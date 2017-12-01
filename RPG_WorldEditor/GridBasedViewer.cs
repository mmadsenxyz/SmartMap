using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using RolePlayingGame.World.GridBased;
using RolePlayingGame.WorldEditor.Properties;

namespace RolePlayingGame.WorldEditor
{
    public partial class GridBasedViewer : PictureBox
    {
        public enum MouseModes
        {
            FreeToMove,
            Selection,
        }

        private MouseModes mouseMode;
        public MouseModes MouseMode
        {
            get { return mouseMode; }
            set { mouseMode = value; }
        }

        private bool showGrids;
        public bool ShowGrids
        {
            get { return showGrids; }
            set { showGrids = value; }
        }

        private bool cursorEnter;
        private bool moving;
        private Point moveOffset;
        private Point offset;
        public Point GetOffset()
        {
            return offset;
        }

        private int gridWidth;
        public int GridWidth
        {
            get { return gridWidth; }
            set { gridWidth = value; }
        }

        private int gridHeight;
        public int GridHeight
        {
            get { return gridHeight; }
            set { gridHeight = value; }
        }

        private Pen gridLinePen;
        public Color GridLineColor
        {
            get { return gridLinePen.Color; }
            set { gridLinePen.Color = value; }
        }
        public float GridLineWidth
        {
            get { return gridLinePen.Width; }
            set { gridLinePen.Width = value; }
        }

        private Pen gridAxisPen;
        public Color GridAxisColor
        {
            get { return gridAxisPen.Color; }
            set { gridAxisPen.Color = value; }
        }
        public float GridAxisWidth
        {
            get { return gridAxisPen.Width; }
            set { gridAxisPen.Width = value; }
        }

        private SolidBrush selectionBrush;
        public Color SelectionColor
        {
            get { return selectionBrush.Color; }
            set { selectionBrush.Color = value; }
        }

        private Image cursorSelectionImage = Resources.CursorSelect;
        private Image cursorMoveImage = Resources.CursorGrab;
        private Image cursorMovingImage = Resources.CursorGrabbed;

        private List<GridBasedViewerItem> items;
        private int selectedItemIndex;
 
        public void AddItem(GridBasedViewerItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(GridBasedViewerItem item)
        {
            items.Remove(item);
        }

        public void RemoveItem(int index)
        {
            items.RemoveAt(index);
        }

        public void RemoveAllItems(int index)
        {
            items.Clear();
        }

        public GridBasedViewerItem GetItem(int index)
        {
            return items[index];
        }

        public int GetSelectedItemIndex()
        {
            return selectedItemIndex;
        }

        public GridBasedViewerItem GetSelectedItem()
        {
            return items[selectedItemIndex];
        }

        public int GetItemCount()
        {
            return items.Count;
        }

        public GridBasedViewer( ) 
            : base()
        {
            GridWidth = 64;
            GridHeight = 64;
            gridLinePen = new Pen(Color.DarkGray, 1.0f);
            gridAxisPen = new Pen(Color.Gray, 3.0f);
            selectionBrush = new SolidBrush(Color.FromArgb(128,Color.Magenta));
            items = new List<GridBasedViewerItem>();
            mouseMode = MouseModes.FreeToMove;
            offset = new Point(0,0);
            moving = false;
            cursorEnter = false;
            showGrids = true;
            selectedItemIndex = -1;
        }

        public void Deselect()
        {
            selectedItemIndex = -1;
        }

        public void Select(int index)
        {
            if (index >= 0 && index < items.Count)
            {
                selectedItemIndex = index;
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Graphics g = pe.Graphics;
            Point curCursor = GetCursorPosition();
            Point curGrid = GetCurrentGrid();

            //Drawing Visible Items
            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                if (items[itemIndex].Visibility)
                {
                    Grid grid = items[itemIndex].GetPosition();

                    int startX = (offset.X + grid.X) * GridWidth;
                    int startY = (offset.Y + grid.Y) * GridHeight;
                    if (
                        (
                            mouseMode == MouseModes.FreeToMove &&
                            moving
                        ) ||
                        (
                            mouseMode == MouseModes.Selection &&
                            moving &&
                            selectedItemIndex >= 0 &&
                            itemIndex == selectedItemIndex
                        )
                    )
                    {
                        startX += (curGrid.X - moveOffset.X) * GridWidth;
                        startY += (curGrid.Y - moveOffset.Y) * GridHeight;
                    }
                    int width = items[itemIndex].PreviewImage.Width;
                    int height = items[itemIndex].PreviewImage.Height;
                    g.DrawImage(items[itemIndex].PreviewImage, new Rectangle(startX, startY, width, height));
                }
            }

            //Drawing Grids
            if (showGrids)
            {
                for (int toRight = GridWidth; toRight < Width; toRight = toRight + GridWidth)
                {
                    g.DrawLine(gridLinePen, toRight, 0, toRight, Height);
                }
                for (int toDown = GridHeight; toDown < Height; toDown = toDown + GridHeight)
                {
                    g.DrawLine(gridLinePen, 0, toDown, Width, toDown);
                }
                int axisX = offset.X * GridWidth;
                int axisY = offset.Y * GridHeight;
                if (mouseMode == MouseModes.FreeToMove &&
                    moving
                )
                {
                    axisX += (curGrid.X - moveOffset.X) * GridWidth;
                    axisY += (curGrid.Y - moveOffset.Y) * GridHeight;
                }
                g.DrawLine(gridAxisPen, axisX, 0, axisX, Height);
                g.DrawLine(gridAxisPen, 0, axisY, Width, axisY);
            }
            //Drawing Selection
            if (selectedItemIndex >= 0)
            {
                Grid position = items[selectedItemIndex].GetPosition();
                int startX = (offset.X + position.X) * GridWidth;
                int startY = (offset.Y + position.Y) * GridHeight;
                if (moving)
                {
                    startX += (curGrid.X - moveOffset.X) * GridWidth;
                    startY += (curGrid.Y - moveOffset.Y) * GridHeight;
                }
                int width = items[selectedItemIndex].PreviewImage.Width;
                int height = items[selectedItemIndex].PreviewImage.Height;
                g.FillRectangle(selectionBrush, new Rectangle(startX, startY, width, height));
            }

            //Drawing Cursor
            Image cursor = null;
            if (cursorEnter)
            {
                if (mouseMode == MouseModes.FreeToMove)
                {
                    if (moving)
                    {
                        cursor = cursorMovingImage;
                    }
                    else
                    {
                        cursor = cursorMoveImage;
                    }
                }
                else
                {
                    cursor = cursorSelectionImage;
                }
                g.DrawImage(cursor, new Rectangle(curCursor.X, curCursor.Y, 16, 16));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Point curGrid = GetCurrentGrid();
            System.Diagnostics.Debug.WriteLine("OnMouseDown...");
            if (e.Button == MouseButtons.Left && mouseMode == MouseModes.FreeToMove)
            {
                moving = true;
                moveOffset = curGrid;
            }
            else if(e.Button == MouseButtons.Left && mouseMode == MouseModes.Selection)
            {
                if (selectedItemIndex >= 0 && curGrid.X == items[selectedItemIndex].GetPosition().X && curGrid.Y == items[selectedItemIndex].GetPosition().Y)
                {
                    moving = true;
                    moveOffset = curGrid;
                }
                GridBasedViewerItem curItem = null;
                selectedItemIndex = -1;
                for (int index = 0; index < items.Count; index++)
                {
                    curItem = items[index];
                    if (curItem.GetPosition().X <= curGrid.X && curItem.GetPosition().Y <= curGrid.Y)
                    {
                        if (curItem.GetPosition().X + (curItem.PreviewImage.Width / GridWidth) > curGrid.X && curItem.GetPosition().Y + (curItem.PreviewImage.Height / GridHeight) > curGrid.Y)
                        {
                            selectedItemIndex = index;
                            break;
                        }
                    }
                }
            }
            Refresh();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            Point curGrid = GetCurrentGrid();
            System.Diagnostics.Debug.WriteLine("OnMouseUp...");
            if (e.Button == MouseButtons.Left && mouseMode == MouseModes.FreeToMove && moving)
            {
                offset.X += curGrid.X - moveOffset.X;
                offset.Y += curGrid.Y - moveOffset.Y;
                moving = false;
                System.Diagnostics.Debug.WriteLine("New offset is " + offset.X + "," + offset.Y);
            }
            if (e.Button == MouseButtons.Left && mouseMode == MouseModes.Selection && moving)
            {
                if (selectedItemIndex >= 0)
                {
                    items[selectedItemIndex].Move(curGrid.X - moveOffset.X, curGrid.Y - moveOffset.Y);
                    moving = false;
                }
                System.Diagnostics.Debug.WriteLine("New item offset is " + offset.X + "," + offset.Y);
            }
            Refresh();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (OnCurrentGridChanged != null)
            {
                OnCurrentGridChanged(GetCurrentGrid());
            }
            Refresh();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            cursorEnter = true;
            System.Windows.Forms.Cursor.Hide();
            Refresh();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            cursorEnter = false;
            System.Windows.Forms.Cursor.Show();
            Refresh();
        }

        public Point GetGridBasedCursorPosition()
        {
            Point local = GetCursorPosition();
            local.X /= GridWidth;
            local.Y /= GridHeight;
            return local;
        }

        public Point GetCurrentGrid()
        {
            Point local = GetGridBasedCursorPosition();
            local.X -= offset.X;
            local.Y -= offset.Y;
            return local;
        }

        public Point GetCursorPosition()
        {
            return PointToClient(System.Windows.Forms.Cursor.Position);
        }

        public delegate void OnCurrentGridChangedMethod(Point Grid);
        public OnCurrentGridChangedMethod OnCurrentGridChanged;
    }
}

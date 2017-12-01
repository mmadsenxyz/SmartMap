using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RolePlayingGame.World.GridBased.Objects;

namespace RolePlayingGame.WorldEditor
{
    public partial class FormGridBasedLevelEditor : Form
    {
        private enum ClipboardTypes
        {
            Empty,
            GridBasedViewerItem,
        }

        private GridBasedViewerItem clipboardViewerItem;
        private ClipboardTypes clipboardType;

        public FormGridBasedLevelEditor()
        {
            InitializeComponent();

            gridBasedViewer1.OnCurrentGridChanged = OnCurrentGridChanged;

            //TEST
            Image image0 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample01.png");
            GridBasedObject obj0 = new GridBasedObject("TerrainSample00");
            obj0.Position.X = -1;
            obj0.Position.Y = 0;

            Image image1 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample01.png");
            GridBasedObject obj1 = new GridBasedObject("TerrainSample01");
            obj1.Position.X = 0;
            obj1.Position.Y = 0;

            Image image2 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample02.png");
            GridBasedObject obj2 = new GridBasedObject("TerrainSample02");
            obj2.Position.X = 1;
            obj2.Position.Y = 0;

            Image image3 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample03.png");
            GridBasedObject obj3 = new GridBasedObject("TerrainSample03");
            obj3.Position.X = 2;
            obj3.Position.Y = 0;

            Image image4 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample04.png");
            GridBasedObject obj4 = new GridBasedObject("TerrainSample04");
            obj4.Position.X = 0;
            obj4.Position.Y = 1;

            Image image5 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample05.png");
            GridBasedObject obj5 = new GridBasedObject("TerrainSample05");
            obj5.Position.X = 1;
            obj5.Position.Y = 1;

            Image image6 = Image.FromFile(@"..\..\..\RPG_Demo\Media\BrowserImages\TerrainSample06.png");
            GridBasedObject obj6 = new GridBasedObject("TerrainSample06");
            obj6.Position.X = 2;
            obj6.Position.Y = 1;

            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj0, image0));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj1, image1));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj2, image2));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj3, image3));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj4, image4));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj5, image5));
            gridBasedViewer1.AddItem(new GridBasedViewerItem(obj6, image6));
            //END OF TEST
        }

        private void OnCurrentGridChanged(Point grid)
        {
            toolStripStatusLabelGrid.Text = "Grid : " + grid.X + "," + grid.Y;
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            SetMouseMode(GridBasedViewer.MouseModes.Selection);
        }

        private void toolStripButtonMove_Click(object sender, EventArgs e)
        {
            SetMouseMode(GridBasedViewer.MouseModes.FreeToMove);
        }

        private void selectionModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMouseMode(GridBasedViewer.MouseModes.Selection);
        }

        private void moveModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMouseMode(GridBasedViewer.MouseModes.FreeToMove);
        }

        public void SetMouseMode(GridBasedViewer.MouseModes mode)
        {
            if (mode == GridBasedViewer.MouseModes.Selection)
            {
                toolStripButtonMove.BackColor = Color.Transparent;
                toolStripButtonSelect.BackColor = Color.DarkGray;
                gridBasedViewer1.MouseMode = GridBasedViewer.MouseModes.Selection;
                moveModeToolStripMenuItem.Checked = false;
                selectionModeToolStripMenuItem.Checked = true;
            }
            else if (mode == GridBasedViewer.MouseModes.FreeToMove)
            {
                toolStripButtonMove.BackColor = Color.DarkGray;
                toolStripButtonSelect.BackColor = Color.Transparent;
                gridBasedViewer1.MouseMode = GridBasedViewer.MouseModes.FreeToMove;
                moveModeToolStripMenuItem.Checked = true;
                selectionModeToolStripMenuItem.Checked = false;
            }
        }

        private void showGridsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            gridBasedViewer1.ShowGrids = !gridBasedViewer1.ShowGrids;
            gridBasedViewer1.Refresh();
        }

        private void clipboardCutGridBasedViewerItem()
        {
            if (gridBasedViewer1.GetSelectedItemIndex() >= 0)
            {
                clipboardType = ClipboardTypes.GridBasedViewerItem;
                clipboardViewerItem = gridBasedViewer1.GetSelectedItem();
                int index = gridBasedViewer1.GetSelectedItemIndex();
                gridBasedViewer1.RemoveItem(index);
                gridBasedViewer1.Deselect();
                gridBasedViewer1.Refresh();
            }
        }

        private void clipboardCopyGridBasedViewerItem()
        {
            if (gridBasedViewer1.GetSelectedItemIndex() >= 0)
            {
                clipboardType = ClipboardTypes.GridBasedViewerItem;
                clipboardViewerItem = (GridBasedViewerItem)gridBasedViewer1.GetSelectedItem().Clone();
            }
        }

        //private GridBasedViewerItem CloneGridBasedViewerItem

        private void clipboardPasteGridBasedViewerItem()
        {
            if (clipboardViewerItem != null)
            {
                clipboardType = ClipboardTypes.GridBasedViewerItem;
                gridBasedViewer1.AddItem(clipboardViewerItem);
                clipboardViewerItem = (GridBasedViewerItem)clipboardViewerItem.Clone();
                gridBasedViewer1.Select(gridBasedViewer1.GetItemCount() - 1);
                gridBasedViewer1.Refresh();
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipboardCutGridBasedViewerItem();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipboardCopyGridBasedViewerItem();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clipboardPasteGridBasedViewerItem();
        }

        private void toolStripButtonCut_Click(object sender, EventArgs e)
        {
            clipboardCutGridBasedViewerItem();
        }

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
            clipboardCopyGridBasedViewerItem();
        }

        private void toolStripButtonPaste_Click(object sender, EventArgs e)
        {
            clipboardPasteGridBasedViewerItem();
        }
    }
}

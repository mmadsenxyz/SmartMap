using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Overlays;
using Axiom.Math;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiCursor : GuiComponent
    {
        public GuiCursor(Panel cursor, List<string> subCursorList, int subCursorIndex) 
            : base(cursor)
        {
            this.subCursorList = subCursorList;
            this.subCursorIndex = subCursorIndex;

            //sychronize cursors at start
            for (int index = 0; index < subCursorList.Count; index++)
            {
                OverlayElement subCursor = ((OverlayElementContainer)element).GetChild(subCursorList[index]);
                if (subCursorIndex == index)
                {
                    subCursor.Show();
                }
                else
                {
                    subCursor.Hide();
                }
            }
        }

        public Panel Cursor
        {
            get { return (Panel)element; }
            set { element = value; }
        }

        private List<string> subCursorList;
        public List<string> SubCursorList
        {
            get { return subCursorList; }
            set { subCursorList = value; }
        }

        private int subCursorIndex;
        public int SubCursorIndex
        {
            get { return subCursorIndex; }
            set
            {
                OverlayElement subCursor = ((OverlayElementContainer)element).GetChild(subCursorList[SubCursorIndex]);
                if (subCursor != null)
                {
                    subCursor.Hide();
                }
                subCursor = ((OverlayElementContainer)element).GetChild(subCursorList[value]);
                if (subCursor != null)
                {
                    subCursor.Show();
                }
                subCursorIndex = value;
            }
        }

        public override void OnFrameStarted()
        {
            Cursor.Left = GuiBase.MouseCoordinates.x;
            Cursor.Top = GuiBase.MouseCoordinates.y;
        }
    }
}

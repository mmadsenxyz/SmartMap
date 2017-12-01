using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RolePlayingGame.GuiDANCE
{
    public partial class GuiRenderBox : PictureBox
    {
        public GuiRenderBox()
        {
            InitializeComponent();
        }

        public GuiRenderBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);
        //    GuiBase.MouseCoordinates = GuiBase.GetMouseCoordinates();
        //}

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor.Hide();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor.Show();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (e.Button == MouseButtons.Left)
            {
                GuiBase.MouseState = GuiMouseState.PressedLeft;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                GuiBase.MouseState = GuiMouseState.PressedMiddle;
            }
            else if (e.Button == MouseButtons.Right)
            {
                GuiBase.MouseState = GuiMouseState.PressedRight;
            }
            else
            {
                GuiBase.MouseState = GuiMouseState.PressedNone;
            }
        }
    }
}

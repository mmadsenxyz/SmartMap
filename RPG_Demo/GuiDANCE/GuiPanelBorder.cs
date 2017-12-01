using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiPanelBorder : GuiPanel
    {
        public GuiPanelBorder(
            Panel center,
            Panel borderTopLeft,
            Panel borderTop,
            Panel borderTopRight,
            Panel borderLeft,
            Panel borderRight,
            Panel borderBottomLeft,
            Panel borderBottom,
            Panel borderBottomRight,
            TextArea textHeader
        ) : base(center)
        {
            this.borderTopLeft = borderTopLeft;
            this.borderTop = borderTop;
            this.borderTopRight = borderTopRight;
            this.borderLeft = borderLeft;
            this.borderRight = borderRight;
            this.borderBottomLeft = borderBottomLeft;
            this.borderBottom = borderBottom;
            this.borderBottomRight = borderBottomRight;
            this.textHeader = textHeader;
        }

        public void Resize(float width, float height)
        {
            Center.Width = width;
            Center.Height = height;
            BorderTop.Width = width;
            BorderBottom.Width = width;
            BorderLeft.Height = height;
            BorderRight.Height = height;
            BorderTopRight.Left = width;
            BorderRight.Left = width;
            BorderBottomRight.Left = width;
            BorderBottomLeft.Top = height;
            BorderBottom.Top = height;
            BorderBottomRight.Top = height;
            Center.Parent.Width = width;
            Center.Parent.Height = height;
        }

        public void Move(float x, float y, HorizontalAlignment alignH, VerticalAlignment alignV)
        {
            Center.Parent.HorizontalAlignment = alignH;
            Center.Parent.VerticalAlignment = alignV;
            Move(x, y);
        }

        public void Move(float x, float y)
        {
            Center.Parent.Left = x;
            Center.Parent.Top = y;
        }

        private Panel borderTopLeft;
        public Panel BorderTopLeft
        {
            get { return borderTopLeft; }
            set { borderTopLeft = value; }
        }
        private Panel borderTop;
        public Panel BorderTop
        {
            get { return borderTop; }
            set { borderTop = value; }
        }
        private Panel borderTopRight;
        public Panel BorderTopRight
        {
            get { return borderTopRight; }
            set { borderTopRight = value; }
        }
        private Panel borderLeft;
        public Panel BorderLeft
        {
            get { return borderLeft; }
            set { borderLeft = value; }
        }
        private Panel borderRight;
        public Panel BorderRight
        {
            get { return borderRight; }
            set { borderRight = value; }
        }
        private Panel borderBottomLeft;
        public Panel BorderBottomLeft
        {
            get { return borderBottomLeft; }
            set { borderBottomLeft = value; }
        }
        private Panel borderBottom;
        public Panel BorderBottom
        {
            get { return borderBottom; }
            set { borderBottom = value; }
        }
        private Panel borderBottomRight;
        public Panel BorderBottomRight
        {
            get { return borderBottomRight; }
            set { borderBottomRight = value; }
        }
        private TextArea textHeader;
        public TextArea TextHeader
        {
            get { return textHeader; }
            set { textHeader = value; }
        }

        public override bool Visibility
        {
            get
            {
                return base.Visibility;
            }
            set
            {
                base.Visibility = value;
                if (value == true)
                {
                    borderTopLeft.Show();
                    borderTop.Show();
                    borderTopRight.Show();
                    borderLeft.Show();
                    borderRight.Show();
                    borderBottomLeft.Show();
                    borderBottom.Show();
                    borderBottomRight.Show();
                    textHeader.Show();
                }
                else
                {
                    borderTopLeft.Hide();
                    borderTop.Hide();
                    borderTopRight.Hide();
                    borderLeft.Hide();
                    borderRight.Hide();
                    borderBottomLeft.Hide();
                    borderBottom.Hide();
                    borderBottomRight.Hide();
                    textHeader.Hide();
                }
            }
        }
    }
}

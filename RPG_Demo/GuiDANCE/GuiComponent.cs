using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Axiom.Overlays;

namespace RolePlayingGame.GuiDANCE
{
    public abstract class GuiComponent
    {
        public GuiComponent(OverlayElement element)
        {
            this.element = element;
            OverlayElement child = element;
            OverlayElementContainer parent = element.Parent;

            this.Width = element.Width;
            this.Height = element.Height;

            do
            {
                this.Left += child.Left;
                this.Top += child.Top;
                if (parent == null)
                {
                    if (child.HorizontalAlignment == HorizontalAlignment.Right)
                    {
                        this.Left += GuiBase.Resolution.x;
                    }
                    else if (child.HorizontalAlignment == HorizontalAlignment.Center)
                    {
                        this.Left += (GuiBase.Resolution.x / 2);
                    }
                    if (child.VerticalAlignment == VerticalAlignment.Bottom)
                    {
                        this.Top += GuiBase.Resolution.y;
                    }
                    else if (child.VerticalAlignment == VerticalAlignment.Center)
                    {
                        this.Left += (GuiBase.Resolution.y / 2);
                    }
                    break;
                }
                if (child.HorizontalAlignment == HorizontalAlignment.Right)
                {
                    this.Left += parent.Width;
                }
                else if (child.HorizontalAlignment == HorizontalAlignment.Center)
                {
                    this.Left += (parent.Width / 2);
                }
                if (child.VerticalAlignment == VerticalAlignment.Bottom)
                {
                    this.Top += parent.Height;
                }
                else if (child.VerticalAlignment == VerticalAlignment.Center)
                {
                    this.Left += (parent.Height / 2);
                }
                child = parent;
                parent = parent.Parent;
            }
            while (true);
        }

        protected OverlayElement element;

        private float left;
        public float Left
        {
            get { return left; }
            set { left = value; }
        }

        private float top;
        public float Top
        {
            get { return top; }
            set { top = value; }
        }

        public float Right
        {
            get { return left + width; }
        }

        public float Bottom
        {
            get { return top + height; }
        }

        private float width;
        public float Width
        {
            get { return width; }
            set { width = value; }
        }

        private float height;
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        public string Name
        {
            get
            {
                return element.Name;
            }
        }

        public virtual bool Visibility
        {
            get
            {
                return element.IsVisible;
            }
            set
            {
                if (value == true)
                {
                    element.Show();
                }
                else
                {
                    element.Hide();
                }
            }
        }

        private bool focus;
        public bool Focus
        {
            get { return focus; }
            set
            {
                if (focus != value)
                {
                    if (value == true)
                    {
                        if (OnMouseEnter != null) { OnMouseEnter(this); }
                    }
                    else
                    {
                        if (OnMouseLeave != null) { OnMouseLeave(this); }
                    }
                }
                focus = value;
            }
        }

        public abstract void OnFrameStarted();

        public delegate void OnMouseEnterMethod(GuiComponent component);
        public delegate void OnMouseLeaveMethod(GuiComponent component);
        public OnMouseEnterMethod OnMouseEnter;
        public OnMouseLeaveMethod OnMouseLeave;
    }
}

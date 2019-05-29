using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiButtonCheckbox : GuiButtonPlain
    {
        public GuiButtonCheckbox(Panel button, Panel check)
            : base(button)
        {
            this.check = check;
        }

        public bool IsChecked()
        {
            return check.IsVisible;
        }

        private Panel check;
        public Panel Check
        {
            get { return check; }
            set { check = value; }
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
                    Check.Show();
                }
                else
                {
                    Check.Hide();
                }
            }
        }

        public override void OnFrameStarted()
        {
            if (GuiBase.MouseCoordinates.x >= Left &&
                GuiBase.MouseCoordinates.y >= Top &&
                GuiBase.MouseCoordinates.x <= Right &&
                GuiBase.MouseCoordinates.y <= Bottom)
            {
                Focus = true;
                switch (GuiBase.MouseState)
                {
                    case GuiMouseState.PressedNone:
                        {
                            break;
                        }
                    case GuiMouseState.PressedLeft:
                        {
                            if(Check.IsVisible) { Check.Hide(); }
                            else { Check.Show(); }
                            System.Diagnostics.Debug.WriteLine("Button Clicked");
                            if (OnMouseClick != null) { OnMouseClick(this); }
                            break;
                        }
                    case GuiMouseState.PressedMiddle:
                        {
                            break;
                        }
                    case GuiMouseState.PressedRight:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            else
            {
                Focus = false;
            }
        }
    }
}

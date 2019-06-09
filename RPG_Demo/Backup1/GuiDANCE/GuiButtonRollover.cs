using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiButtonRollover : GuiButtonPlain
    {
        public GuiButtonRollover(Panel button, Panel rollOver)
            : base(button)
        {
            this.rollOver = rollOver;
        }

        private Panel rollOver;
        public Panel RollOver
        {
            get { return rollOver; }
            set { rollOver = value; }
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
                    RollOver.Show();
                }
                else
                {
                    RollOver.Hide();
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
                //Optimization to multi GuiButtonRollovers can use single rollover element 
                RollOver.Left = Button.Left + ((Button.Width - RollOver.Width) / 2.0f);
                RollOver.Top = Button.Top + ((Button.Height - RollOver.Height) / 2.0f);
                RollOver.Show();
                switch (GuiBase.MouseState)
                {
                    case GuiMouseState.PressedNone:
                        {
                            break;
                        }
                    case GuiMouseState.PressedLeft:
                        {
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
                //Optimization to multi GuiButtonRollovers can use single rollover element 
                if (RollOver.Left == Button.Left + ((Button.Width - RollOver.Width) / 2.0f) &&
                    RollOver.Top == Button.Top + ((Button.Height - RollOver.Height) / 2.0f))
                {
                    RollOver.Hide();
                }
                Focus = false;
            }
        }
    }
}

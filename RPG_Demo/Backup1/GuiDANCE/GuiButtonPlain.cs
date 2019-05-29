using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiButtonPlain : GuiComponent
    {
        public GuiButtonPlain(Panel button)
            : base(button)
        {
            Focus = false;
        }

        public Panel Button
        {
            get { return (Panel)element; }
            set { element = value; }
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

        public delegate void OnMouseClickMethod(GuiButtonPlain button);
        public OnMouseClickMethod OnMouseClick;

    }
}

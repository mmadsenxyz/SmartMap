using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;

namespace RolePlayingGame.GuiDANCE
{
    public class GuiPanel : GuiComponent
    {
        public GuiPanel(Panel center)
            : base(center)
        {
            components = new List<GuiComponent>();
        }

        private List<GuiComponent> components;
        public List<GuiComponent> Components
        {
            get { return components; }
            set { components = value; }
        }

        public Panel Center
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
                switch (GuiBase.MouseState)
                {
                    case GuiMouseState.PressedNone:
                        {
                            break;
                        }
                    case GuiMouseState.PressedLeft:
                        {
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

            for (int index = 0; index < Components.Count; index++)
            {
                if (Components[index].Visibility == true)
                {
                    Components[index].OnFrameStarted();
                }
            }
        }

        public delegate void OnClickMethod();
        public OnClickMethod OnClick;

    }
}

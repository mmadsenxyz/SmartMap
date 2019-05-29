using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Axiom.Math;
using Axiom.Graphics;
using Axiom.Input;

namespace RolePlayingGame.GuiDANCE
{
    public enum GuiMouseState
    {
        PressedNone,
        PressedLeft,
        PressedMiddle,
        PressedRight,
    }

    public static class GuiBase
    {
        public static GuiCursor Cursor;
        public static List<GuiPanel> Panels = new List<GuiPanel>();
        public static Vector2 Resolution;

        public static GuiRenderBox RenderBox;

        private static RenderWindow renderWindow;
        public static RenderWindow RenderWindow
        {
            get 
            { 
                return GuiBase.renderWindow; 
            }
            set 
            { 
                GuiBase.renderWindow = value;
                Resolution = new Vector2((float)renderWindow.Width, (float)renderWindow.Height);
            }
        }
        private static Vector2 mouseCoordinates;
        public static Vector2 MouseCoordinates
        {
            get { return GuiBase.mouseCoordinates; }
            set { GuiBase.mouseCoordinates = value; }
        }

        private static Vector2 GetMouseCoordinates()
        {
            Point clientMouse = RenderBox.PointToClient(System.Windows.Forms.Cursor.Position);
            return new Vector2(((float)clientMouse.X / (float)RenderBox.Width) * Resolution.x, ((float)clientMouse.Y / (float)RenderBox.Height) * Resolution.y);
        }

        private static GuiMouseState mouseState;
        public static GuiMouseState MouseState
        {
            get { return mouseState; }
            set { mouseState = value; }
        }

        public static void OnFrameStarted()
        {
            mouseCoordinates = GetMouseCoordinates();
            Cursor.OnFrameStarted();
            for (int index = 0; index < Panels.Count; index++)
            {
                Panels[index].OnFrameStarted();
            }
            mouseState = GuiMouseState.PressedNone;
        }
    }
}

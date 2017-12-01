using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace RolePlayingGame.World.GridBased
{
    public class Grid
    {
        public int X;
        public int Y;

        public Grid()
        {
            X = 0;
            Y = 0;
        }

        public Grid(int x, int y)
        {
            X = x;
            Y = y;
        }
        public static float GetGridWidth(UnitTypes unitType)
        {
            switch (unitType)
            {
                case UnitTypes.SceneUnit:
                    {
                        return GridBasedWorld.GRID_WIDTH;
                    }
                case UnitTypes.Pixel:
                    {
                        return GridBasedWorld.GRID_WIDTH * GridBasedWorld.SCENEUNIT_TO_PIXEL_RATIO;
                    }
                default:
                    {
                        return GridBasedWorld.GRID_WIDTH;
                    }
            }
        }

        public static float GetGridLength(UnitTypes unitType)
        {
            switch (unitType)
            {
                case UnitTypes.SceneUnit:
                    {
                        return GridBasedWorld.GRID_LENGTH;
                    }
                case UnitTypes.Pixel:
                    {
                        return GridBasedWorld.GRID_LENGTH * GridBasedWorld.SCENEUNIT_TO_PIXEL_RATIO;
                    }
                default:
                    {
                        return GridBasedWorld.GRID_LENGTH;
                    }
            }
        }

        public Grid Rotate(Grid axis, RotationTypes rotationType)
        {
            int rotate90Count = (int) rotationType;
            Grid rotatedGrid = new Grid(X, Y);
            for (int index = 0; index < rotate90Count; index++)
            {
                rotatedGrid = rotatedGrid.Rotate90(axis);
            }
            return rotatedGrid;
        }

        private Grid Rotate90(Grid axis)
        {
            int x = axis.X - (Y - axis.Y);
            int y = axis.Y - (X - axis.X);
            return new Grid(x, y);
        }
    }
}

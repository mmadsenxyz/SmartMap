using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.GridBased
{
    public class GridArea
    {
        public GridArea(Grid start, Grid end)
        {
            Start = start;
            End = end;
        }

        private Grid start;
        public Grid Start
        {
            get { return start; }
            set { start = value; Normalize(); }
        }

        private Grid end;
        public Grid End
        {
            get { return end; }
            set { end = value; Normalize(); }
        }

        public GridSize GetSize()
        {
            return new GridSize(end.X - start.X, end.Y - start.Y);
        }

        private void Normalize()
        {
            if (start == null || end == null)
            {
                return;
            }
            else
            {
                if (end.X < start.X)
                {
                    //swapping integers without temp variable
                    end.X = end.X + start.X;
                    start.X = end.X - start.X;
                    end.X = end.X - start.X;
                }
                if (end.Y < start.Y)
                {
                    //swapping integers without temp variable
                    end.Y = end.Y + start.Y;
                    start.Y = end.Y - start.Y;
                    end.Y = end.Y - start.Y;
                }
            }
        }
    }
}

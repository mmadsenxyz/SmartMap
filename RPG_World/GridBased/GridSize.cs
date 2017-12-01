using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.GridBased
{
    public class GridSize
    {
        public GridSize(int width, int length)
        {
            Width = width;
            Length = length;
        }

        private int width;
        public int Width
        {
            get { return width; }
            set { width = Math.Abs(value); }
        }

        private int length;
        public int Length
        {
            get { return length; }
            set { length = Math.Abs(value); }
        }
    }
}

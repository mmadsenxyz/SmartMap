using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.Generic;

namespace RolePlayingGame.World.GridBased.Objects
{
    public class GridBasedObject
    {
        public GridBasedObject(string name)
        {
            Name = name;
            Position = new Grid();
            Rotation = RotationTypes.Rotate_0;
            ScaleFactor = 1.0f;
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private Grid position;
        public Grid Position
        {
            get { return position; }
            set { position = value; }
        }

        private RotationTypes rotation;
        public RotationTypes Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        private float scaleFactor;
        public float ScaleFactor
        {
            get { return scaleFactor; }
            set { scaleFactor = value; }
        }

        //public void Rotate(RotationTypes rotationType)
        //{
        //    base.Rotate(axis, rotationType);
        //    Rotation = (RotationTypes)(((int)Rotation + (int)rotationType) % 4);
        //}
    }
}

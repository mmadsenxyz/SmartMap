using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.GridBased.Objects;

namespace RolePlayingGame.World.GridBased.Layers
{
    public class GridBasedLayerFloor : GridBasedLayer
    {
        private List<GridBasedObjectFloor> floorList;

        public List<GridBasedObjectFloor> FloorList
        {
            get { return floorList; }
            set { floorList = value; }
        }
    }
}

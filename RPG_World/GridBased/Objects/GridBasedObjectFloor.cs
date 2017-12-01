using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.GridBased.Objects
{
    public class GridBasedObjectFloor : GridBasedObject
    {
        public GridBasedObjectFloor(string name)
            : base(name)
        {

        }

        public string GetMeshName()
        {
            return Name + GridBasedWorld.MESH_EXTENSION;
        }

        public string GetMaterialName()
        {
            return Name + GridBasedWorld.MATERIAL_EXTENSION;
        }
    }
}

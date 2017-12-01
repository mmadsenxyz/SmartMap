using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.GridBased.Templates;

namespace RolePlayingGame.World.GridBased.TemplateLibraries
{
    public class GridBasedTemplateFloorLibrary
    {
        public GridBasedTemplateFloorLibrary()
        {
            floors = new List<GridBasedTemplateFloor>();
        }

        private List<GridBasedTemplateFloor> floors;
        public List<GridBasedTemplateFloor> Floors
        {
            get { return floors; }
            set { floors = value; }
        }
    }
}

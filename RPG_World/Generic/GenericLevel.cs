using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RolePlayingGame.World.Generic
{
    public class GenericLevel
    {
        public GenericLevel()
        {
            layerList = new List<GenericLayer>();
        }

        private List<GenericLayer> layerList;
        public List<GenericLayer> LayerList
        {
            get { return layerList; }
            set { layerList = value; }
        }
    }
}

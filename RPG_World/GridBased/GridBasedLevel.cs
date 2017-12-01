using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.Generic;
using RolePlayingGame.World.GridBased.Layers;

namespace RolePlayingGame.World.GridBased
{
    public enum GridBasedLayerTypes : int
    {
        Floor = 0,
        Obstacle = Floor + 1,
        Interactive = Obstacle + 1,
        ParticleEffect = Interactive + 1,
        Light = ParticleEffect + 1,
        Sound = Light + 1,
    }
    public class GridBasedLevel : GenericLevel
    {
        public GridBasedLevel()
            : base()
        {
            LayerList.Add(new GridBasedLayerFloor());
            LayerList.Add(new GridBasedLayerObstacle());
            LayerList.Add(new GridBasedLayerInteractive());
            LayerList.Add(new GridBasedLayerParticleEffect());
            LayerList.Add(new GridBasedLayerLight());
            LayerList.Add(new GridBasedLayerSound());
        }
    }
}

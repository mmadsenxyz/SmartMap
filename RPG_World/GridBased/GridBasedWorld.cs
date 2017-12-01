using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RolePlayingGame.World.Generic;

namespace RolePlayingGame.World.GridBased
{
    public enum UnitTypes
    {
        SceneUnit,
        Pixel,
    }
    public static class GridBasedWorld
    {
        public static float GRID_WIDTH = 2.0f;  //A 1x1 grid size on x-axis by SceneUnits
        public static float GRID_LENGTH = 2.0f; //A 1x1 grid size on z-axis by SceneUnits

        public static float SCENEUNIT_TO_PIXEL_RATIO = 32.0f;  //The ratio between one SceneUnit and one Pixel

        public static string PREVIEW_IMAGE_EXTENSION = ".png";
        public static string MESH_EXTENSION = ".mesh";
        public static string MATERIAL_EXTENSION = ".material";
    }
}

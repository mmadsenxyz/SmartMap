/*
 * Code by Mark V Madsen
 * License BSD
*/
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using QuickGraph;
using Axiom.Animating;
using Axiom.Core;
using Axiom.Collections;
using Axiom.Math;
using Axiom.Graphics;
using Axiom.Input;

namespace SmartMap
{
    /// <summary>
    /// Creates the 3D objects for the 3D graphics renderer
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    public class Draw3D : EngineSetup, IDraw, IDisposable
    {
        // Map
        SmartMap_Core sm;
        private Draw4D d4d;
        public Dictionary<int, Entity> interiorTile;
        public Dictionary<int, Entity> exteriorTile;
        public SceneNode[] tileNode;
        public SceneNode[] moduleNode;
        public SceneNode[] quadrantNode;
        public SceneNode[] mapNode;
        private int meshCount = 0, textureCount = 0;
        private int nodeCount = 0;
        private int moduleCount = 0, quadrantCount = 0, mapCount = 0;
        private int newModuleCount = 0;//, newQuadrantCount = 0, newMapCount = 0;
        //private int nextPathnode = 0;
        public int tileAmountNorth = 15, tileAmountEast = 15;
        private int tileThreshhold = 80, tileClippingAngle = 300;
        private int tilesetNorth = 1, tilesetEast = 1, tileSetDispersion = 7;
        private float mapSizeNorth = 0, mapSizeEast = 0, tileSetHeight = 150;
        private int sideTileCount = 1000, hallTileCount = 5000, cornerTileCount = 9000, endTileCount = 13000, floorTileCount = 17000;
        private int outSideTileCount = 500, outHallTileCount = 2500, outCornerTileCount = 4500, outEndTileCount = 6500, outFloorTileCount = 8500;
        private float sew2, sew3, sel2, sel3, tew2, tew3, tel2, tel3; // 2nd and 3rd source edge and target edge
        // Graphics
        public static float MeshSize = 276.75f;
        protected TextureFiltering TexFilter = TextureFiltering.Anisotropic;
        public int anisoNumber = 8;
        // Animation
        protected AnimationState modelAnimationState = null; // animationstate of the moving object
        protected float distanceToNextWaypoint = 0.0f;   // the distance the object has left to travel
        protected Vector3 directionOfTravel = Vector3.Zero; // the direction the object is moving
        protected Vector3 nextWaypoint = Vector3.Zero; // the destination that the object is moving towards
        protected float modelWalkSpeed = 200.0f; // the speed at which the object is moving
        protected bool isModelWalking = false;    // Whether or not the object is moving
        protected float timeSinceLastFrame = 0.0f;
        // Occlusion
        //private EntityList entityList = new EntityList();
        public int camClipped = 0;
        //private int objectsVisible = 0;

        public Draw3D()
        {
            this.sm = new SmartMap_Core();

            this.mapSizeEast = MeshSize * tileAmountEast;
            this.mapSizeNorth = MeshSize * tileAmountNorth;

            this.interiorTile = new Dictionary<int, Entity>(3200000);
            this.exteriorTile = new Dictionary<int, Entity>(3200000);
            this.tileNode = new SceneNode[1000000];
            this.moduleNode = new SceneNode[1000000];
            this.quadrantNode = new SceneNode[1000000];
            this.mapNode = new SceneNode[100];
        }

        #region Properties

        #endregion

        #region Create Scene

        protected override void CreateScene()
        {
            CreateEnvironment();
            /*
            // =Draw 3D= - SmartMap's 3D window (Axiom3D)            
            // ==== WARNING :: Keep 'count' variables consistant with resource number changes 
            CreateGraphics(interiorTile, "Room_Side", "Room_Side.mesh", "TileSet/Room", 4000, 4000, true);
            CreateGraphics(interiorTile, "Room_Hall", "Room_Hall.mesh", "TileSet/Room", 4000, 4000, false);
            CreateGraphics(interiorTile, "Room_Corner", "Room_Corner.mesh", "TileSet/Room", 4000, 4000, false);
            CreateGraphics(interiorTile, "Room_End", "Room_End.mesh", "TileSet/Room", 4000, 4000, false);
            CreateGraphics(interiorTile, "Room_Floor", "Room_Floor.mesh", "TileSet/Room", 4000, 4000, false);
            // outer wall resources - (change these to your outer-wall meshes and materials)
            CreateGraphics(exteriorTile, "Wall_Side", "Room_Side.mesh", "TileSet/Wall", 2000, 2000, true);
            CreateGraphics(exteriorTile, "Wall_Hall", "Room_Hall.mesh", "TileSet/Wall", 2000, 2000, false);
            CreateGraphics(exteriorTile, "Wall_Corner", "Room_Corner.mesh", "TileSet/Wall", 2000, 2000, false);
            CreateGraphics(exteriorTile, "Wall_End", "Room_End.mesh", "TileSet/Wall", 2000, 2000, false);
            CreateGraphics(exteriorTile, "Wall_Floor", "Room_Floor.mesh", "TileSet/Wall", 2000, 2000, false);

            // for loops creating new settings for each tile-set - add 2 more tiles for map perimeter
            CreateObjects(tileSetDispersion, this.tileAmountNorth, this.tileAmountEast, tilesetNorth, tilesetEast);
            */
            // =Draw 4D= - For dynamic objects in scene
            // TODO: set up clipping regions for 4 tileSets
            this.d4d = new Draw4D(SceneManager);
            d4d.idraw = this;
            // Tileset
            d4d.CreateModel();
            d4d.modelNode[0].Position = new Vector3(0, tileSetHeight + 500, 0);

            // Set idle animation
            //modelAnimationState = d4d.model[0].GetAnimationState("Idle");
            //modelAnimationState.Loop = true;
            //modelAnimationState.IsEnabled = true;

            // =Save/Load= from XML
            /* this.sm.Save();*/

            #region DEBUG
            //Console.WriteLine("{0}, {1}", d4d.zoneGroup[0].Position, d4d.zoneGroup[2].Position);
            //Console.ReadLine();
            //Frustum.IsVisible = true;
            // show some Bounding Boxes as Zone corners
            /*tileNode[0].ShowBoundingBox = true;
            tileNode[901].ShowBoundingBox = true;
            tileNode[1800].ShowBoundingBox = true;
            tileNode[2701].ShowBoundingBox = true;
            // Models
            //d4d.modelNode[0].ShowBoundingBox = true;
            // Zone Groups
            /*d4d.zoneNode[18].ShowBoundingBox = true;
            d4d.zoneNode[19].ShowBoundingBox = true;
            d4d.zoneNode[20].ShowBoundingBox = true;        
            d4d.zoneNode[24].ShowBoundingBox = true;
            d4d.zoneNode[25].ShowBoundingBox = true;
            d4d.zoneNode[26].ShowBoundingBox = true;    
            d4d.zoneNode[30].ShowBoundingBox = true;
            d4d.zoneNode[31].ShowBoundingBox = true;
            d4d.zoneNode[32].ShowBoundingBox = true;    
            */
            //Window.DebugText = string.Format("Press E to enter Edit Mode");
            #endregion DEBUG
        }

        protected virtual void CreateEnvironment()
        {
            // set some ambient light
            SceneManager.AmbientLight = new ColorEx(1.0f, 0.4f, 0.4f, 0.4f);

            SceneManager.SetFog(FogMode.Exp, ColorEx.White, 0.00001f);

            // create a skydome
            SceneManager.SetSkyDome(true, "Examples/CloudySky", 5, 8);

            // create a simple default point light
            Light light = SceneManager.CreateLight("MainLight");
            light.Position = new Vector3(20, 80, 50);

            // create Tarrain
            SceneManager.LoadWorldGeometry("Terrain.xml");

            MaterialManager.Instance.SetDefaultTextureFiltering(TexFilter);
            MaterialManager.Instance.DefaultAnisotropy = anisoNumber;
            // water plane setup
            Plane waterPlane = new Plane(Vector3.UnitY, 1.5f);

            MeshManager.Instance.CreatePlane(
                                             "WaterPlane",
                                             ResourceGroupManager.DefaultResourceGroupName,
                                             waterPlane,
                                             2800, 2800,
                                             20, 20,
                                             true, 1,
                                             10, 10,
                                             Vector3.UnitZ);

            Entity waterEntity = SceneManager.CreateEntity("Water", "WaterPlane");
            waterEntity.MaterialName = "Terrain/WaterPlane";

            var waterNode = SceneManager.RootSceneNode.CreateChildSceneNode("WaterNode");
            waterNode.AttachObject(waterEntity);
            waterNode.Translate(new Vector3(1000, 0, 1000));

            this.frustumNode.Position = new Vector3(128, 25, 128);
            Camera.LookAt(new Vector3(0, 0, -300));
            
        }

        /// <summary>
        /// Create meshes and textures
        /// </summary>
        /// <param name="tileName">Title of the Tile</param>
        /// <param name="tileFileName">FileName of the Tile</param>
        /// <param name="materialName">Material name of the texture</param>
        /// <param name="meshAmount">The amount of meshes you want - Must match tile creation</param>
        /// <param name="textureAmount">The amount of textures you want - Must match tile creation</param>
        /// <param name="newEntity">Reset Entity count to zero for a new Entity or not stack entity numbers</param>
        public void CreateGraphics(Dictionary<int, Entity> entity, string tileName, string tileFileName, string materialName, int meshAmount,
            int textureAmount, bool newEntity)
        {
            if (newEntity == true)
            {
                meshCount = 0; textureCount = 0;
            }
            for (int i = meshCount; i < meshAmount + meshCount; ++i)
            {
                entity[i] = SceneManager.CreateEntity(tileName + i, tileFileName);
            }
            for (int i = textureCount; i < textureAmount + textureCount; ++i)
            {
                entity[i].MaterialName = materialName;
            }
            meshCount += meshAmount;
            textureCount += textureAmount;
        }

        public void AddModule()
        {
            // don't reset terrain
        }

        /// <summary>
        /// Create tileSets as needed
        /// </summary>
        /// <param name="tilesetDispersion">Distance of dispersed Tilesets</param>
        /// <param name="tilesetNorth">Amount of Tilests North - At least 1</param>
        /// <param name="tilesetEast">Amount of Tilesets East - At least 1</param>
        public void CreateObjects(int tilesetDispersion, int tileAmountNorth, int tileAmountEast, int tilesetNorth, int tilesetEast)
        {
            float moveEast = 0, moveNorth = 0, moveUp = 0;
            int clippedTileCount = 0;
            bool moduleNodeDestroyed = false;

            this.sm.GenerateGraph("TILESET", false, tileAmountNorth, tileAmountEast);
            CreateTileset(interiorTile, 0, 0, 0); // create generic tileset to adjust it to terrain
            // get terrain height - search in center of module - clipping doesn't work as well if oblong map
            moveUp = SceneManager.GetHeightAt(new Vector3(moveEast + (mapSizeEast / 2), 0, moveNorth + (mapSizeNorth / 2)), 0);
            Console.WriteLine("Map Location: {0}, {1}", moveEast, moveNorth);
            // translate module node                 
            this.moduleNode[moduleCount].Translate(new Vector3(moveEast, moveUp, moveNorth), TransformSpace.World);
            // check each tileNode verses module node's height and remove buried edges and tiles. 
            Console.WriteLine("{0}", moduleNode[moduleCount].Name + "'s nodes are being searched for terrain clipping...");
            foreach (SceneNode node in moduleNode[moduleCount].Children) // go through tiles
            { //// STAGGER MODULE ////
                Console.WriteLine("{0}", node.Name + " is being checked..."); // derivedPosition for real world tileNode position - (derived) very important.
                float tileHeight = SceneManager.GetHeightAt(new Vector3(node.DerivedPosition.x, 0, node.DerivedPosition.z), 0);
                if (tileHeight > (moveUp - MeshSize) + tileClippingAngle) // if tile is in terrain 
                {
                    clippedTileCount++;
                    if (clippedTileCount == tileThreshhold)
                    { // if removed tile count equals tileThreshold, remove entire module
                        SceneManager.DestroySceneNode(moduleNode[moduleCount].Name);
                        moduleNodeDestroyed = true;
                        Console.WriteLine("Too many tiles clipped so module removed. Searching next module.\n\n\n");
                    }
                    else if (!moduleNodeDestroyed)
                    { // remove tile 
                        Console.WriteLine("{0}", node.Name + " is too far in terrain.");
                        // remove trimmed tileNodes' vertex from graph
                        for (int x = 0; x < this.sm.Width; x++)
                        {
                            for (int z = 0; z < this.sm.Length; z++)
                            {
                                // check vertex against tileNode vertex
                                if (x * MeshSize == node.Position.x & z * MeshSize == node.Position.z)
                                {
                                    if (this.sm.graph.ContainsVertex(new Point<int>(x, z)))
                                    {
                                        Console.WriteLine("Found tilenode's buried Readout vertex: " + x + "," + z + " ...Removing vertex.");
                                        this.sm.graph.RemoveVertex(new Point<int>(x, z)); // remove vertices to search valid graph. 
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (moduleNodeDestroyed == false)
            { // remake modified module 
              //// MAZE MODULE //// 
                Console.WriteLine("...Re-Creating " + moduleNode[moduleCount].Name + "'s tile-set into maze that fits terrain.");
                // reset node arrays
                SceneManager.DestroySceneNode(moduleNode[moduleCount].Name);
                Console.WriteLine("Destroyed {0} for re-creation", moduleNode[moduleCount].Name);
                if (!this.sm.GeneratePath("TILESET", false, 1, 1, 9, 0))
                { // generate maze with auto or manual path - if it zonks out skip :-)   
                    return;
                }
                this.sm.SearchPath("BFS", moduleNode[moduleCount]); // search module (shortest-path)
                CreateTileset(interiorTile, 0, 0, 0);
                Console.WriteLine(moduleNode[moduleCount].Name + " re-modeled\n.");
                // translate new module node                 
                this.moduleNode[moduleCount].Translate(new Vector3(moveEast, moveUp + tileSetHeight, moveNorth), TransformSpace.World);
                // mold terrain to fit module 
                /*foreach (SceneNode node in moduleNode[moduleCount].Children)
                { // bring up or lower terrain (terrain deformation) to match all tileNode heights 
                        Console.WriteLine("New Set {0} {1}", node.DerivedPosition.x, node.DerivedPosition.z);
                    SceneManager.SetHeightAt(node.DerivedPosition.x, node.DerivedPosition.y - 135, node.DerivedPosition.z);
                }*/
                moduleCount++; // next module only if not destroyed
            }
            // reset variables
            clippedTileCount = 0;
        }

        /// <summary>
        /// Create Quadrants for Map (Each Vertex is a Quadrant and not a Module)
        /// </summary>
        /// <param name="tilesetDispersion">Distance of dispersed Tilesets</param>
        /// <param name="tilesetNorth">Amount of Tilests North - At least 1</param>
        /// <param name="tilesetEast">Amount of Tilesets East - At least 1</param>
        public void CreateWorld(int quadrantDispersion, int quadrantAmountNorth, int quadtrantAmountEast, int quadrantNorth, int quadrantEast)
        {
            this.sm.GenerateGraph("MAP", false, 2, 2);
            this.sm.GeneratePath("MAP", false, 1, 1, 9, 0); // generate maze with auto or manual path - has error handling   

            CreateMap(0, 0, 0);
        }

        #endregion Create Scene

        #region Tileset

        /// <summary>
        /// Prints tile-set as a 3D Axiom "moduleNode" SceneNode 
        /// </summary>
        /// <param name="tile">An array of tile entites to create</param>
        /// <param name="recreate">Recreate the tile-set or it creates a new one</param>
        /// <param name="skew">Skewing of tile tile-set dispersion</param>
        /// <param name="xPosition">Where to place the tile-set in the scene X</param>
        /// <param name="yPosition">Where to place the tile-set in the scene Y</param>
        /// <param name="zPosition">Where to place the tile-set in the scene Z</param>
        public void CreateTileset(Dictionary<int, Entity> tile, /*int skew,*/ float xPosition, float yPosition, float zPosition)
        {
            float x = 0, /*y = 0,*/ z = 0;
            int passes = 0;

            // create modules per Tileset
            this.moduleNode[moduleCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Module " + moduleCount);

            // MAKE TILES - transfer graph to Axiom 
            // do vertices
            foreach (Point<int> v in sm.md.Keys) // taken from mazed MultiDictionary
            {
                passes = 0; // must complete edge amount to create tileNode
                // get the initial vertex size of world map.
                x = (v.Width * MeshSize) + xPosition;
                z = (v.Length * MeshSize) + zPosition;

                // find current edge values. Verteces remain the same
                Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>> ec =
                    (Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>>)sm.md[v];
                // do edges 
                foreach (Edge<Point<int>> e in ec) // edges per vertex, 1-4
                {
                    // END
                    if (ec.Count == 1) // one edge for End tile
                    {
                        tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                        tileNode[nodeCount].ResetToInitialState(); // set mesh North as created in modeler
                        tileNode[nodeCount].Position = new Vector3(x, 0, z);
                        // add exterior tile if adjacent edge is empty. Corner for two. 
                        if (this.sm.NearbyVerticesEmpty(v) == "empty_corner")
                        {
                            tileNode[nodeCount].AttachObject(exteriorTile[outEndTileCount]);
                            outEndTileCount++;
                        }
                        else
                            tileNode[nodeCount].AttachObject(tile[endTileCount]);
                        endTileCount++;
                        // yaw
                        if ((e.Source.Width < v.Width) || (e.Target.Width < v.Width))
                        {
                            tileNode[nodeCount].Yaw(90);
                        }
                        else if ((e.Source.Width > v.Width) || (e.Target.Width > v.Width))
                        {
                            tileNode[nodeCount].Yaw(270);
                        }
                        else if ((e.Source.Length < v.Length) || (e.Target.Length < v.Length))
                        {
                            tileNode[nodeCount].Yaw(0);
                        }
                        else if ((e.Source.Length > v.Length) || (e.Target.Length > v.Length))
                        {
                            tileNode[nodeCount].Yaw(180);
                        }
                    }
                    // HALL 
                    if (ec.Count == 2)
                    { // set 2nd edge to compare both edges for: Hall or Corner
                        if (passes == 0)
                        { // record 2nd edge for next pass
                            this.sew2 = e.Source.Width;
                            this.sel2 = e.Source.Length;
                            this.tew2 = e.Target.Width;
                            this.tel2 = e.Target.Length;
                            passes = 1;
                        }
                        else if ((((e.Source.Width != v.Width) | (e.Target.Width != v.Width)) & ((sew2 != v.Width) | (tew2 != v.Width)))
                          | (((e.Source.Length != v.Length) | (e.Target.Length != v.Length)) & ((sel2 != v.Length) | (tel2 != v.Length))))
                        {
                            tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            tileNode[nodeCount].ResetToInitialState();
                            tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NearbyVerticesEmpty(v) == "empty_corner")
                            {
                                tileNode[nodeCount].AttachObject(exteriorTile[outHallTileCount]);
                                outHallTileCount++;
                            }
                            else
                                tileNode[nodeCount].AttachObject(tile[hallTileCount]);
                            hallTileCount++;
                            // yaw 
                            if ((sew2 != v.Width) | (tew2 != v.Width))
                                tileNode[nodeCount].Yaw(90);
                        }
                        else
                        { // CORNER
                            tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            tileNode[nodeCount].ResetToInitialState();
                            tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NearbyVerticesEmpty(v) == "empty_corner")
                            {
                                tileNode[nodeCount].AttachObject(exteriorTile[outCornerTileCount]);
                                outCornerTileCount++;
                            }
                            else
                                tileNode[nodeCount].AttachObject(tile[cornerTileCount]);
                            cornerTileCount++;
                            // yaw 
                            if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                            || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                tileNode[nodeCount].Yaw(0);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                tileNode[nodeCount].Yaw(180);
                            }
                            else if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                tileNode[nodeCount].Yaw(270);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                          || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                tileNode[nodeCount].Yaw(90);
                            }
                        }
                    }
                    // SIDE
                    if (ec.Count == 3) // 3 edges to calculate side tile
                    {
                        if (passes == 0)
                        { // record 2nd edge
                            this.sew2 = e.Source.Width;
                            this.sel2 = e.Source.Length;
                            this.tew2 = e.Target.Width;
                            this.tel2 = e.Target.Length;
                            passes = 1;
                        }
                        else if (passes == 1)
                        { // record 3rd edge  
                            this.sew3 = e.Source.Width;
                            this.sel3 = e.Source.Length;
                            this.tew3 = e.Target.Width;
                            this.tel3 = e.Target.Length;
                            passes = 2;
                        }
                        else
                        {
                            tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            tileNode[nodeCount].ResetToInitialState();
                            tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NearbyVerticesEmpty(v) == "empty_corner")
                            {
                                tileNode[nodeCount].AttachObject(exteriorTile[outSideTileCount]);
                                outSideTileCount++;
                            }
                            else
                                tileNode[nodeCount].AttachObject(tile[sideTileCount]);
                            sideTileCount++;
                            // yaw 
                            if (!(e.Source.Length < v.Length) & !(e.Target.Length < v.Length) & !(sel2 < v.Length) & !(tel2 < v.Length) & !(sel3 < v.Length) & !(tel3 < v.Length))
                            {
                                tileNode[nodeCount].Yaw(180);
                            }
                            else if (!(e.Source.Length > v.Length) & !(e.Target.Length > v.Length) & !(sel2 > v.Length) & !(tel2 > v.Length) & !(sel3 > v.Length) & !(tel3 > v.Length))
                            {
                                tileNode[nodeCount].Yaw(0);
                            }
                            else if (!(e.Source.Width < v.Width) & !(e.Target.Width < v.Width) & !(sew2 < v.Width) & !(tew2 < v.Width) & !(sew3 < v.Width) & !(tew3 < v.Width))
                            {
                                tileNode[nodeCount].Yaw(270);
                            }
                            else if (!(e.Source.Width > v.Width) & !(e.Target.Width > v.Width) & !(sew2 > v.Width) & !(tew2 > v.Width) & !(sew3 > v.Width) & !(tew3 > v.Width))
                            {
                                tileNode[nodeCount].Yaw(90);
                            }
                        }
                    }
                    // FLOOR
                    if ((ec.Count == 4) & (passes == 0)) // 4 on the floor :)
                    {
                        tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                        tileNode[nodeCount].ResetToInitialState();
                        tileNode[nodeCount].Position = new Vector3(x, 0, z);
                        if (this.sm.NearbyVerticesEmpty(v) == "empty_corner")
                        {
                            tileNode[nodeCount].AttachObject(exteriorTile[outFloorTileCount]);
                            outFloorTileCount++;
                        }
                        else
                            tileNode[nodeCount].AttachObject(tile[floorTileCount]);
                        passes = 1;
                        floorTileCount++;
                    } /*Debug:*/  //Console.WriteLine("Vertex: {0} -- Edges Source: {1} Target: {2}", v, e.Source, e.Target); Console.WriteLine("{0} {1}", v, ec.Count);        
                }
                if (tileNode[nodeCount] != null)
                    this.moduleNode[moduleCount].AddChild(tileNode[nodeCount]);
                nodeCount++;
            }
        }

        /// <summary>
        /// Print Map of tileSets 
        /// </summary>
        /// <param name="tile">An array of tile entites to create</param>
        /// <param name="recreate">Recreate the map or it creates a new one</param>
        /// <param name="skew">Skewing of tile quadrant dispersion</param>
        /// <param name="xPosition">Where to place the map in the scene X</param>
        /// <param name="yPosition">Where to place the map in the scene Y</param>
        /// <param name="zPosition">Where to place the map in the scene Z</param>
        public void CreateMap(/*int skew,*/ float xPosition, float yPosition, float zPosition)
        {
            float x = 0, /*y = 0,*/ z = 0;
            int passes = 0;
            moduleCount = 0;

            // create modules per Tileset
            this.mapNode[mapCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Map " + mapCount);

            // MAKE TILES - transfer graph to Axiom
            // do vertices
            foreach (Point<int> v in sm.md2.Keys) // taken from mazed MultiDictionary+
            {
                passes = 0; // must complete edge amount to create tileNode
                // get the initial vertex size of world map.
                x = (v.Width * MeshSize) + xPosition;
                z = (v.Length * MeshSize) + zPosition;

                // find current edge values. Verteces remain the same
                Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>> ec =
                    (Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>>)sm.md2[v];
                // do edges 
                foreach (Edge<Point<int>> e in ec) // edges per vertex, 1-4
                {
                    // END
                    if (ec.Count == 1) // one edge for End tile`
                    {
                        quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);
                        //quadrantNode[quadrantCount].ResetToInitialState(); // set mesh North as created in modeler
                        quadrantNode[quadrantCount].Position = new Vector3(x, 0, z);

                        quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                        moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                        moduleCount++;
                        quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                        moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                        moduleCount++;
                        quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                        moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                        moduleCount++;
                        // yaw
                        if ((e.Source.Width < v.Width) || (e.Target.Width < v.Width))
                        {
                            quadrantNode[quadrantCount].Yaw(90);
                        }
                        else if ((e.Source.Width > v.Width) || (e.Target.Width > v.Width))
                        {
                            quadrantNode[quadrantCount].Yaw(270);
                        }
                        else if ((e.Source.Length < v.Length) || (e.Target.Length < v.Length))
                        {
                            quadrantNode[quadrantCount].Yaw(0);
                        }
                        else if ((e.Source.Length > v.Length) || (e.Target.Length > v.Length))
                        {
                            quadrantNode[quadrantCount].Yaw(180);
                        }
                    }
                    // HALL 
                    if (ec.Count == 2)
                    { // set 2nd edge to compare both edges for: Hall or Corner
                        if (passes == 0)
                        { // record 2nd edge for next pass
                            this.sew2 = e.Source.Width;
                            this.sel2 = e.Source.Length;
                            this.tew2 = e.Target.Width;
                            this.tel2 = e.Target.Length;
                            passes = 1;
                        }
                        else if ((((e.Source.Width != v.Width) | (e.Target.Width != v.Width)) & ((sew2 != v.Width) | (tew2 != v.Width)))
                          | (((e.Source.Length != v.Length) | (e.Target.Length != v.Length)) & ((sel2 != v.Length) | (tel2 != v.Length))))
                        {
                            quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);
                            //quadrantNode[quadrantCount].ResetToInitialState();
                            quadrantNode[quadrantCount].Position = new Vector3(x, 0, z);
                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                quadrantNode[quadrantCount].AttachObject(exteriorTile[outHallTileCount]);
                                outHallTileCount++; 
                            }  
                            else*/
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            // yaw 
                            if ((sew2 != v.Width) | (tew2 != v.Width))
                                quadrantNode[quadrantCount].Yaw(90);
                        }
                        else
                        { // CORNER
                            quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);
                            //quadrantNode[quadrantCount].ResetToInitialState();                            
                            quadrantNode[quadrantCount].Position = new Vector3(x, 0, z);
                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                quadrantNode[quadrantCount].AttachObject(exteriorTile[outCornerTileCount]);
                                outCornerTileCount++; 
                            }
                            else*/
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            // yaw 
                            if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                            || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                quadrantNode[quadrantCount].Yaw(0);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                quadrantNode[quadrantCount].Yaw(180);
                            }
                            else if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                quadrantNode[quadrantCount].Yaw(270);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                          || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                quadrantNode[quadrantCount].Yaw(90);
                            }
                        }
                    }
                    // SIDE
                    if (ec.Count == 3) // 3 edges to calculate side tile
                    {
                        if (passes == 0)
                        { // record 2nd edge
                            this.sew2 = e.Source.Width;
                            this.sel2 = e.Source.Length;
                            this.tew2 = e.Target.Width;
                            this.tel2 = e.Target.Length;
                            passes = 1;
                        }
                        else if (passes == 1)
                        { // record 3rd edge  
                            this.sew3 = e.Source.Width;
                            this.sel3 = e.Source.Length;
                            this.tew3 = e.Target.Width;
                            this.tel3 = e.Target.Length;
                            passes = 2;
                        }
                        else
                        {
                            quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);
                            //quadrantNode[quadrantCount].ResetToInitialState();
                            quadrantNode[quadrantCount].Position = new Vector3(x, 0, z);
                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                quadrantNode[quadrantCount].AttachObject(exteriorTile[outSideTileCount]);
                                outSideTileCount++; 
                            }
                            else*/
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                            moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                            moduleCount++;
                            // yaw 
                            if (!(e.Source.Length < v.Length) & !(e.Target.Length < v.Length) & !(sel2 < v.Length) & !(tel2 < v.Length) & !(sel3 < v.Length) & !(tel3 < v.Length))
                            {
                                quadrantNode[quadrantCount].Yaw(180);
                            }
                            else if (!(e.Source.Length > v.Length) & !(e.Target.Length > v.Length) & !(sel2 > v.Length) & !(tel2 > v.Length) & !(sel3 > v.Length) & !(tel3 > v.Length))
                            {
                                quadrantNode[quadrantCount].Yaw(0);
                            }
                            else if (!(e.Source.Width < v.Width) & !(e.Target.Width < v.Width) & !(sew2 < v.Width) & !(tew2 < v.Width) & !(sew3 < v.Width) & !(tew3 < v.Width))
                            {
                                quadrantNode[quadrantCount].Yaw(270);
                            }
                            else if (!(e.Source.Width > v.Width) & !(e.Target.Width > v.Width) & !(sew2 > v.Width) & !(tew2 > v.Width) & !(sew3 > v.Width) & !(tew3 > v.Width))
                            {
                                quadrantNode[quadrantCount].Yaw(90);
                            }
                        }
                    }
                    // FLOOR
                    if ((ec.Count == 4) & (passes == 0)) // 4 on the floor :)
                    {
                        quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);
                        //quadrantNode[quadrantCount].ResetToInitialState();
                        quadrantNode[quadrantCount].Position = new Vector3(x, 0, z);
                        /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                            quadrantNode[quadrantCount].AttachObject(exteriorTile[outFloorTileCount]);
                            outFloorTileCount++;
                        } 
                        else*/
                        quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                        moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                        moduleCount++;
                        quadrantNode[quadrantCount].AddChild(moduleNode[moduleCount]);
                        moduleNode[moduleCount].Position = quadrantNode[quadrantCount].Position;
                        moduleCount++;
                        passes = 1;
                    } /*Debug:*/  //Console.WriteLine("Vertex: {0} -- Edges Source: {1} Target: {2}", v, e.Source, e.Target); Console.WriteLine("{0} {1}", v, ec.Count);        
                } // add your created quadrant to the map 
                if (quadrantNode[quadrantCount] != null)
                    this.mapNode[mapCount].AddChild(quadrantNode[quadrantCount]);
                quadrantCount++;
            }
        }

        #endregion TileSet

        protected virtual void GenerateTiles()
        {
            //this.nextPathnode = 0;

            // reset map variables 
            this.mapSizeEast = MeshSize * tileAmountEast;
            this.mapSizeNorth = MeshSize * tileAmountNorth;

            for (; newModuleCount < moduleCount; newModuleCount++)
            {
                if (moduleNode[newModuleCount].ChildCount == 0)
                {
                    continue;
                }

                SceneManager.DestroySceneNode(moduleNode[newModuleCount].Name);
                Console.WriteLine("Destroyed Module Node {0}" + moduleNode[newModuleCount].Name);
            }
            GC.Collect();

            // reset variables 
            sideTileCount = 1000; hallTileCount = 5000; cornerTileCount = 9000; endTileCount = 13000; floorTileCount = 17000;
            outSideTileCount = 500; outHallTileCount = 2500; outCornerTileCount = 4500; outEndTileCount = 6500; outFloorTileCount = 8500;
            // refresh terrain
            //SceneManager.ResetTerrain();
            CreateObjects(tileSetDispersion, tileAmountNorth, tileAmountEast, tilesetNorth, tilesetEast);

            // needs to stop frame animation to build tiles properly
            //Window.DebugText = string.Format("Press E to enter Edit Mode");
            Root.FrameStarted += OnFrameStarted;
            Root.FrameEnded += OnFrameEnded;
            Root.FrameStarted += UpdateInput;
            Window.IsActive = true;
        }

        protected virtual void ExitEditor()
        {
            //Window.DebugText = string.Format("Press E to enter Edit Mode");
            Root.FrameStarted += UpdateInput;
            Root.FrameStarted += OnFrameStarted;
            Root.FrameEnded += OnFrameEnded;
            Window.IsActive = true;
        }

        protected bool nextLocation()
        {
            if (this.sm.path_module.Count == 0)
                return false;
            else
                return true;
        }

        #region Frame Animation

        protected override void OnFrameStarted(object source, FrameEventArgs e)
        {
            //timeSinceLastFrame = e.TimeSinceLastFrame;
            base.OnFrameStarted(source, e);
            #region Camera Clipping Events and CREATING PATHS
            /*
                // ZONE SYSTEM (dependant on pure engine coordinates)
                //////////////////////////////////////

             * if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[0].WorldAABB)) & (camClipped != 1))
                { 
                    // turn off camClip until another is triggered because of timer
                    camClipped = 1;
                    Window.DebugText = string.Format("Zone: 1");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x - mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10); // wont need to do this every time
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x - mapSize*2, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[1].WorldAABB)) & (camClipped != 2))
                {
                    camClipped = 2;
                    Window.DebugText = string.Format("Zone: 2");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z > tileNode[0].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[2].WorldAABB)) & (camClipped != 3))
                {
                    camClipped = 3;
                    Window.DebugText = string.Format("Zone: 3");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x + mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[3].WorldAABB)) & (camClipped != 4))
                {
                    camClipped = 4;
                    Window.DebugText = string.Format("Zone: 4");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z != tileNode[0].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[4].WorldAABB)) & (camClipped != 5))
                {
                    camClipped = 5;
                    Window.DebugText = string.Format("Zone: 5");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[2700].Position.z > tileNode[900].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[900].Position.x, 0, tileNode[900].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[5].WorldAABB)) & (camClipped != 6))
                {
                    camClipped = 6;
                    Window.DebugText = string.Format("Zone: 6");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x + mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[900].Position.x + mapSize, 0, tileNode[900].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[6].WorldAABB)) & (camClipped != 7))
                {
                    camClipped = 7;
                    Window.DebugText = string.Format("Zone: 7");
                    if ((tileNode[900].Position.z != tileNode[0].Position.z) | (tileNode[900].Position.x > tileNode[0].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[0].Position.x - mapSize*2, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[7].WorldAABB)) & (camClipped != 8)) {
                    camClipped = 8;
                    Window.DebugText = string.Format("Zone: 8 :: A-MAZE-ZING! Don't get lost");
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[8].WorldAABB)) & (camClipped != 9))
                {
                    camClipped = 9;
                    Window.DebugText = string.Format("Zone: 9");
                    if ((tileNode[900].Position.z != tileNode[0].Position.z) | (tileNode[900].Position.x < tileNode[0].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[9].WorldAABB)) & (camClipped != 10))
                {
                    camClipped = 10;
                    Window.DebugText = string.Format("Zone: 10");
                    if ((tileNode[0].Position.z != tileNode[900].Position.z) | (tileNode[0].Position.x > tileNode[900].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[900].Position.x - mapSize, 0, tileNode[900].Position.z);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[10].WorldAABB)) & (camClipped != 11))
                {
                    camClipped = 11;
                    Window.DebugText = string.Format("Zone: 11 :: A-MAZE-ZING!");
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[11].WorldAABB)) & (camClipped != 12))
                {
                    camClipped = 12;
                    Window.DebugText = string.Format("Zone: 12");
                    if ((tileNode[0].Position.z != tileNode[0].Position.z) | (tileNode[0].Position.x < tileNode[900].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[900].Position.x + mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[12].WorldAABB)) & (camClipped != 13))
                {
                    camClipped = 13;
                    Window.DebugText = string.Format("Zone: 13");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x - mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z + mapSize))
                        {
                            this.sm.GeneratePath(10, 10);
                            this.sm.SearchPath();
                            RemoveTileset(4);
                            CreateTileset(4, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z + mapSize);
                            d4d.zoneGroup[3].Position =  new Vector3(d4d.zoneGroup[0].Position.x - mapSize*2, 0, d4d.zoneGroup[0].Position.z);
                        }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[13].WorldAABB)) & (camClipped != 14))
                {
                    camClipped = 14;
                    Window.DebugText = string.Format("Zone: 14");
                    if ((tileNode[0].Position.x != tileNode[1800].Position.x) | (tileNode[0].Position.z > tileNode[1800].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[14].WorldAABB)) & (camClipped != 15))
                {
                    camClipped = 15;
                    Window.DebugText = string.Format("Zone: 15");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x + mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z + mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[15].WorldAABB)) & (camClipped != 16))
                {
                    camClipped = 16;
                    Window.DebugText = string.Format("Zone: 16");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x - mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[900].Position.x - mapSize, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[16].WorldAABB)) & (camClipped != 17)) 
                {
                    camClipped = 17;
                    Window.DebugText = string.Format("Zone: 17");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[2700].Position.z < tileNode[900].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[900].Position.x, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[17].WorldAABB)) & (camClipped != 18))
                {
                    camClipped = 18;
                    Window.DebugText = string.Format("Zone: 18");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x + mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[900].Position.x + mapSize, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[18].WorldAABB)) & (camClipped != 19))
                {
                    camClipped = 19;
                    Window.DebugText = string.Format("Zone: 19");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x - mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[1800].Position.x - mapSize, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x - mapSize*2, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[19].WorldAABB)) & (camClipped != 20))
                {
                    camClipped = 20;
                    Window.DebugText = string.Format("Zone: 20");
                    if ((tileNode[0].Position.x != tileNode[1800].Position.x) | (tileNode[0].Position.z > tileNode[1800].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[1800].Position.x, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[20].WorldAABB)) & (camClipped != 21))
                {
                    camClipped = 21;
                    Window.DebugText = string.Format("Zone: 21");   
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x + mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[21].WorldAABB)) & camClipped != 22) {
                    camClipped = 22;
                    Window.DebugText = string.Format("Zone: 22");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x - mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[22].WorldAABB)) & (camClipped != 23))
                {
                    camClipped = 23;
                    Window.DebugText = string.Format("Zone: 23");
                    if ((tileNode[900].Position.x != tileNode[2700].Position.x) | (tileNode[900].Position.z > tileNode[2700].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[2700].Position.x, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[23].WorldAABB)) & (camClipped != 24))
                {
                    camClipped = 24;
                    Window.DebugText = string.Format("Zone: 24");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x + mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[24].WorldAABB)) & (camClipped != 25))
                {
                    camClipped = 25;
                    Window.DebugText = string.Format("Zone: 25");
                    if ((tileNode[2700].Position.z != tileNode[1800].Position.z) | (tileNode[2700].Position.x > tileNode[1800].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[1800].Position.x - mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[2].Position.x - mapSize*2, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[25].WorldAABB)) & (camClipped != 26))
                {
                    camClipped = 26;
                    Window.DebugText = string.Format("Zone: 26 :: A-MAZING-ING!");
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[26].WorldAABB)) & (camClipped != 27))
                {
                    camClipped = 27;
                    Window.DebugText = string.Format("Zone: 27");
                    if ((tileNode[2700].Position.z != tileNode[1800].Position.z) | (tileNode[2700].Position.x < tileNode[1800].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(4);
                        CreateTileset(4, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[27].WorldAABB)) & (camClipped != 28))
                {
                    camClipped = 28;
                    Window.DebugText = string.Format("Zone: 28");
                    if ((tileNode[1800].Position.z != tileNode[2700].Position.z) | (tileNode[1800].Position.x > tileNode[2700].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[28].WorldAABB)) & (camClipped != 29))
                {
                    camClipped = 29;
                    Window.DebugText = string.Format("Zone: 29 :: A-MAZING-ING!");
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[29].WorldAABB)) & (camClipped != 30))
                {
                    camClipped = 30;
                    Window.DebugText = string.Format("Zone: 30");
                    if ((tileNode[1800].Position.z != tileNode[2700].Position.z) | (tileNode[1800].Position.x < tileNode[2700].Position.x))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(3);
                        CreateTileset(3, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[30].WorldAABB)) & (camClipped != 31))
                {
                    camClipped = 31;
                    Window.DebugText = string.Format("Zone: 31");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x - mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[1800].Position.x - mapSize, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x - mapSize*2, 0, d4d.zoneGroup[2].Position.z + mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[31].WorldAABB)) & (camClipped != 32))
                {
                    camClipped = 32;
                    Window.DebugText = string.Format("Zone: 32");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z > tileNode[0].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[1800].Position.x, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[32].WorldAABB)) & (camClipped != 33))
                {
                    camClipped = 33;
                    Window.DebugText = string.Format("Zone: 33");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x + mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[33].WorldAABB)) & (camClipped != 34))
                {
                    camClipped = 34;
                    Window.DebugText = string.Format("Zone: 34");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x - mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[34].WorldAABB)) & (camClipped != 35))
                {
                    camClipped = 35;
                    Window.DebugText = string.Format("Zone: 35");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[900].Position.z < tileNode[2700].Position.z))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(2);
                        CreateTileset(2, true, tileNode[2700].Position.x, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[35].WorldAABB)) & (camClipped != 36))
                {
                    camClipped = 36;
                    Window.DebugText = string.Format("Zone: 36");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x + mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z + mapSize))
                    {
                        this.sm.GeneratePath(10, 10);
                        this.sm.SearchPath();
                        RemoveTileset(1);
                        CreateTileset(1, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                }
                */

            //objectsVisible = 0;
            // make < number the amount of meshes in scene using variables. 
            /*for (int i = 0; i < 10000; i++) 
            {
               
               // tileNode[i].DetachAllObjects();
                if (Frustum.IsObjectVisible(interiorTile[i].GetWorldBoundingBox()))
                {
                    //SceneNode nd = (SceneNode)interiorTile[i].ParentNode;
                    //nd.DetachAllObjects();                  
                    interiorTile[i].IsVisible = true;       
                    //objectsVisible++;
                }
                else if (interiorTile[i].IsAttached) // make sure entity is attached before attempting to use it
                {
                    //Node nd = interiorTile[i].ParentNode;
                    //nd.RemoveAllChildren();
                    interiorTile[i].IsVisible = false;
                }
            } */
            // report the number of objects within the frustum 
            //Window.DebugText = string.Format("Objects visible: {0}", objectsVisible);

            #endregion Camera Clipping Events

            #region OBJECT ANIMATION

            ////// MODEL ANIMATIONS //////
            //modelAnimationState.AddTime(timeSinceLastFrame);
            /*float move = 0.0f;
 
            if (!isModelWalking)
            //either we've not started walking or reached a way point
            {
                //check if there are places to go
               if (nextLocation())
               {
                    // start the walk animation
                    //modelAnimationState = d4d.model[0].GetAnimationState("Walk");
                    //modelAnimationState.Loop = true;
                    //modelAnimationState.IsEnabled = true;
                    isModelWalking = true;

                    //nextWaypoint.x = sm.path_module[0].Width; 
                    //nextWaypoint.z = sm.path_module[0].Length;

                    if (nextPathnode < sm.path_module.Count)
                    { 
                        // add Vector3 later to simplify
                        nextWaypoint.x = sm.path_module[nextPathnode].Width;
                        nextWaypoint.z = sm.path_module[nextPathnode].Length; 
                        nextWaypoint.y = sm.path_module[nextPathnode].Height + 75;                                                  
                    } else if (nextPathnode == sm.path_module.Count)
                    {
                        nextPathnode = 0;
                    }

                    nextPathnode++;
                    Console.WriteLine("Pathnode: {0}", nextPathnode);             

                    // update the direction and the distance
                    directionOfTravel = nextWaypoint - d4d.modelNode[0].DerivedPosition;
                    Console.WriteLine("Next Waypoint: {0} - {1}", nextWaypoint, d4d.modelNode[0].DerivedPosition);
                    distanceToNextWaypoint = directionOfTravel.Normalize();
                }
                //else // nowhere to go. set to idle animation
                //{   //if nodeCount more loactions just keep going
                    // modelAnimationState = d4d.model[0].GetAnimationState("Idle");
                    // robotAnimationState = _robotEnt.GetAnimationState("Die");
                    // robotAnimationState.Loop = false;
                //}
            } else // if isModelWalking, determine how far to move this frame
            {
                move = modelWalkSpeed * timeSinceLastFrame;
                distanceToNextWaypoint -= move;                                 
            }
            // you have reached a pathnode
            if (distanceToNextWaypoint <= 0) // stop model and set isModelWalking to false 
            {      // Console.WriteLine("Stopped");
                // set our node to the destination we've just reached & reset direction to 0
                d4d.modelNode[0].Position = nextWaypoint;
                directionOfTravel = Vector3.Zero;
                isModelWalking = false;
            } else // move the model
            {
                // Console.WriteLine("Moving");
                // movement code goes here
                //directionOfTravel = nextWaypoint - d4d.modelNode[0].DerivedPosition;
                d4d.modelNode[0].Translate(directionOfTravel * move);

                // rotation code goes here
                Vector3 src = d4d.modelNode[0].Orientation * Vector3.UnitX;
                Quaternion quat = src.GetRotationTo(directionOfTravel);
                d4d.modelNode[0].Rotate(quat);

            }*/

            #endregion ANIMATION
        }

        #endregion
    }
}

/*
 * Code by Mark V Madsen
 * License BSD
 * Starport Media llc
*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using QuickGraph;
using Axiom.Animating;
using Axiom.Core;
using Axiom.Core.InstanceGeometry;
using Axiom.Math;
using Axiom.Graphics;
using Axiom.Configuration;
using Axiom.ParticleSystems;

namespace SmartMap
{
    /// <summary>
    /// Creates the 3D objects for the 3D graphics renderer
    /// </summary>
    [System.ComponentModel.DesignerCategory("")]
    public class Draw3D : EngineSetup, IDraw, IDisposable
    {
        #region objects
        // Map
        SmartMap_Core sm;
        private Draw4D d4d;
        public Dictionary<int, Entity> interiorTileSide;
        public Dictionary<int, Entity> exteriorTileHall;
        public Dictionary<int, Entity> interiorTileCorner;
        public Dictionary<int, Entity> exteriorTileEnd;
        public Dictionary<int, Entity> interiorTileFloor;
        public Dictionary<int, Entity> exteriorTileSide;
        public Dictionary<int, Entity> interiorTileHall;
        public Dictionary<int, Entity> exteriorTileCorner;
        public Dictionary<int, Entity> interiorTileEnd;
        public Dictionary<int, Entity> exteriorTileFloor;
        public SceneNode[] mapNode;
        public SceneNode[] quadrantNode;
        public SceneNode[] moduleNode;
        public SceneNode[] tileNode;
        private int meshCount = 0, textureCount = 0;
        private int nodeCount = 0;
        private int mapCount = 0;
        private int newModuleCount = 0;//, newQuadrantCount = 0, newMapCount = 0;
        //private int nextPathnode = 0;
        // Sizeing and quantity of structures.
        public int tileAmountNorth = 5, tileAmountEast = 5;
        public int moduleAmountSouth = 2, moduleAmountEast = 2;
        //////////
        private int /*tileThreshhold = 80,*/ tileClippingAngle = 300;
        private float moduleSizeNorth = 0, moduleSizeEast = 0, tileSetHeight = 150;
        private int sideTileCount = 0, hallTileCount = 0, cornerTileCount = 0, endTileCount = 0, floorTileCount = 0;
        private int outSideTileCount = 0, outHallTileCount = 0, outCornerTileCount = 0, outEndTileCount = 0, outFloorTileCount = 0;
        // Edges
        private float sew2, sew3, sel2, sel3, tew2, tew3, tel2, tel3; // 2nd and 3rd source edge and target edge
        // Graphics
        public static float MeshSize = 276.75f;
        //public static float MeshSize = 27.75f;
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
        private HardwareOcclusionQuery query;
        public int camClipped = 0;
        private int objectsVisible = 0;
        // Mesh Optimization
        /*private static readonly int maxObjectsPerBatch = 80;
        private double mAvgFrameTime;
        private int mSelectedMesh;
        private int mNumMeshes;
        private int objectCount;
        private string mDebugText;
        private int mNumRendered;
        private List<InstancedGeometry> renderInstance;
        private List<StaticGeometry> renderStatic;
        private List<Entity> renderEntity;
        private List<SceneNode> nodes;
        private List<List<Vector3>> posMatrices;*/
        // Debug
        public bool DebugStatements = true;
        private string assertMessage;
        #endregion

        public Draw3D()
        {
            this.sm = new SmartMap_Core();

            this.interiorTileSide = new Dictionary<int, Entity>(300000); // an Interior style tile will have indoor textures
            this.exteriorTileHall = new Dictionary<int, Entity>(300000); // an Exterior style tile will have outdoor textures
            this.interiorTileCorner = new Dictionary<int, Entity>(300000); // an Interior style tile will have indoor textures
            this.exteriorTileEnd = new Dictionary<int, Entity>(300000); // an Exterior style tile will have outdoor textures
            this.interiorTileFloor = new Dictionary<int, Entity>(300000); // an Interior style tile will have indoor textures
            this.exteriorTileSide = new Dictionary<int, Entity>(300000); // an Exterior style tile will have outdoor textures
            this.interiorTileHall = new Dictionary<int, Entity>(300000); // an Interior style tile will have indoor textures
            this.exteriorTileCorner = new Dictionary<int, Entity>(300000); // an Exterior style tile will have outdoor textures
            this.interiorTileEnd = new Dictionary<int, Entity>(300000); // an Interior style tile will have indoor textures
            this.exteriorTileFloor = new Dictionary<int, Entity>(300000); // an Exterior style tile will have outdoor textures
            this.mapNode = new SceneNode[100]; // a map is an overall region of the world encapsulating Quadrants, Modules and Tiles
            this.quadrantNode = new SceneNode[1000]; // a Quadrant is a large section of modules in a Map
            this.moduleNode = new SceneNode[300000]; // a Module is a Tileset represeting a myriad of interchangeable tiles
            this.tileNode = new SceneNode[300000]; // a tile is a singular interchangeable puzzle-piece within a Tileset Module 

            this.moduleSizeEast = MeshSize * tileAmountEast; // size map east
            this.moduleSizeNorth = MeshSize * tileAmountNorth; // size of map north
        }

        #region Properties

        #endregion

        #region Create Scene

        protected override void CreateScene()
        {
            CreateEnvironment();

            // LOAD UP YER MESHES           
            /*Console.WriteLine("LOADING...interiorTileSide");
            CreateGraphics(interiorTileSide, "Room_Side", "Room_Side.mesh", "TileSet/Room", 1500, 1500, RenderQueueGroupID.One);
            Console.WriteLine("LOADING...interiorTileHall");
            CreateGraphics(interiorTileHall, "Room_Hall", "Room_Hall.mesh", "TileSet/Room", 1500, 1500, RenderQueueGroupID.Two);
            Console.WriteLine("LOADING...interiorTileCorner");
            CreateGraphics(interiorTileCorner, "Room_Corner", "Room_Corner.mesh", "TileSet/Room", 1500, 1500, RenderQueueGroupID.Three);
            Console.WriteLine("LOADING...interiorTileEnd");
            CreateGraphics(interiorTileEnd, "Room_End", "Room_End.mesh", "TileSet/Room", 1500, 1500, RenderQueueGroupID.Four);
            Console.WriteLine("LOADING...interiorTileFloor");
            CreateGraphics(interiorTileFloor, "Room_Floor", "Room_Floor.mesh", "TileSet/Room", 1500, 1500, RenderQueueGroupID.Six);
            // outer wall resources
            Console.WriteLine("LOADING...exteriorTileSide");
            CreateGraphics(exteriorTileSide, "Wall_Side", "Room_Side.mesh", "TileSet/Wall", 1500, 1500, RenderQueueGroupID.Seven);
            Console.WriteLine("LOADING...exteriorTileHall");
            CreateGraphics(exteriorTileHall, "Wall_Hall", "Room_Hall.mesh", "TileSet/Wall", 1500, 1500, RenderQueueGroupID.Eight);
            Console.WriteLine("LOADING...exteriorTileCorner");
            CreateGraphics(exteriorTileCorner, "Wall_Corner", "Room_Corner.mesh", "TileSet/Wall", 1500, 1500, RenderQueueGroupID.Nine);
            Console.WriteLine("LOADING...exteriorTileEnd");
            CreateGraphics(exteriorTileEnd, "Wall_End", "Room_End.mesh", "TileSet/Wall", 1500, 1500, RenderQueueGroupID.Nine);
            Console.WriteLine("LOADING...exteriorTileFloor");
            CreateGraphics(exteriorTileFloor, "Wall_Floor", "Room_Floor.mesh", "TileSet/Wall", 1500, 1500, RenderQueueGroupID.Nine);*/

            // LOAD UP YER MESHES           
            CreateGraphics(interiorTileSide, "Room_Side", "Room_Side.mesh", "TileSet/Room", 200, 200, RenderQueueGroupID.One);
            Console.WriteLine("LOADING...interiorTileHall");
            CreateGraphics(interiorTileHall, "Room_Hall", "Room_Hall.mesh", "TileSet/Room", 200, 200, RenderQueueGroupID.Two);
            Console.WriteLine("LOADING...interiorTileCorner");
            CreateGraphics(interiorTileCorner, "Room_Corner", "Room_Corner.mesh", "TileSet/Room", 200, 200, RenderQueueGroupID.Three);
            Console.WriteLine("LOADING...interiorTileEnd");
            CreateGraphics(interiorTileEnd, "Room_End", "Room_End.mesh", "TileSet/Room", 200, 200, RenderQueueGroupID.Four);
            Console.WriteLine("LOADING...interiorTileFloor");
            CreateGraphics(interiorTileFloor, "Room_Floor", "Room_Floor.mesh", "TileSet/Room", 200, 200, RenderQueueGroupID.Six);
            // outer wall resources
            Console.WriteLine("LOADING...exteriorTileSide");
            CreateGraphics(exteriorTileSide, "Wall_Side", "Room_Side.mesh", "TileSet/Wall", 200, 200, RenderQueueGroupID.Seven);
            Console.WriteLine("LOADING...exteriorTileHall");
            CreateGraphics(exteriorTileHall, "Wall_Hall", "Room_Hall.mesh", "TileSet/Wall", 200, 200, RenderQueueGroupID.Eight);
            Console.WriteLine("LOADING...exteriorTileCorner");
            CreateGraphics(exteriorTileCorner, "Wall_Corner", "Room_Corner.mesh", "TileSet/Wall", 200, 200, RenderQueueGroupID.Nine);
            Console.WriteLine("LOADING...exteriorTileEnd");
            CreateGraphics(exteriorTileEnd, "Wall_End", "Room_End.mesh", "TileSet/Wall", 200, 200, RenderQueueGroupID.Nine);
            Console.WriteLine("LOADING...exteriorTileFloor");
            CreateGraphics(exteriorTileFloor, "Wall_Floor", "Room_Floor.mesh", "TileSet/Wall", 200, 200, RenderQueueGroupID.Nine);
       
            
            
            //CreateInstanceGeom();

            CreateWorld(0, 0, 0, 0, 0);
            
            #region DEBUG
            // Debug.Assert(DebugStatements == true,"{0}, {1}", d4d.zoneGroup[0].Position, d4d.zoneGroup[2].Position);
            //Console.ReadLine();
            //Frustum.IsVisible = true;
            // show some Bounding Boxes as Zone corners
            /*tileNode[0].ShowBoundingBox = true;
            tileNode[9].ShowBoundingBox = true;
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
            // set up queue event handlers to run the query
            SceneManager.QueueStarted += scene_QueueStarted;
            SceneManager.QueueEnded += scene_QueueEnded;
          
            // set some ambient light
            SceneManager.AmbientLight = new ColorEx(1.0f, 0.4f, 0.4f, 0.4f);

            SceneManager.SetFog(FogMode.Linear, new ColorEx(0.8f, 0.8f, 0.8f), -7, 15000, 100000);

            // create a skydome
            SceneManager.SetSkyBox(true, "Skybox/CloudyHills", 8);

            // create a simple default point light
            Light light = SceneManager.CreateLight("MainLight");
            light.Position = new Vector3(20, 80, 50);

            // create Tarrain
            SceneManager.LoadWorldGeometry("Terrain.xml");

            MaterialManager.Instance.SetDefaultTextureFiltering(TexFilter);
            MaterialManager.Instance.DefaultAnisotropy = anisoNumber;
            
            // water plane setup
            Plane waterPlane = new Plane(Vector3.UnitY, 1.5f);

            MeshManager.Instance.CreatePlane("WaterPlane",
                                             ResourceGroupManager.DefaultResourceGroupName,
                                             waterPlane,
                                             256000, 256000, 20, 20, true, 1, 10, 10, Vector3.UnitZ);

            Entity waterEntity = SceneManager.CreateEntity("Water", "WaterPlane");
            waterEntity.MaterialName = "Terrain/WaterPlane";
            // do not frustum cull Water
            waterEntity.BoundingBox.IsInfinite = true;
            // do not frustum cull Water
            waterEntity.BoundingBox.IsNull = true;

            var waterNode = SceneManager.RootSceneNode.CreateChildSceneNode("WaterNode");
            waterNode.AttachObject(waterEntity);
            waterNode.Translate(new Vector3(-999, 10, -999));

            // =Draw 4D= - For dynamic objects in scene
            // TODO: set up clipping regions for 4 tileSets
            this.d4d = new Draw4D(base.SceneManager);
            this.d4d.idraw = this;
            // Model
            this.d4d.sinbad = new SinbadCharacterController(Camera);
            this.d4d.sinbad.cameraNode.AttachObject(m_frustum);
            // initial position
            this.d4d.sinbad.cameraNode.Position = new Vector3(128, 500, 128);
            //this.d4d.CreateModel();
            //this.d4d.modelNode[0].Position = new Vector3(0, tileSetHeight + 500, 0);
            // Animation
            // Object animation. Set idle animation
            //modelAnimationState = d4d.model[0].GetAnimationState("Idle");
            //modelAnimationState.Loop = true;
            //modelAnimationState.IsEnabled = true;

            // TODO: for the saving and loading of our level.
            // =Save/Load= from XML
            /* this.sm.Save();*/

            //frustumNode.Position = new Vector3(128, 500, 128);
            Camera.LookAt(new Vector3(0, 0, -300));

            // instance optimization
            //this.mNumMeshes = 160;
            //this.mNumRendered = 0;

            // occlusion query
            query = Root.Instance.RenderSystem.CreateHardwareOcclusionQuery();
    
            // particles smoke
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
        public void CreateGraphics(Dictionary<int, Entity> entityList, string tileName, string tileFileName, string materialName, int meshAmount, int textureAmount, RenderQueueGroupID rqid)
        {
            for (int i = meshCount; i < meshAmount; ++i)
            {
                entityList[i] = SceneManager.CreateEntity(tileName + i, tileFileName);
                entityList[i].RenderQueueGroup = rqid;
                //CreateInstanceGeom(entity[i]);
            }
            for (int i = textureCount; i < textureAmount; ++i)
            {
                entityList[i].MaterialName = materialName;
            }
            meshCount = 0;
            textureCount = 0;
        }

        #region INSTANCING

        /// <summary>
        /// Create Instanced mesh
        /// </summary>
        /// <param name="mesh">New mesh on the block</param>
        /*private void CreateInstanceGeom(Entity mesh)
        {
            this.renderInstance = new List<InstancedGeometry>(this.mNumRendered);

            //Load a mesh to read data from.	
            var batch = new InstancedGeometry(SceneManager, mesh.Name + "s")
            {
                CastShadows = true,
                Origin = Vector3.Zero,
                BatchInstanceDimensions = new Vector3(1000000f, 1000000f, 1000000f)
            };

            int batchSize = (this.mNumMeshes > maxObjectsPerBatch) ? maxObjectsPerBatch : this.mNumMeshes;
            SetupInstancedMaterialToEntity(mesh);
            for (int i = 0; i < batchSize; i++)
            {
                batch.AddEntity(mesh, Vector3.Zero);
            }

            batch.Build();


            int k;
            for (k = 0; k < this.mNumRendered - 1; k++)
            {
                batch.AddBatchInstance();
            }

            k = 0;
            foreach (var batchInstance in batch.BatchInstances)
            {
                int j = 0;
                foreach (var instancedObject in batchInstance.(???))
                {
                    instancedObject.Position = this.posMatrices[k][j];
                    ++j;
                }
                k++;
            }
            batch.IsVisible = true;
            this.renderInstance[0] = batch;

            SceneManager.RemoveEntity(mesh);
        }

        private void SetupInstancedMaterialToEntity(Entity ent)
        {
            for (int i = 0; i < ent.SubEntityCount; ++i)
            {
                SubEntity se = ent.GetSubEntity(i);
                string materialName = se.MaterialName;
                se.MaterialName = BuildInstancedMaterial(materialName);
            }
        }

        private string BuildInstancedMaterial(string originalMaterialName)
        {
            // already instanced ?
            if (originalMaterialName.EndsWith("/instanced"))
            {
                return originalMaterialName;
            }

            var originalMaterial = (Material)MaterialManager.Instance.GetByName(originalMaterialName);

            // if originalMat doesn't exists use "Instancing" material name
            string instancedMaterialName = (null == originalMaterial ? "Instancing" : originalMaterialName + "/Instanced");
            var instancedMaterial = (Material)MaterialManager.Instance.GetByName(instancedMaterialName);

            // already exists ?
            if (null == instancedMaterial)
            {
                instancedMaterial = originalMaterial.Clone(instancedMaterialName);
                instancedMaterial.Load();
                Technique t = instancedMaterial.GetBestTechnique();
                for (int pItr = 0; pItr < t.PassCount; pItr++)
                {
                    Pass p = t.GetPass(pItr);
                    p.SetVertexProgram("Instancing", false);
                    p.SetShadowCasterVertexProgram("InstancingShadowCaster");
                }
            }
            instancedMaterial.Load();
            return instancedMaterialName;
        }*/

        #endregion

        /// <summary>
        /// Create Quadrants for Maps
        /// </summary>
        /// </summary>
        /// <param name="quadrantDispersion">Distance of dispersed Tilesets</param>
        /// <param name="quadrantAmountNorth"></param>
        /// <param name="quadtrantAmountEast"></param>
        /// <param name="quadrantNorth"></param>
        /// <param name="quadrantEast"></param>
        public void CreateWorld(int quadrantDispersion, int quadrantAmountNorth, int quadtrantAmountEast, int quadrantNorth, int quadrantEast)
        {
            this.sm.GenerateGraph("QUADRANT", false, moduleAmountEast, moduleAmountSouth);
            this.sm.GeneratePath("QUADRANT", false, 0, 0); // generate maze with auto or manual path - has error handling   
            Debug.Assert(DebugStatements == true,"--------EXITING PATH GENERATION FOR QUADRANT--------");
            //Console.ReadLine();
            CreateMap(0, 10000, 0, 10000, 3);
            //frustumNode.Translate(moduleNode[0].Position);
            this.d4d.sinbad.cameraNode.Translate(moduleNode[0].Position);
        }

        #endregion Create Scene

        #region Map, Quadrants, Modules and Tiles

        /// <summary>
        /// Print a Map of Quadrants containing Modules
        /// </summary>
        /// <param name="quadrantCount"></param>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <param name="zPosition"></param>
        public void CreateMap(/*int skew,*/ int quadrantCount, float xPosition, float yPosition, float zPosition, int expandQuadrant)
        {
            float x = 0, /*y = 0,*/ z = 0;
            int passes = 0;
            int moduleCount = 0;

            //this.mapNode[mapCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Map " + mapCount);
            this.quadrantNode[quadrantCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Quadrant " + quadrantCount);

            // MAKE MODULES - transfer graph to Axiom
            // do vertices
            foreach (Point<int> v in sm.md2.Keys) // taken from mazed MultiDictionary
            {
                passes = 0; // must complete edge amount to create correct module
                // get the initial vertex location of world map plus any additional distance.
                x = ((v.Width * this.moduleSizeEast) * expandQuadrant)  + xPosition;
                z = ((v.Length * this.moduleSizeNorth) * expandQuadrant) + zPosition;

                // find current edge values. Verteces remain the same
                //Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>> ec =
                    //(Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>>)sm.md2[v];
                // do edges 
                foreach (Edge<Point<int>> e in sm.md2[v]) // edges per vertex, 1-4
                {
                    // END
                    if (sm.md2[v].Count == 1) // one edge for End tile
                    {

                        //this.moduleNode[moduleCount].ResetToInitialState(); // set module North as created in modeler
                        //this.moduleNode[moduleCount].Position = new Vector3(x, 0, z);
                        ManufactureModule(moduleCount, x, z);
                        //this.moduleNode[moduleCount].ResetOrientation();

                        // yaw
                        if ((e.Source.Width < v.Width) || (e.Target.Width < v.Width))
                        {
                            this.moduleNode[moduleCount].Yaw(90);
                        }
                        else if ((e.Source.Width > v.Width) || (e.Target.Width > v.Width))
                        {
                            this.moduleNode[moduleCount].Yaw(270);
                        }
                        else if ((e.Source.Length < v.Length) || (e.Target.Length < v.Length))
                        {
                            this.moduleNode[moduleCount].Yaw(0);
                        }
                        else if ((e.Source.Length > v.Length) || (e.Target.Length > v.Length))
                        {
                            this.moduleNode[moduleCount].Yaw(180);
                        }
                    }
                    // HALL 
                    if (sm.md2[v].Count == 2)
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
                            //this.moduleNode[moduleCount].Position = new Vector3(x, 0, z);
                            ManufactureModule(moduleCount, x, z);
                            //this.moduleNode[moduleCount].ResetOrientation(); // set module North as created in modeler
                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                quadrantNode[quadrantCount].AttachObject(exteriorTile[outHallTileCount]);
                                outHallTileCount++; 
                            }  
                            else*/
                            // yaw 
                            if ((sew2 != v.Width) | (tew2 != v.Width))
                                this.moduleNode[moduleCount].Yaw(90);
                        }
                        else
                        { // CORNER
                            //this.moduleNode[moduleCount].Position = new Vector3(x, 0, z);
                            ManufactureModule(moduleCount, x, z);
                            //this.moduleNode[moduleCount].ResetOrientation(); // set module North as created in modeler
                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                quadrantNode[quadrantCount].AttachObject(exteriorTile[outCornerTileCount]);
                                outCornerTileCount++; 
                            }
                            else*/
                            // yaw 
                            if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                            || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                this.moduleNode[moduleCount].Yaw(0);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                this.moduleNode[moduleCount].Yaw(180);
                            }
                            else if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                this.moduleNode[moduleCount].Yaw(270);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                          || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                this.moduleNode[moduleCount].Yaw(90);
                            }
                        }
                    }
                    // SIDE
                    if (sm.md2[v].Count == 3) // 3 edges to calculate side tile
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
                            //this.moduleNode[moduleCount].Position = new Vector3(x, 0, z);
                            ManufactureModule(moduleCount, x, z);
                            //this.moduleNode[moduleCount].ResetOrientation(); // set module North as created in modeler

                            /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                                outSideTileCount++; 
                            }
                            else*/
                            // yaw 
                            if (!(e.Source.Length < v.Length) & !(e.Target.Length < v.Length) & !(sel2 < v.Length) & !(tel2 < v.Length) & !(sel3 < v.Length) & !(tel3 < v.Length))
                            {
                                this.moduleNode[moduleCount].Yaw(180);
                            }
                            else if (!(e.Source.Length > v.Length) & !(e.Target.Length > v.Length) & !(sel2 > v.Length) & !(tel2 > v.Length) & !(sel3 > v.Length) & !(tel3 > v.Length))
                            {
                                this.moduleNode[moduleCount].Yaw(0);
                            }
                            else if (!(e.Source.Width < v.Width) & !(e.Target.Width < v.Width) & !(sew2 < v.Width) & !(tew2 < v.Width) & !(sew3 < v.Width) & !(tew3 < v.Width))
                            {
                                this.moduleNode[moduleCount].Yaw(270);
                            }
                            else if (!(e.Source.Width > v.Width) & !(e.Target.Width > v.Width) & !(sew2 > v.Width) & !(tew2 > v.Width) & !(sew3 > v.Width) & !(tew3 > v.Width))
                            {
                                this.moduleNode[moduleCount].Yaw(90);
                            }
                        }
                    }
                    // FLOOR
                    if ((sm.md2[v].Count == 4) & (passes == 0)) // 4 on the floor :)
                    {
                        ManufactureModule(moduleCount, x, z);
                        //moduleNode[moduleCount].ResetOrientation(); // set module North as created in modeler
                        //this.moduleNode[moduleCount].Position = new Vector3(x, 0, z);
                        /*if (this.sm.NearbyVerticesEmpty(v) == "empty_corner") {
                            quadrantNode[quadrantCount].AttachObject(exteriorTile[outFloorTileCount]);
                            outFloorTileCount++;
                        } 
                        else*/
                        passes = 1;
                    } /*Debug:*/  // Debug.Assert(DebugStatements == true,"Vertex: {0} -- Edges Source: {1} Target: {2}", v, e.Source, e.Target);  Debug.Assert(DebugStatements == true,"{0} {1}", v, this.sm.md2[v].Count);        
                } // add your created quadrant to the map 
                if (this.moduleNode[moduleCount] != null)
                {   //reset Module orientation for now until SmartMap uses Module oriention later for organized cities
                    this.moduleNode[moduleCount].ResetOrientation();
                    this.quadrantNode[quadrantCount].AddChild(this.moduleNode[moduleCount]);
                    assertMessage = string.Format("[][][] New Module {0} has been created for Quadrant {1}[][][]", this.moduleNode[moduleCount].Name, this.quadrantNode[quadrantCount].Name);
                    Console.WriteLine(assertMessage);
                    //Console.ReadLine();
                }
                moduleCount++;
            }
        }

        public void ManufactureModule(int moduleCount, float xLocation, float zLocation)
        {
            //move up, or down, the mountain 
            float moveUp = 0;
            //int clippedTileCount = 0;
            bool tilesetDestroyed = false;

            //// TRIM MODULES FIRST////
            this.sm.GenerateGraph("MODULE", false, tileAmountNorth, tileAmountEast);
            CreateModule(moduleCount, 0, 0, 0); // create generic tileset to adjust it to terrain
            // PREPARE MODULE FOUNDATION / get terrain height - search in center of module
            moveUp = SceneManager.GetHeightAt(new Vector3(xLocation + (moduleSizeEast / 2), 0, zLocation + (moduleSizeNorth / 2)), 0);
            // MOVE THE MODULE ONTO ITS FOUNDATION
            this.moduleNode[moduleCount].Translate(new Vector3(xLocation, moveUp, zLocation), TransformSpace.World);
            //this.moduleNode[moduleCount].Position = new Vector3(xLocation, moveUp, zLocation);
            // TRIM TILESET AROUND TERRAIN FOUNDATION
            // check each tileNode verses module node's height and remove edges and tiles that are burried inside terrain. 
            /* Debug.Assert(DebugStatements == true,"{0}", this.moduleNode[moduleCount].Name + "'s nodes are being searched for terrain clipping...");
            foreach (SceneNode node in this.moduleNode[moduleCount].Children) // go through tiles
            { 
                 Debug.Assert(DebugStatements == true,"{0}", node.Name + " is being checked..."); // derivedPosition for real world tileNode position - (derived) very important.
                float tileHeight = SceneManager.GetHeightAt(new Vector3(node.DerivedPosition.x, 0, node.DerivedPosition.z), 0);
                if (1000 > (moveUp - MeshSize) + tileClippingAngle) // if tile is in terrain 
                {
                    clippedTileCount++;
                    if (clippedTileCount == (tileAmountNorth * tileAmountEast) * 0.8)
                    { // if removed tile count equals tileThreshold, remove entire module
                        SceneManager.DestroySceneNode(this.moduleNode[moduleCount].Name);
                        tilesetDestroyed = true;
                         Debug.Assert(DebugStatements == true,"Too many tiles clipped so module removed. Searching next module.\n\n\n");
                    }
                    else if (!tilesetDestroyed)
                    { // remove tile 
                         Debug.Assert(DebugStatements == true,"{0}", node.Name + " is too far in terrain.");
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
                                         Debug.Assert(DebugStatements == true,"Found tilenode's buried Readout vertex: " + x + "," + z + " ...Removing vertex.");
                                        this.sm.graph.RemoveVertex(new Point<int>(x, z)); // remove vertices to search valid graph. 
                                    }
                                }
                            }
                        }
                    }
                }
            }*/
            if (tilesetDestroyed == false)
            {   // RECREATE NEW MODULES BASED ON CURRENT TERRAIN TRIMMED GRAPH
                 Debug.Assert(DebugStatements == true,"...Re-Creating " + this.moduleNode[moduleCount].Name + "'s tile-set into maze that fits terrain.");
                // reset node arrays
                SceneManager.DestroySceneNode(this.moduleNode[moduleCount].Name);
                assertMessage = string.Format("{0} has {1} children left after being destroyed for re-creation", this.moduleNode[moduleCount].Name, this.moduleNode[moduleCount].ChildCount);
                Debug.Assert(DebugStatements == true, assertMessage);
                // generate maze with auto or manual path - if it zonks out skip :-)
                if (!this.sm.GeneratePath("MODULE", false, 0, 0)) { return; }
                // creates and searches logical path through module (shortest-path)
                //this.sm.SearchPath("BFS", this.moduleNode[moduleCount]);
                CreateModule(moduleCount, 0, 0, 0);
                //this.moduleNode[0].AttachObject(ParticleSystemManager.Instance.CreateSystem("Smoke", "Examples/Smoke"));
                Debug.Assert(DebugStatements == true,this.moduleNode[moduleCount].Name + " REMODELED");
                // TRANSLATE NEW MODULE BACK ONTO FOUNDATION
                this.moduleNode[moduleCount].Translate(new Vector3(xLocation, moveUp, zLocation), TransformSpace.World);
                //this.moduleNode[moduleCount].Position = new Vector3(xLocation, moveUp + this.tileSetHeight, zLocation);
                assertMessage = string.Format("{0} has {1} children left after being destroyed for re-creation", this.moduleNode[moduleCount].Name, this.moduleNode[moduleCount].ChildCount);
                Debug.Assert(DebugStatements == true, assertMessage);
                // AUTO-MOLD TERRAIN to fit around tileset for a customized Foundation under module
                foreach (SceneNode node in this.moduleNode[moduleCount].Children)
                { // bring up or lower terrain (terrain deformation) to match all tileNode heights 
                    SceneManager.SetHeightAt(node.DerivedPosition, node.DerivedPosition.y - (MeshSize / 2));
                }
            }
            //clippedTileCount = 0; // reset variables
        }

        /// <summary>
        /// Print Modules (Tilesets) with Tiles
        /// </summary>
        /// <param name="xPosition"></param>
        /// <param name="yPosition"></param>
        /// <param name="zPosition"></param>
        public void CreateModule(/*int skew,*/ int moduleCount,  float xPosition, float yPosition, float zPosition)
        {
            float x = 0, /*y = 0,*/ z = 0;
            int passes = 0;  

            // create new Tileset Modules
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
                //Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>> ec =
                    //(Wintellect.PowerCollections.CollectionBase<Edge<Point<int>>>)sm.md[v];
                // go through all of the MD vertices and populate many tilesets with edges.
                // use TileCount variables to find "place in line." IE: Where each new tileset starts in MD
                foreach (Edge<Point<int>> e in this.sm.md[v]) // CREATE NEW EDGE PACK per VERTEX, 1-4, Leave loop when created
                {
                    // END
                    if (this.sm.md[v].Count == 1) // one edge for End tile
                    {
                        Debug.Assert(DebugStatements == true,"Manufacturing END Tile");
                        this.tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                        this.tileNode[nodeCount].ResetToInitialState(); // set mesh North as created in modeler
                        this.tileNode[nodeCount].Position = new Vector3(x, 0, z);
                        // add exterior tile if adjacent edge is empty. Corner for two. 
                        if (this.sm.NoNearbyVertices(v) == "outerwall")
                        {          
                            this.tileNode[nodeCount].AttachObject(exteriorTileEnd[outEndTileCount]);  
                            Console.WriteLine("Exterior EndTile Entity {0} attached", outEndTileCount);
                            outEndTileCount++;
                        }
                        else
                            this.tileNode[nodeCount].AttachObject(interiorTileEnd[endTileCount]);
                            endTileCount++;
                        // yaw
                        if ((e.Source.Width < v.Width) || (e.Target.Width < v.Width))
                        {
                            this.tileNode[nodeCount].Yaw(90);
                        }
                        else if ((e.Source.Width > v.Width) || (e.Target.Width > v.Width))
                        {
                            this.tileNode[nodeCount].Yaw(270);
                        }
                        else if ((e.Source.Length < v.Length) || (e.Target.Length < v.Length))
                        {
                            this.tileNode[nodeCount].Yaw(0);
                        }
                        else if ((e.Source.Length > v.Length) || (e.Target.Length > v.Length))
                        {
                            this.tileNode[nodeCount].Yaw(180);
                        }
                    }
                    // HALL 
                    if (this.sm.md[v].Count == 2)
                    { // set 2nd edge to compare both edges for: Hall or Corner
                         Debug.Assert(DebugStatements == true,"Manufacturing HALL Tile");
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
                            this.tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            this.tileNode[nodeCount].ResetToInitialState();
                            this.tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NoNearbyVertices(v) == "outerwall")
                            {
                                this.tileNode[nodeCount].AttachObject(exteriorTileHall[outHallTileCount]);
                                outHallTileCount++;
                            }
                            else
                                this.tileNode[nodeCount].AttachObject(interiorTileHall[hallTileCount]);
                            hallTileCount++;
                            // yaw 
                            if ((sew2 != v.Width) | (tew2 != v.Width))
                                this.tileNode[nodeCount].Yaw(90);
                        }
                        else
                        { // CORNER
                             Debug.Assert(DebugStatements == true,"Manufacturing CORNER Tile");
                            this.tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            this.tileNode[nodeCount].ResetToInitialState();
                            this.tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NoNearbyVertices(v) == "outerwall")
                            {
                                this.tileNode[nodeCount].AttachObject(exteriorTileCorner[outCornerTileCount]);
                                outCornerTileCount++;
                            }
                            else
                                this.tileNode[nodeCount].AttachObject(interiorTileCorner[cornerTileCount]);
                            cornerTileCount++;
                            // yaw 
                            if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                            || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                this.tileNode[nodeCount].Yaw(0);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                this.tileNode[nodeCount].Yaw(180);
                            }
                            else if ((((e.Source.Width > v.Width) | (e.Target.Width > v.Width)) & ((sel2 > v.Length) | (tel2 > v.Length)))
                          || (((e.Source.Length > v.Length) | (e.Target.Length > v.Length)) & ((sew2 > v.Width) | (tew2 > v.Width))))
                            {
                                this.tileNode[nodeCount].Yaw(270);
                            }
                            else if ((((e.Source.Width < v.Width) | (e.Target.Width < v.Width)) & ((sel2 < v.Length) | (tel2 < v.Length)))
                          || (((e.Source.Length < v.Length) | (e.Target.Length < v.Length)) & ((sew2 < v.Width) | (tew2 < v.Width))))
                            {
                                this.tileNode[nodeCount].Yaw(90);
                            }
                        }
                    }
                    // SIDE
                    if (this.sm.md[v].Count == 3) // 3 edges to calculate side tile
                    {
                         Debug.Assert(DebugStatements == true,"Manufacturing SIDE Tile");
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
                            this.tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                            this.tileNode[nodeCount].ResetToInitialState();
                            this.tileNode[nodeCount].Position = new Vector3(x, 0, z);
                            if (this.sm.NoNearbyVertices(v) == "outerwall")
                            {
                                this.tileNode[nodeCount].AttachObject(exteriorTileSide[outSideTileCount]);
                                outSideTileCount++;
                            }
                            else
                                this.tileNode[nodeCount].AttachObject(interiorTileSide[sideTileCount]);
                            sideTileCount++;
                            // yaw 
                            if (!(e.Source.Length < v.Length) & !(e.Target.Length < v.Length) & !(sel2 < v.Length) & !(tel2 < v.Length) & !(sel3 < v.Length) & !(tel3 < v.Length))
                            {
                                this.tileNode[nodeCount].Yaw(180);
                            }
                            else if (!(e.Source.Length > v.Length) & !(e.Target.Length > v.Length) & !(sel2 > v.Length) & !(tel2 > v.Length) & !(sel3 > v.Length) & !(tel3 > v.Length))
                            {
                                this.tileNode[nodeCount].Yaw(0);
                            }
                            else if (!(e.Source.Width < v.Width) & !(e.Target.Width < v.Width) & !(sew2 < v.Width) & !(tew2 < v.Width) & !(sew3 < v.Width) & !(tew3 < v.Width))
                            {
                                this.tileNode[nodeCount].Yaw(270);
                            }
                            else if (!(e.Source.Width > v.Width) & !(e.Target.Width > v.Width) & !(sew2 > v.Width) & !(tew2 > v.Width) & !(sew3 > v.Width) & !(tew3 > v.Width))
                            {
                                this.tileNode[nodeCount].Yaw(90);
                            }
                        }
                    }
                    // FLOOR
                    if ((this.sm.md[v].Count == 4) & (passes == 0)) // 4 on the floor :)
                    {
                        Debug.Assert(DebugStatements == true,"Manufacturing FLOOR Tile");
                        this.tileNode[nodeCount] = SceneManager.RootSceneNode.CreateChildSceneNode("Tile " + nodeCount);
                        this.tileNode[nodeCount].ResetToInitialState();
                        this.tileNode[nodeCount].Position = new Vector3(x, 0, z);
                        if (this.sm.NoNearbyVertices(v) == "outerwall")
                        {
                            this.tileNode[nodeCount].AttachObject(exteriorTileFloor[outFloorTileCount]);
                            outFloorTileCount++;
                        }
                        else
                            this.tileNode[nodeCount].AttachObject(interiorTileFloor[floorTileCount]);
                        passes = 1;
                        floorTileCount++;
                    } /*Debug:*/  // Debug.Assert(DebugStatements == true,DebugStatements == true,"Vertex: {0} -- Edges Source: {1} Target: {2}", v, e.Source, e.Target);  Debug.Assert(DebugStatements,"{0} {1}", v, this.sm.md[v].Count);        
                }
                if (this.tileNode[nodeCount] != null)
                {
                    this.moduleNode[moduleCount].AddChild(this.tileNode[nodeCount]);
                    this.moduleNode[moduleCount].DetachAllObjects();
                    
                    //this.moduleNode[moduleCount].AddChild(this.tileNode[nodeCount]);
                    assertMessage = string.Format("[][][] New tile {0} has been created [][][]", nodeCount);
                    Console.WriteLine("TileNode {0} has been created", this.tileNode[nodeCount].Name);
                    Debug.Assert(DebugStatements == true, assertMessage);
                }
                nodeCount++;
            }
            assertMessage = string.Format("[][][] New tile {0} has been created [][][]", nodeCount);
            Debug.Assert(DebugStatements == true, assertMessage);
        }

        #endregion TileSet

        protected virtual void ResetTiles(int moduleCount)
        {
            //this.nextPathnode = 0;

            // reset map variables 
            this.moduleSizeEast = MeshSize * tileAmountEast;
            this.moduleSizeNorth = MeshSize * tileAmountNorth;

            for (; newModuleCount < moduleCount; newModuleCount++)
            {
                if (moduleNode[newModuleCount].ChildCount == 0)
                {
                    continue;
                }

                SceneManager.DestroySceneNode(moduleNode[newModuleCount].Name);
                 Debug.Assert(DebugStatements == true,"Destroyed Module Node {0}" + moduleNode[newModuleCount].Name);
            }
            GC.Collect();

            // refresh terrain
            //SceneManager.ResetTerrain();
            CreateWorld(0, 0, 0, 0, 0);

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

        public override void Dispose()
        {
            if (query != null)
            {
                query.Dispose();
            }
            base.Dispose();
        }

        #region MODEL CONTROLS

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public override bool KeyPressed(SharpInputSystem.KeyEventArgs evt)
        {
            // relay input events to character controller
            if (!TrayManager.IsDialogVisible)
            {
                this.d4d.sinbad.InjectKeyDown(evt);
            }

            return base.KeyPressed(evt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public override bool KeyReleased(SharpInputSystem.KeyEventArgs evt)
        {
            if (!TrayManager.IsDialogVisible)
            {
                this.d4d.sinbad.InjectKeyUp(evt);
            }

            return base.KeyReleased(evt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <returns></returns>
        public override bool MouseMoved(SharpInputSystem.MouseEventArgs evt)
        {
            // relay input events to character controller
            if (!TrayManager.IsDialogVisible)
            {
                this.d4d.sinbad.InjectMouseMove(evt);
            }

            return base.MouseMoved(evt);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="evt"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public override bool MousePressed(SharpInputSystem.MouseEventArgs evt, SharpInputSystem.MouseButtonID id)
        {
            // relay input events to character controller
            if (!TrayManager.IsDialogVisible)
            {
                this.d4d.sinbad.InjectMouseDown(evt, id);
            }

            return base.MousePressed(evt, id);
        }

        #endregion

        #region RENDERING QUEUE HARDWARE OCCLUSION

        /// <summary>
        ///	When RenderQueue 6 is starting, we will begin the occlusion query.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        private void scene_QueueStarted(object sender, SceneManager.BeginRenderQueueEventArgs e)
        {

            #region OCCLUSIONQEURY BEGIN
            // begin the occlusion query
            /*if (e.RenderQueueId == RenderQueueGroupID.One)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Two)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Three)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Four)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Six)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Seven)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Eight)
            {
                query.Begin();
            }
            if (e.RenderQueueId == RenderQueueGroupID.Nine)
            {
                query.Begin();
            }*/
            #endregion

            return;
        }

        /// <summary>
        ///	When RenderQueue 6 is ending, we will end the query and poll for the results.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        private void scene_QueueEnded(object sender, SceneManager.EndRenderQueueEventArgs e)
        {
            #region OCCLUSION QUERY END
            // end our occlusion query
            /*if (e.RenderQueueId == RenderQueueGroupID.One)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue One: Object is occluded. ");
                    for (int i = 0; i < interiorTileSide.Count; i++)
                    {
                        if (interiorTileSide[i] != null && interiorTileSide[i].IsAttached && interiorTileSide[i].IsVisible)
                        {

                            interiorTileSide[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue One: Visible fragments = {0}", count);
                    for (int i = 0; i < interiorTileSide.Count; i++)
                    {
                        if (interiorTileSide[i] != null && interiorTileSide[i].IsAttached && !interiorTileSide[i].IsVisible)
                        {

                            interiorTileSide[i].IsVisible = true;
                        }
                    }
                }
            }
            
            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Two)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Two: Object is occluded. ");
                    for (int i = 0; i < interiorTileHall.Count; i++)
                    {
                        if (interiorTileHall[i] != null && interiorTileHall[i].IsAttached && interiorTileHall[i].IsVisible)
                        {

                            interiorTileHall[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Two: Visible fragments = {0}", count);
                    for (int i = 0; i < interiorTileHall.Count; i++)
                    {
                        if (interiorTileHall[i] != null && interiorTileHall[i].IsAttached && !interiorTileHall[i].IsVisible)
                        {

                            interiorTileHall[i].IsVisible = true;
                        }
                    }
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Three)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Three: Object is occluded. ");
                    for (int i = 0; i < interiorTileCorner.Count; i++)
                    {
                        if (interiorTileCorner[i] != null && interiorTileCorner[i].IsAttached && interiorTileCorner[i].IsVisible)
                        {

                            interiorTileCorner[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < interiorTileCorner.Count; i++)
                    {
                        if (interiorTileCorner[i] != null && interiorTileCorner[i].IsAttached && !interiorTileCorner[i].IsVisible)
                        {

                            interiorTileCorner[i].IsVisible = true;
                        }
                    }
                    debugText = string.Format("Queue Three: Visible fragments = {0}", count);
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Four)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Four: Object is occluded. ");
                    for (int i = 0; i < interiorTileEnd.Count; i++)
                    {
                        if (interiorTileEnd[i] != null && interiorTileEnd[i].IsAttached && interiorTileEnd[i].IsVisible)
                        {

                            interiorTileEnd[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Four: Visible fragments = {0}", count);
                    for (int i = 0; i < interiorTileEnd.Count; i++)
                    {
                        if (interiorTileEnd[i] != null && interiorTileEnd[i].IsAttached && !interiorTileEnd[i].IsVisible)
                        {

                            interiorTileEnd[i].IsVisible = true;
                        }
                    }
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Six)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Six: Object is occluded. ");
                    for (int i = 0; i < interiorTileFloor.Count; i++)
                    {
                        if (interiorTileFloor[i] != null && interiorTileFloor[i].IsAttached & interiorTileFloor[i].IsVisible)
                        {

                            interiorTileFloor[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Six: Visible fragments = {0}", count);
                    for (int i = 0; i < interiorTileFloor.Count; i++)
                    {
                        if (interiorTileFloor[i] != null && interiorTileFloor[i].IsAttached & !interiorTileFloor[i].IsVisible)
                        {

                            interiorTileFloor[i].IsVisible = true;
                        }
                    }
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Seven)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Seven: Object is occluded. ");
                    for (int i = 0; i < exteriorTileSide.Count; i++)
                    {
                        if (exteriorTileSide[i] != null && exteriorTileSide[i].IsAttached & exteriorTileSide[i].IsVisible)
                        {

                            exteriorTileSide[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Seven: Visible fragments = {0}", count);
                    for (int i = 0; i < exteriorTileSide.Count; i++)
                    {
                        if (exteriorTileSide[i] != null && exteriorTileSide[i].IsAttached & !exteriorTileSide[i].IsVisible)
                        {

                            exteriorTileSide[i].IsVisible = true;
                        }
                    }
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Eight)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Eight: Object is occluded. ");
                    for (int i = 0; i < exteriorTileHall.Count; i++)
                    {
                        if (exteriorTileHall[i] != null && exteriorTileHall[i].IsAttached & exteriorTileHall[i].IsVisible)
                        {

                            exteriorTileHall[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Eight: Visible fragments = {0}", count);
                    for (int i = 0; i < exteriorTileHall.Count; i++)
                    {
                        if (exteriorTileHall[i] != null && exteriorTileHall[i].IsAttached & !exteriorTileHall[i].IsVisible)
                        {

                            exteriorTileHall[i].IsVisible = true;
                        }
                    }
                }
            }

            // end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Nine)
            {
                query.End();
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Nine: Object is occluded. ");
                    for (int i = 0; i < exteriorTileCorner.Count; i++)
                    {
                        if (exteriorTileCorner[i] != null && exteriorTileCorner[i].IsAttached & exteriorTileCorner[i].IsVisible)
                        {

                            exteriorTileCorner[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Nine: Visible fragments = {0}", count);
                    for (int i = 0; i < exteriorTileCorner.Count; i++)
                    {
                        if (exteriorTileCorner[i] != null && exteriorTileCorner[i].IsAttached & !exteriorTileCorner[i].IsVisible)
                        {

                            exteriorTileCorner[i].IsVisible = true;
                        }
                    }
                }
            }// end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Nine)
            {
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Nine: Object is occluded. ");
                    for (int i = 0; i < exteriorTileEnd.Count; i++)
                    {
                        if (exteriorTileEnd[i] != null && exteriorTileEnd[i].IsAttached & exteriorTileEnd[i].IsVisible)
                        {

                            exteriorTileEnd[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Nine: Visible fragments = {0}", count);
                    for (int i = 0; i < exteriorTileEnd.Count; i++)
                    {
                        if (exteriorTileEnd[i] != null && exteriorTileEnd[i].IsAttached & !exteriorTileEnd[i].IsVisible)
                        {

                            exteriorTileEnd[i].IsVisible = true;
                        }
                    }
                }
            }// end our occlusion query
            if (e.RenderQueueId == RenderQueueGroupID.Nine)
            {
                int count = query.PullResults();

                // report the results
                if (count <= 0)
                { // get the fragment count from the query
                    debugText = string.Format("Queue Nine: Object is occluded. ");
                    for (int i = 0; i < exteriorTileFloor.Count; i++)
                    {
                        if (exteriorTileFloor[i] != null && exteriorTileFloor[i].IsAttached & exteriorTileFloor[i].IsVisible)
                        {

                            exteriorTileFloor[i].IsVisible = false;
                        }
                    }
                }
                else
                {
                    debugText = string.Format("Queue Nine: Visible fragments = {0}", count);
                    for (int i = 0; i < exteriorTileFloor.Count; i++)
                    {
                        if (exteriorTileFloor[i] != null && exteriorTileFloor[i].IsAttached & !exteriorTileFloor[i].IsVisible)
                        {

                            exteriorTileFloor[i].IsVisible = true;
                        }
                    }
                }
            }*/
            #endregion

            return;
        }
        
        #endregion

        #region Frame Animation   

        protected override void OnFrameStarted(object source, FrameEventArgs e)
        {
            // let sinbad character update animations and camera
            this.d4d.sinbad.AddTime(e.TimeSinceLastFrame);

            //timeSinceLastFrame = e.TimeSinceLastFrame;
            base.OnFrameStarted(source, e);

            #region FRUSTUM CULL
            //objectsVisible = 0;

           for (int i = 0; i < exteriorTileEnd.Count; i++) 
           {
               if (exteriorTileEnd[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(exteriorTileEnd[i].GetWorldBoundingBox()))
                   {
                       //exteriorTileEnd[i].ShowBoundingBox = false;
                       exteriorTileEnd[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //exteriorTileEnd[i].ShowBoundingBox = false;
                       exteriorTileEnd[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < exteriorTileCorner.Count; i++)
           {
               if (exteriorTileCorner[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(exteriorTileCorner[i].GetWorldBoundingBox()))
                   {
                       //exteriorTileCorner[i].ShowBoundingBox = false;
                       exteriorTileCorner[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //exteriorTileCorner[i].ShowBoundingBox = false;
                       exteriorTileCorner[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < exteriorTileFloor.Count; i++)
           {
               if (exteriorTileFloor[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(exteriorTileFloor[i].GetWorldBoundingBox()))
                   {
                       //exteriorTileFloor[i].ShowBoundingBox = false;
                       exteriorTileFloor[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //exteriorTileFloor[i].ShowBoundingBox = false;
                       exteriorTileFloor[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < exteriorTileHall.Count; i++)
           {
               if (exteriorTileHall[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(exteriorTileHall[i].GetWorldBoundingBox()))
                   {
                       //exteriorTileHall[i].ShowBoundingBox = false;
                       exteriorTileHall[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //exteriorTileHall[i].ShowBoundingBox = false;
                       exteriorTileHall[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < exteriorTileSide.Count; i++)
           {
               if (exteriorTileSide[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(exteriorTileSide[i].GetWorldBoundingBox()))
                   {
                       //exteriorTileSide[i].ShowBoundingBox = false;
                       exteriorTileSide[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //exteriorTileSide[i].ShowBoundingBox = false;
                       exteriorTileSide[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < interiorTileCorner.Count; i++)
           {
               if (interiorTileCorner[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(interiorTileCorner[i].GetWorldBoundingBox()))
                   {
                       //interiorTileCorner[i].ShowBoundingBox = false;
                       interiorTileCorner[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //interiorTileCorner[i].ShowBoundingBox = false;
                       interiorTileCorner[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < interiorTileEnd.Count; i++)
           {
               if (interiorTileEnd[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(interiorTileEnd[i].GetWorldBoundingBox()))
                   {
                       //interiorTileEnd[i].ShowBoundingBox = false;
                       interiorTileEnd[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //interiorTileEnd[i].ShowBoundingBox = false;
                       interiorTileEnd[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < interiorTileFloor.Count; i++)
           {
               if (interiorTileFloor[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(interiorTileFloor[i].GetWorldBoundingBox()))
                   {
                       //interiorTileFloor[i].ShowBoundingBox = false;
                       interiorTileFloor[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //interiorTileFloor[i].ShowBoundingBox = false;
                       interiorTileFloor[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < interiorTileHall.Count; i++)
           {
               if (interiorTileHall[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(interiorTileHall[i].GetWorldBoundingBox()))
                   {
                       //interiorTileHall[i].ShowBoundingBox = false;
                       interiorTileHall[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //interiorTileHall[i].ShowBoundingBox = false;
                       interiorTileHall[i].IsVisible = false;
                   }
               }
           }

           for (int i = 0; i < interiorTileSide.Count; i++)
           {
               if (interiorTileSide[i].IsAttached)
               {
                   if (this.m_frustum.IsObjectVisible(interiorTileSide[i].GetWorldBoundingBox()))
                   {
                       //interiorTileSide[i].ShowBoundingBox = false;
                       interiorTileSide[i].IsVisible = true;
                   }
                   else // make sure entity is attached before attempting to use it
                   {
                       //interiorTileSide[i].ShowBoundingBox = false;
                       interiorTileSide[i].IsVisible = false;
                   }
               }
           }
            // report the number of objects within the frustum 
            //debugText = string.Format("Objects visible: {0}", objectsVisible);
            #endregion

            #region OBJECT PATHFINDING

            ////// MODEL PATHFINDING //////
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
                     Debug.Assert(DebugStatements == true,"Pathnode: {0}", nextPathnode);             

                    // update the direction and the distance
                    directionOfTravel = nextWaypoint - d4d.modelNode[0].DerivedPosition;
                     Debug.Assert(DebugStatements == true,"Next Waypoint: {0} - {1}", nextWaypoint, d4d.modelNode[0].DerivedPosition);
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
                move = modelWalkS  peed * timeSinceLastFrame;
                distanceToNextWaypoint -= move;                                 
            }
            // you have reached a pathnode
            if (distanceToNextWaypoint <= 0) // stop model and set isModelWalking to false 
            {      //  Debug.Assert(DebugStatements == true,"Stopped");
                // set our node to the destination we've just reached & reset direction to 0
                d4d.modelNode[0].Position = nextWaypoint;
                directionOfTravel = Vector3.Zero;
                isModelWalking = false;
            } else // move the model
            {
                //  Debug.Assert(DebugStatements == true,"Moving");
                // movement code goes here
                //directionOfTravel = nextWaypoint - d4d.modelNode[0].DerivedPosition;
                d4d.modelNode[0].Translate(directionOfTravel * move);

                // rotation code goes here
                Vector3 src = d4d.modelNode[0].Orientation * Vector3.UnitX;
                Quaternion quat = src.GetRotationTo(directionOfTravel);
                d4d.modelNode[0].Rotate(quat);

            }*/

            #endregion ANIMATION

            #region MODEL NODE COLLISIONS
            /*
                // PAGING ZONE SYSTEM (dependant on pure engine coordinates, meant for massive worlds)
                // Essentially a Random Zone creator as you explore
                //////////////////////////////////////

                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[0].WorldAABB)) & (camClipped != 1))
                { 
                    // turn off camClip until another is triggered because of timer
                    camClipped = 1;
                    Window.DebugText = string.Format("Zone: 1");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x - mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z - mapSize))
                    {
                        CreateModule(4, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x - mapSize*2, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[1].WorldAABB)) & (camClipped != 2))
                {
                    camClipped = 2;
                    Window.DebugText = string.Format("Zone: 2");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z > tileNode[0].Position.z))
                    {
                        CreateModule(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[2].WorldAABB)) & (camClipped != 3))
                {
                    camClipped = 3;
                    Window.DebugText = string.Format("Zone: 3");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x + mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z - mapSize))
                    {

                        CreateModule(4, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z - mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[3].WorldAABB)) & (camClipped != 4))
                {
                    camClipped = 4;
                    Window.DebugText = string.Format("Zone: 4");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z != tileNode[0].Position.z - mapSize))
                    {

                        CreateModule(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[4].WorldAABB)) & (camClipped != 5))
                {
                    camClipped = 5;
                    Window.DebugText = string.Format("Zone: 5");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[2700].Position.z > tileNode[900].Position.z))
                    {

                        CreateModule(4, true, tileNode[900].Position.x, 0, tileNode[900].Position.z - mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[5].WorldAABB)) & (camClipped != 6))
                {
                    camClipped = 6;
                    Window.DebugText = string.Format("Zone: 6");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x + mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z - mapSize))
                    {

                        CreateModule(3, true, tileNode[900].Position.x + mapSize, 0, tileNode[900].Position.z - mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z - mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[6].WorldAABB)) & (camClipped != 7))
                {
                    camClipped = 7;
                    Window.DebugText = string.Format("Zone: 7");
                    if ((tileNode[900].Position.z != tileNode[0].Position.z) | (tileNode[900].Position.x > tileNode[0].Position.x))
                    {

                        CreateModule(2, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z);
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

                        CreateModule(2, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[9].WorldAABB)) & (camClipped != 10))
                {
                    camClipped = 10;
                    Window.DebugText = string.Format("Zone: 10");
                    if ((tileNode[0].Position.z != tileNode[900].Position.z) | (tileNode[0].Position.x > tileNode[900].Position.x))
                    {

                        CreateModule(1, true, tileNode[900].Position.x - mapSize, 0, tileNode[900].Position.z);
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

                        CreateModule(1, true, tileNode[900].Position.x + mapSize, 0, tileNode[0].Position.z);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[12].WorldAABB)) & (camClipped != 13))
                {
                    camClipped = 13;
                    Window.DebugText = string.Format("Zone: 13");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x - mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z + mapSize))
                        {

                            CreateModule(4, true, tileNode[0].Position.x - mapSize, 0, tileNode[0].Position.z + mapSize);
                            d4d.zoneGroup[3].Position =  new Vector3(d4d.zoneGroup[0].Position.x - mapSize*2, 0, d4d.zoneGroup[0].Position.z);
                        }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[13].WorldAABB)) & (camClipped != 14))
                {
                    camClipped = 14;
                    Window.DebugText = string.Format("Zone: 14");
                    if ((tileNode[0].Position.x != tileNode[1800].Position.x) | (tileNode[0].Position.z > tileNode[1800].Position.z))
                    {

                        CreateModule(3, true, tileNode[0].Position.x, 0, tileNode[0].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[14].WorldAABB)) & (camClipped != 15))
                {
                    camClipped = 15;
                    Window.DebugText = string.Format("Zone: 15");
                    if ((tileNode[2700].Position.x != tileNode[0].Position.x + mapSize) | (tileNode[2700].Position.z != tileNode[0].Position.z + mapSize))
                    {

                        CreateModule(4, true, tileNode[0].Position.x + mapSize, 0, tileNode[0].Position.z + mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[0].Position.x, 0, d4d.zoneGroup[0].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[15].WorldAABB)) & (camClipped != 16))
                {
                    camClipped = 16;
                    Window.DebugText = string.Format("Zone: 16");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x - mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z + mapSize))
                    {

                        CreateModule(3, true, tileNode[900].Position.x - mapSize, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[16].WorldAABB)) & (camClipped != 17)) 
                {
                    camClipped = 17;
                    Window.DebugText = string.Format("Zone: 17");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[2700].Position.z < tileNode[900].Position.z))
                    {

                        CreateModule(4, true, tileNode[900].Position.x, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[1].Position.x, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[17].WorldAABB)) & (camClipped != 18))
                {
                    camClipped = 18;
                    Window.DebugText = string.Format("Zone: 18");
                    if ((tileNode[1800].Position.x != tileNode[900].Position.x + mapSize) | (tileNode[1800].Position.z != tileNode[900].Position.z + mapSize))
                    {

                        CreateModule(3, true, tileNode[900].Position.x + mapSize, 0, tileNode[900].Position.z + mapSize);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[1].Position.x + mapSize*2, 0, d4d.zoneGroup[1].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[18].WorldAABB)) & (camClipped != 19))
                {
                    camClipped = 19;
                    Window.DebugText = string.Format("Zone: 19");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x - mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z - mapSize))
                    {

                        CreateModule(2, true, tileNode[1800].Position.x - mapSize, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x - mapSize*2, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[19].WorldAABB)) & (camClipped != 20))
                {
                    camClipped = 20;
                    Window.DebugText = string.Format("Zone: 20");
                    if ((tileNode[0].Position.x != tileNode[1800].Position.x) | (tileNode[0].Position.z > tileNode[1800].Position.z))
                    {

                        CreateModule(1, true, tileNode[1800].Position.x, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[20].WorldAABB)) & (camClipped != 21))
                {
                    camClipped = 21;
                    Window.DebugText = string.Format("Zone: 21");   
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x + mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z - mapSize))
                    {

                        CreateModule(2, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[21].WorldAABB)) & camClipped != 22) {
                    camClipped = 22;
                    Window.DebugText = string.Format("Zone: 22");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x - mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {

                        CreateModule(1, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[22].WorldAABB)) & (camClipped != 23))
                {
                    camClipped = 23;
                    Window.DebugText = string.Format("Zone: 23");
                    if ((tileNode[900].Position.x != tileNode[2700].Position.x) | (tileNode[900].Position.z > tileNode[2700].Position.z))
                    {

                        CreateModule(2, true, tileNode[2700].Position.x, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[23].WorldAABB)) & (camClipped != 24))
                {
                    camClipped = 24;
                    Window.DebugText = string.Format("Zone: 24");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x + mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {

                        CreateModule(1, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z - mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[24].WorldAABB)) & (camClipped != 25))
                {
                    camClipped = 25;
                    Window.DebugText = string.Format("Zone: 25");
                    if ((tileNode[2700].Position.z != tileNode[1800].Position.z) | (tileNode[2700].Position.x > tileNode[1800].Position.x))
                    {

                        CreateModule(4, true, tileNode[1800].Position.x - mapSize, 0, tileNode[0].Position.z);
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

                        CreateModule(4, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z);
                        d4d.zoneGroup[3].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[27].WorldAABB)) & (camClipped != 28))
                {
                    camClipped = 28;
                    Window.DebugText = string.Format("Zone: 28");
                    if ((tileNode[1800].Position.z != tileNode[2700].Position.z) | (tileNode[1800].Position.x > tileNode[2700].Position.x))
                    {

                        CreateModule(3, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z);
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

                        CreateModule(3, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z);
                        d4d.zoneGroup[2].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[30].WorldAABB)) & (camClipped != 31))
                {
                    camClipped = 31;
                    Window.DebugText = string.Format("Zone: 31");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x - mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z + mapSize))
                    {

                        CreateModule(2, true, tileNode[1800].Position.x - mapSize, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x - mapSize*2, 0, d4d.zoneGroup[2].Position.z + mapSize*2);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[31].WorldAABB)) & (camClipped != 32))
                {
                    camClipped = 32;
                    Window.DebugText = string.Format("Zone: 32");
                    if ((tileNode[1800].Position.x != tileNode[0].Position.x) | (tileNode[1800].Position.z > tileNode[0].Position.z))
                    {

                        CreateModule(1, true, tileNode[1800].Position.x, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z);
                    }
                } else
                if  ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[32].WorldAABB)) & (camClipped != 33))
                {
                    camClipped = 33;
                    Window.DebugText = string.Format("Zone: 33");
                    if ((tileNode[900].Position.x != tileNode[1800].Position.x + mapSize) | (tileNode[900].Position.z != tileNode[1800].Position.z + mapSize))
                    {

                        CreateModule(2, true, tileNode[1800].Position.x + mapSize, 0, tileNode[1800].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[2].Position.x, 0, d4d.zoneGroup[2].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[33].WorldAABB)) & (camClipped != 34))
                {
                    camClipped = 34;
                    Window.DebugText = string.Format("Zone: 34");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x - mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z - mapSize))
                    {

                        CreateModule(1, true, tileNode[2700].Position.x - mapSize, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[34].WorldAABB)) & (camClipped != 35))
                {
                    camClipped = 35;
                    Window.DebugText = string.Format("Zone: 35");
                    if ((tileNode[2700].Position.x != tileNode[900].Position.x) | (tileNode[900].Position.z < tileNode[2700].Position.z))
                    {

                        CreateModule(2, true, tileNode[2700].Position.x, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[1].Position = new Vector3(d4d.zoneGroup[3].Position.x, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                } else
                if ((d4d.modelNode[0].WorldAABB.Intersects(d4d.zoneNode[35].WorldAABB)) & (camClipped != 36))
                {
                    camClipped = 36;
                    Window.DebugText = string.Format("Zone: 36");
                    if ((tileNode[0].Position.x != tileNode[2700].Position.x + mapSize) | (tileNode[0].Position.z != tileNode[2700].Position.z + mapSize))
                    {
                        CreateModule(1, true, tileNode[2700].Position.x + mapSize, 0, tileNode[2700].Position.z + mapSize);
                        d4d.zoneGroup[0].Position = new Vector3(d4d.zoneGroup[3].Position.x + mapSize*2, 0, d4d.zoneGroup[3].Position.z + mapSize*2);
                    }
                }
                */

            #endregion Camera Clipping Events
        }
        #endregion
    }
}

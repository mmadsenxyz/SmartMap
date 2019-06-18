using System;
using System.Collections;
using System.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using Axiom.SceneManagers.Octree;
using Axiom.Configuration;
using Axiom.Core;
using Axiom.Core.InstanceGeometry;
using Axiom.Input;
using Axiom.Overlays;
using Axiom.Math;
using Axiom.Graphics;
using Axiom.Samples;
using Axiom.Platforms.OpenTK;
using MouseButtons = Axiom.Input.MouseButtons;

namespace SmartMap
{
    #region ConfigDialog

    class ConfigDialog
    {
        #region Types

        public enum DialogResult { Ok, Cancel }

        #endregion

        #region Fields
        private ConfigOption _renderSystems;
        private Axiom.Graphics.RenderSystem _currentSystem;
        private DialogResult _result;
        private ConfigOption _currentOption;
        private ArrayList _menuItems = new ArrayList();
        private ArrayList _options = new ArrayList();
        #endregion

        #region Constructor

        public ConfigDialog()
        {
            _currentSystem = Root.Instance.RenderSystems[0];
            _renderSystems = new ConfigOption("Render System", _currentSystem.Name, false);
            foreach (Axiom.Graphics.RenderSystem rs in Root.Instance.RenderSystems)
            {
                _renderSystems.PossibleValues.Add(_renderSystems.PossibleValues.Count, rs.ToString());
            }
            BuildOptions();
        }
        #endregion

        #region Methods 
        private void BuildOptions()
        {
            _options.Clear();
            _options.Add(_renderSystems);

            // Load Render Subsystem Options
            foreach (ConfigOption option in _currentSystem.ConfigOptions)
            {
                _options.Add(option);
            }
        }

        private void BuildMenu()
        {
            _menuItems.Clear();
            if (_currentOption == null)
                BuildMainMenu();
            else
                BuildOptionMenu();
        }

        private void BuildMainMenu()
        {
            for (int index = 0; index < _options.Count; index++)
            {
                _menuItems.Add(_options[index]);
            }
        }

        private void BuildOptionMenu()
        {
            for (int index = 0; index < _currentOption.PossibleValues.Count; index++)
            {
                _menuItems.Add(_currentOption.PossibleValues.Values[index].ToString());
            }
        }

        private void DisplayOptions()
        {
            Console.Clear();

            Console.WriteLine("Axiom Engine Configuration");
            Console.WriteLine("==========================");

            if (_currentOption != null)
            {
                Console.WriteLine("Available settings for {0}.\n", _currentOption.Name);
            }
            // Load Render Subsystem Options
            for (int index = 0; index < _menuItems.Count; index++)
            {
                System.Console.WriteLine("{0:D2}      | {1}", index, _menuItems[index].ToString());
            }

            if (_currentOption == null)
            {
                Console.WriteLine();
                Console.WriteLine("Enter  | Saves changes.");
                Console.WriteLine("ESC    | Exits.");
            }
            Console.Write("\nSelect option : ");
        }

        private int GetInput()
        {
            int number = 0;
            int keyCount = 2;

            while (keyCount > 0)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                if (key.Key == ConsoleKey.Escape)
                    return -1;
                if (key.Key == ConsoleKey.Enter)
                    return -2;

                if (key.Key.ToString().Substring(1).Length == 1 && key.Key.ToString().Substring(1).ToCharArray()[0] >= '0' && key.Key.ToString().Substring(1).ToCharArray()[0] <= '9')
                {
                    number += Int32.Parse(key.Key.ToString().Substring(1)) * ((int)System.Math.Pow(10, keyCount - 1));
                    keyCount--;
                }
            }
            return number;
        }

        private bool ProcessKey(int key)
        {
            if (_currentOption == null)
            {
                if (key == -1) //ESCAPE
                {
                    _result = DialogResult.Cancel;
                    return false;
                }
                if (key == -2)
                {
                    Root.Instance.RenderSystem = _currentSystem;

                    //for ( index = 0; index < _options.Count; index++ )
                    //{
                    //    ConfigOption opt = (ConfigOption)_options[ index ];
                    //    _currentSystem.ConfigOptions[ opt.Name ] = opt;
                    //}

                    _result = DialogResult.Ok;
                    return false;
                }

                if (key < _menuItems.Count)
                {
                    _currentOption = (ConfigOption)_menuItems[key];
                }
            }
            else
            {
                _currentOption.Value = _currentOption.PossibleValues.Values[key].ToString();

                if (_currentOption.Name == "Render System") // About to change Renderers
                {
                    _renderSystems = _currentOption;
                    _currentSystem = Root.Instance.RenderSystems[key];
                    BuildOptions();
                    _currentOption = null;

                    return true;
                }

                _currentOption = null;
            }
            return true;
        }

        public DialogResult ShowDialog()
        {
            bool _continue = false;
            do
            {
                BuildMenu();
                DisplayOptions();
                int value = GetInput();
                _continue = ProcessKey(value);
            } while (_continue);
            Console.Clear();
            return _result;
        }

        #endregion
    }

    #endregion
    
    /// <summary>
    ///     Base class for Axiom examples.
    /// </summary>
    public abstract class EngineSetup : SdkSample, IDisposable
    { 
        #region Protected Fields
        protected Root Root;
        protected Camera Camera;
        protected Frustum m_frustum;
        protected Frustum u_frustum;
        public SceneNode frustumNode;
        protected Viewport Viewport;
        protected RenderWindow Window;
        protected InputReader Input;
        protected TerrainSceneManager m_sceneManager;
        protected Vector3 cameraVector = Vector3.Zero;
        protected float cameraScale;
        protected bool showDebugOverlay = true;
        protected float statDelay = 0.0f;
        protected float debugTextDelay = 0.0f;
        protected string debugText = "";
        protected float toggleDelay = 0.0f;
        protected Vector3 camVelocity = Vector3.Zero;
        protected Vector3 camAccel = Vector3.Zero;
        protected Vector3 mouseRotateVector = Vector3.Zero;
        protected bool isUsingKbCameraLook = false;
        protected float camSpeed = 2.5f;
        protected int aniso = 1;
        protected TextureFiltering filtering = TextureFiltering.Bilinear;
        private const string CONFIG_FILE = @"EngineConfig.xml";
        #endregion Protected Fields
        
        #region Protected Methods
        
        /// <summary>
        /// Creates the Camera object for the scene.
        /// </summary>
        protected virtual void CreateCamera()
        { 
            // create a camera and initialize its position
            Camera = m_sceneManager.CreateCamera("MainCamera");
            Camera.Position = new Vector3(0, 0, 500);
            Camera.LookAt(new Vector3(0, 0, -300));

            // set the near clipping plane to be very close
            Camera.Near = 5;

            m_frustum = new Frustum();
            m_frustum.Near = 10;
            m_frustum.Far = 10000;
            m_frustum.FieldOfView = 110;
            m_frustum.IsVisible = true;
            m_frustum.Name = "Frustum";

            u_frustum = new Frustum();
            u_frustum.Near = 10;
            u_frustum.Far = 100;
            u_frustum.FieldOfView = 110;
            u_frustum.IsVisible = true;
            u_frustum.Name = "Frustum Underbrush";

            // create a node for the frustum and attach it
            frustumNode = m_sceneManager.RootSceneNode.CreateChildSceneNode(new Vector3(0, 2000, 2000), Quaternion.Identity);

            frustumNode.Yaw(0);
            frustumNode.Position = new Vector3(8000, -7000, 8000);

            frustumNode.AttachObject(m_frustum);
            frustumNode.AttachObject(u_frustum);
            //frustumNode.AttachObject(Camera);
        }

        /// <summary>
        ///    Shows the debug overlay, which displays performance statistics.
        /// </summary>
        protected void ShowDebugOverlay(bool show)
        {
            // gets a reference to the default overlay
            Overlay o = OverlayManager.Instance.GetByName("Core/DebugOverlay");

            if (o == null)
            {
                LogManager.Instance.Write(string.Format("Could not find overlay named '{0}'.", "Core/DebugOverlay"));
            }

            if (show)
            {
                o.Show();
            }
            else
            {
                o.Hide();
            }
        }

        /// <summary>
        /// Takes a screenshot... used where?
        /// </summary>
        /// <param name="fileName"></param>
        protected void TakeScreenshot(string fileName)
        {
            Window.WriteContentsToFile(fileName);
        }

        #endregion Protected Methods
        
        #region Protected Virtual Methods
        /// <summary>
        /// SceneManager (Axiom.Core.SceneManager)
        /// </summary>
        protected TerrainSceneManager SceneManager
        {
            get { return m_sceneManager; }
            set { m_sceneManager = value; }
        }

        /// <summary>
        /// Handles the selection of an appropriate scene manager
        /// </summary>
        protected virtual void ChooseSceneManager()
        {
            // Create a generic TerrainSceneManager
            m_sceneManager = (TerrainSceneManager)Root.CreateSceneManager("TerrainSceneManager", "TerrainInstance");
        }

        /// <summary>
        /// Handles creating the viewport for a window.
        /// </summary>
        protected virtual void CreateViewports()
        {
            Debug.Assert(Window != null, "Attempting to use a null RenderWindow.");

            // create a new viewport and set it's background color
            Viewport = Window.AddViewport(Camera, 0, 0, 1.0f, 1.0f, 100);
            Viewport.BackgroundColor = ColorEx.Black;
        }

        /// <summary>
        /// Establishes the Engine.FrameStarted/Engine.FrameEnded events
        /// </summary>
        protected virtual void SetupFrameHandlers()
        {
            // add event handlers for frame events
            Root.FrameStarted += new EventHandler<FrameEventArgs>(OnFrameStarted);
            Root.FrameEnded += new EventHandler<FrameEventArgs>(OnFrameEnded);
        }

        /// <summary>
        /// Handles the initialization and ordering of all of the various Create*,Setup*, etc
        /// methods in an ExampleApplication instance
        /// </summary>
        /// <returns>returns true on successful setup. Used by Run()</returns>
        protected virtual bool Setup()
        {
            // instantiate the Root singleton
            Root = new Root("AxiomEngine.log");
           
            // this actually loads the resource information
            // stored in EngineConfig.xml
            SetupResources();

            // This runs the ConfigDialog for per-session
            // variables like which renderer to use, fullscreen, etc
            if (!Configure())
            {
                // shutting right back down
                Root.Shutdown();

                return false;
            }

            // initialize a RenderWindow
            Window = Root.Instance.Initialize(true, "Axiom Engine Demo Window");

            // intialize resources .. need a window initialized before running this step
            ResourceGroupManager.Instance.InitializeAllResourceGroups();

            // establish the debug overlay
            ShowDebugOverlay(showDebugOverlay);

            // select a scene manager
            ChooseSceneManager();

            // set up the PlayerCamera
            CreateCamera();

            // set up the Viewports
            CreateViewports();

            // sets up input
            SetupInput();

            // call the overridden CreateScene method
            CreateScene();

            // set default mipmap level
            TextureManager.Instance.DefaultMipmapCount = 5;

            // sets up the FrameStarted/FrameEnded events
            SetupFrameHandlers();

            return true;
        }
        
        /// <summary>
        /// Handles the setup of the Input system for the ExampleApplication
        /// </summary>
        protected virtual void SetupInput()
        {
            // retreive and initialize the input system
            Input = PlatformManager.Instance.CreateInputReader();
            Input.Initialize(Window, true, true, false, false);

        }

        /// <summary>
        ///     Loads default resource configuration if one exists.
        /// </summary>
        protected virtual void SetupResources()
        {
            string resourceConfigPath = Path.GetFullPath(CONFIG_FILE);

            if (File.Exists(resourceConfigPath))
            {
                EngineConfig config = new EngineConfig();

                // load the config file
                // relative from the location of debug and releases executables
                config.ReadXml(CONFIG_FILE);

                // interrogate the available resource paths
                foreach (EngineConfig.FilePathRow row in config.FilePath)
                {
                    ResourceGroupManager.Instance.AddResourceLocation(row.src, row.type);
                }
            }
        }

        /// <summary>
        /// Attempts to get a session configuration.
        /// </summary>
        /// <returns>returns true on success</returns>
        protected virtual bool Configure()
        {
            ConfigDialog dlg = new ConfigDialog();
            ConfigDialog.DialogResult result = dlg.ShowDialog();
            if (result == ConfigDialog.DialogResult.Cancel)
            {
                Root.Instance.Dispose();
                Root = null;
                return false;
            }

            return true;
        }

        #endregion Protected Virtual Methods

        #region Protected Abstract Methods

        /// <summary>
        /// Create a scene. Must be implemented by an inheritor.
        /// </summary>
        protected abstract void CreateScene();

        #endregion Protected Abstract Methods

        #region Public Methods

        /// <summary>
        /// Begins the execution the application.
        /// </summary>
        public void Run()
        {
            try
            {
                if (Setup())
                {
                    // start the engines rendering loop
                    Root.StartRendering();
                }
            }
            catch (Exception ex)
            {
                // try logging the error here first, before Root is disposed of
                if (LogManager.Instance != null)
                {
                    LogManager.Instance.Write(LogManager.BuildExceptionString(ex));
                }
            }
        }

        public virtual void Dispose()
        {
            if (Root != null)
            {
                // remove event handlers
                Root.FrameStarted -= new EventHandler<FrameEventArgs>(OnFrameStarted);
                Root.FrameEnded -= new EventHandler<FrameEventArgs>(OnFrameEnded);

                //engine.Dispose();
            }
            m_sceneManager.RemoveAllCameras();
            m_sceneManager.RemoveCamera(Camera);
            Camera = null;
            Root.Instance.RenderSystem.DetachRenderTarget(Window);
            Window.Dispose();

            Root.Dispose();
        }

        #endregion Public Methods

        #region Event Handlers

        /// <summary>
        /// Event handler that is triggered once per frame after rendering is complete. Is configured
        /// to run by default is 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void OnFrameEnded(Object source, FrameEventArgs e)
        {

        }

        protected virtual void OnFrameStarted(Object source, FrameEventArgs e)
        {
            UpdateDebugOverlay(source, e);

            UpdateInput(source, e);
        }

        protected void UpdateInput(Object source, FrameEventArgs e)
        {

            Input.Capture();

            float scaleMove = 200 * e.TimeSinceLastFrame;

            // reset acceleration zero
            camAccel = Vector3.Zero;

            // set the scaling of camera motion
            cameraScale = 100 * e.TimeSinceLastFrame;

            float speed = 350 * e.TimeSinceLastFrame;
            float change = 15 * e.TimeSinceLastFrame;

            if (Input.IsKeyPressed(KeyCodes.Escape))
            {
                Root.Instance.QueueEndRendering();
                //return false;
            }
           
            /*if (Input.IsKeyPressed(KeyCodes.A))
            {
                camAccel.x = -0.5f;
            }

            if (Input.IsKeyPressed(KeyCodes.D))
            {
                camAccel.x = 0.5f;
            }

            if (Input.IsKeyPressed(KeyCodes.W))
            {
                camAccel.z = -1.0f;
            }

            if (Input.IsKeyPressed(KeyCodes.S))
            {
                camAccel.z = 1.0f;
            }

            //camAccel.y += (float)( input.RelativeMouseZ * 0.1f );

            // knock out the mouse stuff here
            isUsingKbCameraLook = false;
            if (Input.IsKeyPressed(KeyCodes.Left))
            {
                frustumNode.Yaw(cameraScale, TransformSpace.Parent);
                //Camera.Yaw(cameraScale);
                isUsingKbCameraLook = true;
            }

            if (Input.IsKeyPressed(KeyCodes.Right))
            {
                frustumNode.Yaw(-cameraScale, TransformSpace.Parent);
                //Camera.Yaw(-cameraScale);
                isUsingKbCameraLook = true;
            }

            if (Input.IsKeyPressed(KeyCodes.Up))
            {
                frustumNode.Pitch(cameraScale);
                //Camera.Pitch(cameraScale);
                isUsingKbCameraLook = true;
            }

            if (Input.IsKeyPressed(KeyCodes.Down))
            {
                frustumNode.Pitch(-cameraScale);
                //Camera.Pitch(-cameraScale);
                isUsingKbCameraLook = true;
            }

            // Mouse camera movement.
            if (!isUsingKbCameraLook)
            {
                mouseRotateVector = Vector3.Zero;
                mouseRotateVector.x += Input.RelativeMouseX * 0.13f;
                mouseRotateVector.y += Input.RelativeMouseY * 0.13f;
                frustumNode.Yaw(-mouseRotateVector.x, TransformSpace.Parent);
                frustumNode.Pitch(-mouseRotateVector.y);
                //Camera.Yaw(-mouseRotateVector.x);
                //Camera.Pitch(-mouseRotateVector.y);
            }
            isUsingKbCameraLook = false;
            */
            // subtract the time since last frame to delay specific key presses
            toggleDelay -= e.TimeSinceLastFrame;

            // toggle rendering mode
            if (Input.IsKeyPressed(KeyCodes.R) && toggleDelay < 0)
            {
                if (Camera.PolygonMode == PolygonMode.Points)
                {
                    Camera.PolygonMode = PolygonMode.Solid;
                }
                else if (Camera.PolygonMode == PolygonMode.Solid)
                {
                    Camera.PolygonMode = PolygonMode.Wireframe;
                }
                else
                {
                    Camera.PolygonMode = PolygonMode.Points;
                }

                Console.WriteLine("Rendering mode changed to '{0}'.", Camera.PolygonMode);

                toggleDelay = 1;
            }

            if (Input.IsKeyPressed(KeyCodes.T) && toggleDelay < 0)
            {
                // toggle the texture settings
                switch (filtering)
                {
                    case TextureFiltering.Bilinear:
                        filtering = TextureFiltering.Trilinear;
                        aniso = 1;
                        break;
                    case TextureFiltering.Trilinear:
                        filtering = TextureFiltering.Anisotropic;
                        aniso = 8;
                        break;
                    case TextureFiltering.Anisotropic:
                        filtering = TextureFiltering.Bilinear;
                        aniso = 1;
                        break;
                }

                Console.WriteLine("Texture Filtering changed to '{0}'.", filtering);

                // set the new default
                MaterialManager.Instance.SetDefaultTextureFiltering(filtering);
                MaterialManager.Instance.DefaultAnisotropy = aniso;

                toggleDelay = 1;
            }

            if (Input.IsKeyPressed(KeyCodes.P))
            {
                string[] temp = Directory.GetFiles(Environment.CurrentDirectory, "screenshot*.jpg");
                string fileName = string.Format("screenshot{0}.jpg", temp.Length + 1);

                TakeScreenshot(fileName);

                // show briefly on the screen
                debugText = string.Format("Wrote screenshot '{0}'.", fileName);

                // show for 2 seconds
                debugTextDelay = 2.0f;
            }

            if (Input.IsKeyPressed(KeyCodes.B))
            {
                m_sceneManager.ShowBoundingBoxes = !m_sceneManager.ShowBoundingBoxes;
            }

            if (Input.IsKeyPressed(KeyCodes.F))
            {
                // hide all overlays, includes ones besides the debug overlay
                Viewport.ShowOverlays = !Viewport.ShowOverlays;
            }

            //if ( !input.IsMousePressed( MouseButtons.Left ) )
            //{
            //    float cameraYaw = -input.RelativeMouseX * .13f;
            //    float cameraPitch = -input.RelativeMouseY * .13f;

            //    camera.Yaw( cameraYaw );
            //    camera.Pitch( cameraPitch );
            //}
            //else
            //{
            //    cameraVector.x += input.RelativeMouseX * 0.13f;
            //}

            camVelocity += (camAccel * scaleMove * camSpeed);

            // move the camera based on the accumulated movement vector
            //Camera.MoveRelative(camVelocity * e.TimeSinceLastFrame);
            // move in current body direction (not the goal direction)

            //this.frustumNode.Translate(camVelocity * e.TimeSinceLastFrame, TransformSpace.Local);

            // Now dampen the Velocity - only if user is not accelerating
            if (camAccel == Vector3.Zero)
            {
                camVelocity *= (1 - (6 * e.TimeSinceLastFrame));
            }
        }

        protected void UpdateDebugOverlay(object source, FrameEventArgs e)
        {
            OverlayElement element;

            // update performance stats once per second
            if (statDelay < 0.0f && showDebugOverlay)
            {
                // TODO: Replace with CEGUI
                element = OverlayManager.Instance.Elements.GetElement("Core/CurrFps");
                element.Text = string.Format("Current FPS: {0:#.00}", Root.Instance.CurrentFPS);

                element = OverlayManager.Instance.Elements.GetElement("Core/BestFps");
                element.Text = string.Format("Best FPS: {0:#.00}", Root.Instance.BestFPS);

                element = OverlayManager.Instance.Elements.GetElement("Core/WorstFps");
                element.Text = string.Format("Worst FPS: {0:#.00}", Root.Instance.WorstFPS);

                element = OverlayManager.Instance.Elements.GetElement("Core/AverageFps");
                element.Text = string.Format("Average FPS: {0:#.00}", Root.Instance.AverageFPS);

                element = OverlayManager.Instance.Elements.GetElement("Core/NumTris");
                element.Text = string.Format("Triangle Count: {0}", m_sceneManager.TargetRenderSystem.FacesRendered);

                statDelay = 1.0f;
            }
            else
            {
                statDelay -= e.TimeSinceLastFrame;
            }

            // turn off debug text when delay ends
            if (debugTextDelay < 0.0f)
            {
                debugTextDelay = 0.0f;
                debugText = "";
            }
            else if (debugTextDelay > 0.0f)
            {
                debugTextDelay -= e.TimeSinceLastFrame;
            }

            element = OverlayManager.Instance.Elements.GetElement("Core/DebugText");
            element.Text = debugText;
        }

        #endregion Event Handlers
    }
}



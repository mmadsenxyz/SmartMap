﻿#region Namespace Declarations

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

using Axiom.Configuration;
using Axiom.Core;
using Axiom.Input;
using Axiom.Overlays;
using Axiom.Math;
using Axiom.Graphics;
using MouseButtons = Axiom.Input.MouseButtons;
using Axiom.Collections;
using RolePlayingGame.GuiDANCE;
using Axiom.Utilities;

#endregion Namespace Declarations

namespace RolePlayingGame
{
    /// <summary>
    ///     Base class for Axiom examples.
    /// </summary>
    public abstract class Game : IDisposable
    {
        public Game(IntPtr targetHandle)
        {
            windowHandle = targetHandle;
        }

        #region Protected Fields

        public IntPtr windowHandle; 
        protected Root engine;
        protected Camera camera;
        protected Viewport viewport;
        protected SceneManager scene;
        protected RenderWindow window;
        protected InputReader input;
        protected Vector3 cameraVector = Vector3.Zero;
        protected float cameraScale;
        protected bool showDebugOverlay = true;
        protected float statDelay = 0.0f;
        protected float debugTextDelay = 0.0f;
        protected string debugText = "";
        protected float toggleDelay = 0.0f;
        protected Vector3 camVelocity = Vector3.Zero;
        protected Vector3 camAccel = Vector3.Zero;
        protected float camSpeed = 2.5f;
        protected int aniso = 1;
        protected TextureFiltering filtering = TextureFiltering.Bilinear;

        #endregion Protected Fields

        #region Protected Methods

        //protected bool Configure()
        //{
        //    // HACK: Temporary
        //    //RenderSystem renderSystem = Root.Instance.RenderSystems[ 0 ];
        //    //Root.Instance.RenderSystem = renderSystem;
        //    //EngineConfig.DisplayModeRow mode = renderSystem.ConfigOptions.DisplayMode[ 0 ];
        //    //mode.FullScreen = true;
        //    //mode.Selected = true;

        //    window = Root.Instance.Initialize( true, "Axiom Engine Window" );

        //    ShowDebugOverlay( showDebugOverlay );

        //    return true;
        //}

        protected virtual void CreateCamera()
        {
            // create a camera and initialize its position
            camera = scene.CreateCamera("MainCamera");
            camera.Position = new Vector3(0, 0, 500);
            camera.LookAt(new Vector3(0, 0, -300));

            // set the near clipping plane to be very close
            camera.Near = 5;
        }

        /// <summary>
        ///    Shows the debug overlay, which displays performance statistics.
        /// </summary>
        protected void ShowDebugOverlay(bool show)
        {
            // gets a reference to the default overlay
            Overlay o = OverlayManager.Instance.GetByName("GUI/DebugOverlay");

            if (o == null)
            {
                LogManager.Instance.Write(string.Format("Could not find overlay named '{0}'.", "GUI/DebugOverlay"));
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

        protected void TakeScreenshot(string fileName)
        {
            window.WriteContentsToFile(fileName);
        }

        #endregion Protected Methods

        #region Protected Virtual Methods

        protected virtual void ChooseSceneManager()
        {
            // Get the SceneManager, a generic one by default
            scene = engine.CreateSceneManager(SceneType.Generic, "GameSM");
            scene.ClearScene();
        }

        protected virtual void CreateViewports()
        {
            Debug.Assert(window != null, "Attempting to use a null RenderWindow.");
            // create a new viewport and set it's background color
            viewport = window.AddViewport(camera, 0, 0, 1.0f, 1.0f, 100);
            viewport.BackgroundColor = ColorEx.Black;
        }

        protected virtual bool Setup()
        {
            // instantiate the Root singleton
            //engine = new Root( "EngineConfig.xml", "AxiomEngine.log" );
            engine = Root.Instance;

            // add event handlers for frame events
            engine.FrameStarted += new EventHandler<FrameEventArgs>(OnFrameStarted);
            engine.FrameEnded += new EventHandler<FrameEventArgs>(OnFrameEnded);

            window = Root.Instance.Initialize(false, "Game Window");

            NamedParameterList windowParams = new NamedParameterList();
            windowParams.Add("externalWindowHandle", windowHandle);
            window = engine.CreateRenderWindow("Game Window", 1024, 768, false, windowParams);

            OnCreateWindow();

            GameWindowListener gwl = new GameWindowListener(window);
            WindowEventMonitor.Instance.RegisterListener(window, gwl);

            ResourceGroupManager.Instance.InitializeAllResourceGroups();

            ShowDebugOverlay(showDebugOverlay);

            ChooseSceneManager();
            CreateCamera();
            CreateViewports();

            // set default mipmap level
            TextureManager.Instance.DefaultMipmapCount = 5;

            // call the overridden CreateScene method
            CreateScene();

            // retreive and initialize the input system
            input = PlatformManager.Instance.CreateInputReader();
            input.Initialize(window, true, true, false, false);

            return true;
        }

        /// <summary>
        ///		Loads default resource configuration if one exists.
        /// </summary>
        //protected virtual void SetupResources()
        //{
        //    string resourceConfigPath = Path.GetFullPath( "EngineConfig.xml" );

        //    if ( File.Exists( resourceConfigPath ) )
        //    {
        //        EngineConfig config = new EngineConfig();

        //        // load the config file
        //        // relative from the location of debug and releases executables
        //        config.ReadXml( "EngineConfig.xml" );

        //        // interrogate the available resource paths
        //        foreach ( EngineConfig.FilePathRow row in config.FilePath )
        //        {
        //            ResourceManager.AddCommonArchive( row.src, row.type );
        //        }
        //    }
        //}

        #endregion Protected Virtual Methods

        #region Protected Abstract Methods

        /// <summary>
        /// 
        /// </summary>
        protected abstract void CreateScene();

        #endregion Protected Abstract Methods

        #region Public Methods

        public void Start()
        {
            try
            {
                if (Setup())
                {
                    // start the engines rendering loop
                    engine.StartRendering();
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

        public void Dispose()
        {
            if (engine != null)
            {
                // remove event handlers
                engine.FrameStarted -= new EventHandler<FrameEventArgs>(OnFrameStarted);
                engine.FrameEnded -= new EventHandler<FrameEventArgs>(OnFrameEnded);

                //engine.Dispose();
            }
            scene.RemoveAllCameras();
            scene.RemoveCamera(camera);
            camera = null;
            Root.Instance.RenderSystem.DetachRenderTarget(window);
            window.Dispose();

            engine.Dispose();
        }

        #endregion Public Methods

        #region Event Handlers

        protected virtual void OnFrameEnded(Object source, FrameEventArgs e)
        {
            //return true;
        }

        protected virtual void OnFrameStarted(Object source, FrameEventArgs e)
        {
            float scaleMove = 200 * e.TimeSinceLastFrame;

            // reset acceleration zero
            camAccel = Vector3.Zero;

            // set the scaling of camera motion
            cameraScale = 100 * e.TimeSinceLastFrame;

            // TODO: Move this into an event queueing mechanism that is processed every frame
            input.Capture();

            if (input.IsKeyPressed(KeyCodes.Escape))
            {
                Root.Instance.QueueEndRendering();
                //return false;
            }

            if (input.IsKeyPressed(KeyCodes.A))
            {
                camAccel.z = -0.5f;
            }

            if (input.IsKeyPressed(KeyCodes.D))
            {
                camAccel.z = 0.5f;
            }

            if (input.IsKeyPressed(KeyCodes.W))
            {
                camAccel.x = -1.0f;
            }

            if (input.IsKeyPressed(KeyCodes.S))
            {
                camAccel.x = 1.0f;
            }

            //camAccel.y += (float)( input.RelativeMouseZ * 0.1f );

            if (input.IsKeyPressed(KeyCodes.Left))
            {
                camera.Yaw(cameraScale);
            }

            if (input.IsKeyPressed(KeyCodes.Right))
            {
                camera.Yaw(-cameraScale);
            }

            if (input.IsKeyPressed(KeyCodes.Up))
            {
                camera.Pitch(cameraScale);
            }

            if (input.IsKeyPressed(KeyCodes.Down))
            {
                camera.Pitch(-cameraScale);
            }

            // subtract the time since last frame to delay specific key presses
            toggleDelay -= e.TimeSinceLastFrame;

            // toggle rendering mode
            if (input.IsKeyPressed(KeyCodes.R) && toggleDelay < 0)
            {
                if (camera.PolygonMode == PolygonMode.Points)
                {
                    camera.PolygonMode = PolygonMode.Solid;
                }
                else if (camera.PolygonMode == PolygonMode.Solid)
                {
                    camera.PolygonMode = PolygonMode.Wireframe;
                }
                else
                {
                    camera.PolygonMode = PolygonMode.Points;
                }

                SetDebugText(String.Format("Rendering mode changed to '{0}'.", camera.PolygonMode));

                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.T) && toggleDelay < 0)
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

                SetDebugText(String.Format("Texture Filtering changed to '{0}'.", filtering));

                // set the new default
                MaterialManager.Instance.SetDefaultTextureFiltering(filtering);
                MaterialManager.Instance.DefaultAnisotropy = aniso;

                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.P) && toggleDelay < 0)
            {
                string[] temp = Directory.GetFiles(Environment.CurrentDirectory, "screenshot*.jpg");
                string fileName = string.Format("screenshot{0}.jpg", temp.Length + 1);

                TakeScreenshot(fileName);

                // show on the screen for some seconds
                SetDebugText(string.Format("Wrote screenshot '{0}'.", fileName));

                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.B) && toggleDelay < 0)
            {
                scene.ShowBoundingBoxes = !scene.ShowBoundingBoxes;

                SetDebugText(String.Format("Bounding boxes {0}.", scene.ShowBoundingBoxes ? "visible" : "hidden"));

                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.F) && toggleDelay < 0)
            {
                // hide all overlays, includes ones besides the debug overlay
                viewport.ShowOverlays = !viewport.ShowOverlays;
                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.Comma) && toggleDelay < 0)
            {
                Root.Instance.MaxFramesPerSecond = 60;

                SetDebugText(String.Format("Limiting framerate to {0} FPS.", Root.Instance.MaxFramesPerSecond));

                toggleDelay = .3f;
            }

            if (input.IsKeyPressed(KeyCodes.Period) && toggleDelay < 0)
            {
                Root.Instance.MaxFramesPerSecond = 0;

                SetDebugText(String.Format("Framerate limit OFF.", Root.Instance.MaxFramesPerSecond));

                toggleDelay = .3f;
            }

            camVelocity += (camAccel * scaleMove * camSpeed);

            // move the camera based on the accumulated movement vector
            camera.Move(camVelocity * e.TimeSinceLastFrame);

            // Now dampen the Velocity - only if user is not accelerating
            if (camAccel == Vector3.Zero)
            {
                camVelocity *= (1 - (6 * e.TimeSinceLastFrame));
            }

            // update performance stats once per second
            if (statDelay < 0.0f && showDebugOverlay)
            {
                UpdateStats();
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

            OverlayElement element = OverlayManager.Instance.Elements.GetElement("Core/DebugText");
            element.Text = debugText;

            //return true;
        }

        protected void UpdateStats()
        {
            // TODO: Replace with CEGUI
            OverlayElement element = OverlayManager.Instance.Elements.GetElement("Core/CurrFps");
            element.Text = string.Format("Current FPS: {0:#.00}", Root.Instance.CurrentFPS);

            element = OverlayManager.Instance.Elements.GetElement("Core/BestFps");
            element.Text = string.Format("Best FPS: {0:#.00}", Root.Instance.BestFPS);

            element = OverlayManager.Instance.Elements.GetElement("Core/WorstFps");
            element.Text = string.Format("Worst FPS: {0:#.00}", Root.Instance.WorstFPS);

            element = OverlayManager.Instance.Elements.GetElement("Core/AverageFps");
            element.Text = string.Format("Average FPS: {0:#.00}", Root.Instance.AverageFPS);

            element = OverlayManager.Instance.Elements.GetElement("Core/NumTris");
            element.Text = string.Format("Triangle Count: {0}", scene.TargetRenderSystem.FacesRendered);
        }

        protected virtual void OnCreateWindow()
        {
        }

        /// <summary>
        /// Show a text message on screen for two seconds.
        /// </summary>
        /// <param name="text"></param>
        protected void SetDebugText(string text)
        {
            SetDebugText(text, 2.0f);
        }

        /// <summary>
        /// Show a text message on screen for the specified amount of time.
        /// </summary>
        /// <param name="text">Text to show</param>
        /// <param name="delay">Duration in seconds</param>
        protected void SetDebugText(string text, float delay)
        {
            debugText = text;
            debugTextDelay = delay;
        }

        #endregion Event Handlers
    }

    public class GameWindowListener : IWindowEventListener
    {
        private RenderWindow _mw;
        public GameWindowListener(RenderWindow mainWindow)
        {
            Contract.RequiresNotNull(mainWindow, "mainWindow");

            _mw = mainWindow;
        }

        /// <summary>
        /// Window has moved position
        /// </summary>
        /// <param name="rw">The RenderWindow which created this event</param>
        public void WindowMoved(RenderWindow rw)
        {
        }

        /// <summary>
        /// Window has resized
        /// </summary>
        /// <param name="rw">The RenderWindow which created this event</param>
        public void WindowResized(RenderWindow rw)
        {
        }

        /// <summary>
        /// Window has closed
        /// </summary>
        /// <param name="rw">The RenderWindow which created this event</param>
        public void WindowClosed(RenderWindow rw)
        {
            Contract.RequiresNotNull(rw, "RenderWindow");

            // Only do this for the Main Window
            if (rw == _mw)
            {
                Root.Instance.QueueEndRendering();
            }
        }

        /// <summary>
        /// Window lost/regained the focus
        /// </summary>
        /// <param name="rw">The RenderWindow which created this event</param>
        public void WindowFocusChange(RenderWindow rw)
        {
            Contract.RequiresNotNull(rw, "RenderWindow");

            if (!rw.IsActive)
                rw.IsActive = true;
        }

    }
}


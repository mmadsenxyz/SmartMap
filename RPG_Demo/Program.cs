using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Windows.Forms;

using Axiom.Core;
using Axiom.Graphics;
using Axiom.Configuration;
using Axiom.Collections;

using RolePlayingGame.TheSaga;
using RolePlayingGame.Configuration;

namespace RolePlayingGame
{
    public class Program : IDisposable
    {
        protected const string CONFIG_FILE = @"EngineConfig.xml";

        private Root engine;

        private bool _configure()
        {
            // instantiate the Root singleton
            engine = new Root("Engine.log");

            _setupResources();

            //foreach (RenderSystem renderSystem in Root.Instance.RenderSystems)
            //{
            //    cboRenderSystems.Items.Add(renderSystem);
            //}

            Root.Instance.RenderSystem = Root.Instance.RenderSystems["Direct3D9"]; //Set as DirectX
            Root.Instance.RenderSystem.ConfigOptions["Video Mode"].Value = "1024 x 768 @ 32-bit colour";

            //RenderSystem system = Root.Instance.RenderSystem;

            //foreach (ConfigOption opt in system.ConfigOptions.Values)
            //{
            //    system.ConfigOptions[opt.Name] = opt;
            //}

            return true;
        }

        /// <summary>
        ///		Loads default resource configuration if one exists.
        /// </summary>
        private void _setupResources()
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

        public void Run()
        {
            try
            {
                if (_configure())
                {
                    GameForm form = new GameForm();
                    form.Show();
                    using (TheSagaDemo game = new TheSagaDemo(form.RenderBox))
                    {
                        game.Start();
                    }
                }
            }
            catch (Exception caughtException)
            {
                LogManager.Instance.Write(BuildExceptionString(caughtException));
            }
        }

        #region Main
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                using (Program main = new Program())
                {
                    main.Run();//show and start rendering
                }//dispose of it when done
            }
            catch (Exception ex)
            {
                Console.WriteLine(BuildExceptionString(ex));
                Console.WriteLine("An exception has occurred.  Press enter to continue...");
                Console.ReadLine();
            }

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new GameForm());
        }

        private static string BuildExceptionString(Exception exception)
        {
            string errMessage = string.Empty;

            errMessage += exception.Message + Environment.NewLine + exception.StackTrace;

            while (exception.InnerException != null)
            {
                errMessage += BuildInnerExceptionString(exception.InnerException);
                exception = exception.InnerException;
            }

            return errMessage;
        }

        private static string BuildInnerExceptionString(Exception innerException)
        {
            string errMessage = string.Empty;

            errMessage += Environment.NewLine + " InnerException ";
            errMessage += Environment.NewLine + innerException.Message + Environment.NewLine + innerException.StackTrace;

            return errMessage;
        } 
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        #endregion
    }
}

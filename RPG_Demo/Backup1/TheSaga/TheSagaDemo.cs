using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Axiom.Core;
using Axiom.Math;
using Axiom.Overlays;
using Axiom.Overlays.Elements;
using RolePlayingGame.GuiDANCE;
using Axiom.Graphics;

namespace RolePlayingGame.TheSaga
{
    public enum GameStates
    {
        Menu,
        Game,
    }
    class TheSagaDemo : Game
    {
        private Overlay gameOverlay;
        private GuiPanel panelSkills;
        private GuiPanel panelCharacters;
        private GuiPanelBorder panelTooltip;
        private GuiCursor cursor;
        private GuiButtonRollover buttonMenuOptions;
        private GuiButtonRollover buttonMenuInventory;
        private GuiButtonRollover buttonMenuMap;
        private GuiButtonRollover buttonSkillHandDefault;
        private GuiButtonRollover buttonSkillFootDefault;
        private GuiButtonRollover buttonSkillAttackDefault;
        private GuiButtonRollover buttonSkillDefendDefault;
        private GuiButtonRollover buttonSkillTalkDefault;
        private GuiButtonRadiobox buttonStatDefault;
        private GuiButtonRadiobox buttonStat01;
        private GuiButtonRadiobox buttonStat02;
        private GuiButtonRadiobox buttonStat03;
        private GuiButtonRadiobox buttonStat04;

        public TheSagaDemo(GuiRenderBox target)
            : base(target.Handle)
        {
            GuiBase.RenderBox = target;
        }

        private GameStates gameState = GameStates.Game;

        protected override void OnCreateWindow()
        {
            GuiBase.RenderWindow = window;
        }
        protected override void CreateScene()
        {
            gameOverlay = OverlayManager.Instance.GetByName("GUI/GameOverlay");
            if (gameOverlay == null)
            {
                LogManager.Instance.Write(string.Format("Could not find overlay named '{0}'.", "GUI/GameOverlay"));
            }
            else
            {
                List<string> subCursorList = new List<string>();
                subCursorList.Add("GUI/CursorFree");
                subCursorList.Add("GUI/CursorOver");

                cursor = new GuiCursor(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/Cursor"),
                    subCursorList,
                    0
                );

                buttonMenuOptions = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonMenuOptions"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonMenu")
                );
                buttonMenuOptions.OnMouseEnter = OnMouseEnterToMenuButton;
                buttonMenuOptions.OnMouseLeave = OnMouseLeaveFromMenuButton;

                buttonMenuInventory = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonMenuInventory"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonMenu")
                );
                buttonMenuInventory.OnMouseEnter = OnMouseEnterToMenuButton;
                buttonMenuInventory.OnMouseLeave = OnMouseLeaveFromMenuButton;

                buttonMenuMap = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonMenuMap"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonMenu")
                );
                buttonMenuMap.OnMouseEnter = OnMouseEnterToMenuButton;
                buttonMenuMap.OnMouseLeave = OnMouseLeaveFromMenuButton;

                buttonSkillHandDefault = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonSkillHandDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonSkills")
                );
                buttonSkillHandDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonSkillHandDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonSkillFootDefault = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonSkillFootDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonSkills")
                );
                buttonSkillFootDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonSkillFootDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonSkillAttackDefault = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonSkillAttackDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonSkills")
                );
                buttonSkillAttackDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonSkillAttackDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonSkillDefendDefault = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonSkillDefendDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonSkills")
                );
                buttonSkillDefendDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonSkillDefendDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonSkillTalkDefault = new GuiButtonRollover(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonSkillTalkDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonSkills")
                );
                buttonSkillTalkDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonSkillTalkDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonStatDefault = new GuiButtonRadiobox(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonStatDefault"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonStat")
                );
                buttonStatDefault.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonStatDefault.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonStat01 = new GuiButtonRadiobox(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonStatStrength"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonStat")
                );
                buttonStat01.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonStat01.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonStat02 = new GuiButtonRadiobox(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonStatVitality"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonStat")
                );
                buttonStat02.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonStat02.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonStat03 = new GuiButtonRadiobox(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonStatAgility"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonStat")
                );
                buttonStat03.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonStat03.OnMouseLeave = OnMouseLeaveFromSkillButton;

                buttonStat04 = new GuiButtonRadiobox(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/ButtonStatCharm"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/SelectionButtonStat")
                );
                buttonStat04.OnMouseEnter = OnMouseEnterToSkillButton;
                buttonStat04.OnMouseLeave = OnMouseLeaveFromSkillButton;

                panelSkills = new GuiPanel(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelSkills")
                );

                panelCharacters = new GuiPanel(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelCharacters")
                );

                panelTooltip = new GuiPanelBorder(
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipCenter"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipTopLeft"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipTop"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipTopRight"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipLeft"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipRight"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipBottomLeft"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipBottom"),
                    (Panel)OverlayManager.Instance.Elements.GetElement("GUI/PanelTooltipBottomRight"),
                    (TextArea)OverlayManager.Instance.Elements.GetElement("GUI/TextTooltipHeader")
                );
                panelTooltip.Visibility = false;

                panelCharacters.Components.Add(buttonMenuOptions);
                panelCharacters.Components.Add(buttonMenuInventory);
                panelCharacters.Components.Add(buttonMenuMap);
                panelSkills.Components.Add(buttonSkillHandDefault);
                panelSkills.Components.Add(buttonSkillFootDefault);
                panelSkills.Components.Add(buttonSkillAttackDefault);
                panelSkills.Components.Add(buttonSkillDefendDefault);
                panelSkills.Components.Add(buttonSkillTalkDefault);
                panelSkills.Components.Add(buttonStatDefault);
                panelSkills.Components.Add(buttonStat01);
                panelSkills.Components.Add(buttonStat02);
                panelSkills.Components.Add(buttonStat03);
                panelSkills.Components.Add(buttonStat04);

                GuiBase.Cursor = cursor;
                GuiBase.Panels.Add(panelSkills);
                GuiBase.Panels.Add(panelCharacters);
                GuiBase.Panels.Add(panelTooltip);

                panelTooltip.Resize(128, 128);
                panelTooltip.Move(-145, -264);
            }



            //SceneNode node = scene.RootSceneNode.CreateChildSceneNode();
            //SceneNode sphNode = node.CreateChildSceneNode();

            //sphNode.Position = new Vector3(0, 0, 0);
            //Entity sphere = scene.CreateEntity("Sphere", PrefabEntity.Sphere);
            //sphere.MaterialName = "RPG/Floor/Indoor/Wood01";

            //sphNode.AttachObject(sphere);

            //Light light = scene.CreateLight("Light01");
            //light.Type = Axiom.Graphics.LightType.Directional;
            //light.Direction = new Vector3(-1.0f, -1.0f, -1.0f);
            //light.Diffuse = new ColorEx(1.0f, 1.0f, 1.0f);

            //SceneNode lightNode = scene.RootSceneNode.CreateChildSceneNode();
            //lightNode.AttachObject(light);
            //lightNode.Position = new Vector3(15.0f, 15.0f, 15.0f);

            //Mesh mesh01 = MeshManager.Instance.Load("interior_wall_window_01.mesh", ResourceGroupManager.DefaultResourceGroupName);

            //SceneNode node01 = scene.RootSceneNode.CreateChildSceneNode();
            //Entity wall01 = scene.CreateEntity("wall01", "interior_wall_window_01.mesh");
            //node01.AttachObject(wall01);
            //node01.Translate(new Vector3(0, 0, 4));
            ////node01.Yaw(90);

            //Mesh mesh2 = MeshManager.Instance.Load("interior_wall_edge_01.mesh", ResourceGroupManager.DefaultResourceGroupName);

            //SceneNode node02 = scene.RootSceneNode.CreateChildSceneNode();
            //Entity wall02 = scene.CreateEntity("wall02", "interior_wall_edge_01.mesh");
            ////athene.MaterialName = atheneMaterials[currentAtheneMaterial];
            //node02.AttachObject(wall02);
            //node02.Translate(new Vector3(0, 0, 0));
            ////node02.Yaw(90);

            Mesh meshFloor03 = MeshManager.Instance.Load("saga_house01_floor03.mesh", ResourceGroupManager.DefaultResourceGroupName);

            SceneNode node01 = scene.RootSceneNode.CreateChildSceneNode();
            Entity entityFloor03 = scene.CreateEntity("floor03", "saga_house01_floor03.mesh");
            node01.AttachObject(entityFloor03);
            //node01.Translate(new Vector3(0, 0, 4));
            //node01.Yaw(90);
        }

        protected override void CreateCamera()
        {
            // create a camera and initialize its position
            camera = scene.CreateCamera("MainCamera");
            camera.Position = new Vector3(50, 50, 50);
            camera.LookAt(new Vector3(-30, -30, -30));

            //camera.ProjectionType = Axiom.Graphics.Projection.Orthographic;
            // set the near clipping plane to be very close
            camera.Near = 5f;
            camera.Far = 20000f;


            //camera.ProjectionType = Projection.Orthographic;
            //camera.Far = 2000f;
            //camera.Near = 50f;
            //camera.FieldOfView = 0f;
            //camera.FixedYawAxis = Vector3.Zero;
            //camera.Rotate(Vector3.UnitX, 90f);
            //camera.LookAt(Vector3.Zero);
            //camera.AutoAspectRatio = true;
        }
        protected override bool OnFrameStarted(object source, FrameEventArgs e)
        {
            bool result = base.OnFrameStarted(source, e);
            GuiBase.OnFrameStarted();
            debugText = "Role Playing Game Demo";
            ShowOverlay(gameState);

            switch (gameState)
            {
                case GameStates.Menu:
                    {
                        break;
                    }
                case GameStates.Game:
                    {

                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return result;
        }

        protected void ShowOverlay(GameStates state)
        {
            switch (gameState)
            {
                case GameStates.Menu:
                    {
                        gameOverlay.Hide();
                        break;
                    }
                case GameStates.Game:
                    {
                        gameOverlay.Show();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void OnMouseEnterToSkillButton(GuiComponent button)
        {
            panelTooltip.Visibility = true;
            cursor.SubCursorIndex = 1; //Cursor Over
        }
        private void OnMouseLeaveFromSkillButton(GuiComponent button)
        {
            if (IsMouseFocused(button, panelSkills))
            {
                panelTooltip.Visibility = false;
                cursor.SubCursorIndex = 0; //Cursor Free
            }
        }

        private void OnMouseEnterToMenuButton(GuiComponent button)
        {
            cursor.SubCursorIndex = 1; //Cursor Over
        }
        private void OnMouseLeaveFromMenuButton(GuiComponent button)
        {
            if (IsMouseFocused(button, panelCharacters))
            {
                cursor.SubCursorIndex = 0; //Cursor Free
            }
        }

        private bool IsMouseFocused(GuiComponent button, GuiPanel panel)
        {
            //This is a fix that occurs on continious move from a button to another on reveresed index
            //TODO : Fix it on GuiDANCE library
            for (int index = 0; index < panel.Components.Count; index++)
            {
                GuiComponent component = panel.Components[index];
                if (component.Focus == true)
                {
                    if (component.Name != button.Name)
                    {
                        return false;
                    }
                }
            }
            //End of fix
            return true;
        }
    }
}

namespace RolePlayingGame.WorldEditor
{
    partial class FormGridBasedLevelEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGrid = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectionModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGridsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutLevelEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTerrain = new System.Windows.Forms.TabPage();
            this.tableLayoutPanelTerrain = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTerrainButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAddTemplate = new System.Windows.Forms.Button();
            this.buttonAddLibrary = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
            this.tabObstacle = new System.Windows.Forms.TabPage();
            this.tabInteractive = new System.Windows.Forms.TabPage();
            this.tabParticle = new System.Windows.Forms.TabPage();
            this.tabLight = new System.Windows.Forms.TabPage();
            this.tabSound = new System.Windows.Forms.TabPage();
            this.toolStripOperations = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSaveLevel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCut = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRedo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.gridBasedViewer1 = new RolePlayingGame.WorldEditor.GridBasedViewer();
            this.statusStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStripContainer.ContentPanel.SuspendLayout();
            this.toolStripContainer.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer.SuspendLayout();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabTerrain.SuspendLayout();
            this.tableLayoutPanelTerrain.SuspendLayout();
            this.tableLayoutPanelTerrainButtons.SuspendLayout();
            this.toolStripOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBasedViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGrid});
            this.statusStrip1.Location = new System.Drawing.Point(0, 347);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(668, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGrid
            // 
            this.toolStripStatusLabelGrid.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabelGrid.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconPropertyGrid;
            this.toolStripStatusLabelGrid.Name = "toolStripStatusLabelGrid";
            this.toolStripStatusLabelGrid.Size = new System.Drawing.Size(69, 17);
            this.toolStripStatusLabelGrid.Text = "Grid : 0,0";
            // 
            // menuStrip
            // 
            this.menuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(668, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLevelToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveLevelToolStripMenuItem
            // 
            this.saveLevelToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.saveLevelToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconSave;
            this.saveLevelToolStripMenuItem.Name = "saveLevelToolStripMenuItem";
            this.saveLevelToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.saveLevelToolStripMenuItem.Text = "Save Level";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.undoToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationUndo;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.redoToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationRedo;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.cutToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationCut;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.copyToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationCopy;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.pasteToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationPaste;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.deleteToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationDelete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectionModeToolStripMenuItem,
            this.moveModeToolStripMenuItem,
            this.showGridsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // selectionModeToolStripMenuItem
            // 
            this.selectionModeToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.selectionModeToolStripMenuItem.CheckOnClick = true;
            this.selectionModeToolStripMenuItem.Name = "selectionModeToolStripMenuItem";
            this.selectionModeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.selectionModeToolStripMenuItem.Text = "Selection Mode";
            this.selectionModeToolStripMenuItem.Click += new System.EventHandler(this.selectionModeToolStripMenuItem_Click);
            // 
            // moveModeToolStripMenuItem
            // 
            this.moveModeToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.moveModeToolStripMenuItem.Checked = true;
            this.moveModeToolStripMenuItem.CheckOnClick = true;
            this.moveModeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.moveModeToolStripMenuItem.Name = "moveModeToolStripMenuItem";
            this.moveModeToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.moveModeToolStripMenuItem.Text = "Move Mode";
            this.moveModeToolStripMenuItem.Click += new System.EventHandler(this.moveModeToolStripMenuItem_Click);
            // 
            // showGridsToolStripMenuItem
            // 
            this.showGridsToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.showGridsToolStripMenuItem.Checked = true;
            this.showGridsToolStripMenuItem.CheckOnClick = true;
            this.showGridsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGridsToolStripMenuItem.Name = "showGridsToolStripMenuItem";
            this.showGridsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.showGridsToolStripMenuItem.Text = "Show Grids";
            this.showGridsToolStripMenuItem.Click += new System.EventHandler(this.showGridsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.aboutLevelEditorToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.contentsToolStripMenuItem.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconContent;
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.contentsToolStripMenuItem.Text = "Contents";
            // 
            // aboutLevelEditorToolStripMenuItem
            // 
            this.aboutLevelEditorToolStripMenuItem.BackgroundImage = global::RolePlayingGame.WorldEditor.Properties.Resources.MenuContext;
            this.aboutLevelEditorToolStripMenuItem.Name = "aboutLevelEditorToolStripMenuItem";
            this.aboutLevelEditorToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.aboutLevelEditorToolStripMenuItem.Text = "About Level Editor";
            // 
            // toolStripContainer
            // 
            // 
            // toolStripContainer.ContentPanel
            // 
            this.toolStripContainer.ContentPanel.Controls.Add(this.splitMain);
            this.toolStripContainer.ContentPanel.Size = new System.Drawing.Size(668, 298);
            this.toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer.Name = "toolStripContainer";
            this.toolStripContainer.Size = new System.Drawing.Size(668, 323);
            this.toolStripContainer.TabIndex = 2;
            this.toolStripContainer.Text = "toolStripContainer1";
            // 
            // toolStripContainer.TopToolStripPanel
            // 
            this.toolStripContainer.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer.TopToolStripPanel.Controls.Add(this.toolStripOperations);
            // 
            // splitMain
            // 
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitMain.IsSplitterFixed = true;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.tabControl1);
            this.splitMain.Panel1MinSize = 200;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.gridBasedViewer1);
            this.splitMain.Panel2MinSize = 100;
            this.splitMain.Size = new System.Drawing.Size(668, 298);
            this.splitMain.SplitterDistance = 200;
            this.splitMain.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTerrain);
            this.tabControl1.Controls.Add(this.tabObstacle);
            this.tabControl1.Controls.Add(this.tabInteractive);
            this.tabControl1.Controls.Add(this.tabParticle);
            this.tabControl1.Controls.Add(this.tabLight);
            this.tabControl1.Controls.Add(this.tabSound);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(200, 298);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 0;
            // 
            // tabTerrain
            // 
            this.tabTerrain.Controls.Add(this.tableLayoutPanelTerrain);
            this.tabTerrain.Location = new System.Drawing.Point(4, 40);
            this.tabTerrain.Name = "tabTerrain";
            this.tabTerrain.Padding = new System.Windows.Forms.Padding(3);
            this.tabTerrain.Size = new System.Drawing.Size(192, 254);
            this.tabTerrain.TabIndex = 1;
            this.tabTerrain.Text = "Terrain";
            this.tabTerrain.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelTerrain
            // 
            this.tableLayoutPanelTerrain.ColumnCount = 1;
            this.tableLayoutPanelTerrain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTerrain.Controls.Add(this.tableLayoutPanelTerrainButtons, 0, 1);
            this.tableLayoutPanelTerrain.Controls.Add(this.listView1, 0, 0);
            this.tableLayoutPanelTerrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTerrain.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanelTerrain.Name = "tableLayoutPanelTerrain";
            this.tableLayoutPanelTerrain.RowCount = 2;
            this.tableLayoutPanelTerrain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTerrain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelTerrain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTerrain.Size = new System.Drawing.Size(186, 248);
            this.tableLayoutPanelTerrain.TabIndex = 0;
            // 
            // tableLayoutPanelTerrainButtons
            // 
            this.tableLayoutPanelTerrainButtons.ColumnCount = 4;
            this.tableLayoutPanelTerrainButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelTerrainButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTerrainButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelTerrainButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanelTerrainButtons.Controls.Add(this.buttonAddTemplate, 2, 0);
            this.tableLayoutPanelTerrainButtons.Controls.Add(this.buttonAddLibrary, 3, 0);
            this.tableLayoutPanelTerrainButtons.Controls.Add(this.buttonDelete, 0, 0);
            this.tableLayoutPanelTerrainButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTerrainButtons.Location = new System.Drawing.Point(0, 212);
            this.tableLayoutPanelTerrainButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTerrainButtons.Name = "tableLayoutPanelTerrainButtons";
            this.tableLayoutPanelTerrainButtons.RowCount = 1;
            this.tableLayoutPanelTerrainButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTerrainButtons.Size = new System.Drawing.Size(186, 36);
            this.tableLayoutPanelTerrainButtons.TabIndex = 0;
            // 
            // buttonAddTemplate
            // 
            this.buttonAddTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddTemplate.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconAddTemplate;
            this.buttonAddTemplate.Location = new System.Drawing.Point(117, 3);
            this.buttonAddTemplate.Name = "buttonAddTemplate";
            this.buttonAddTemplate.Size = new System.Drawing.Size(30, 30);
            this.buttonAddTemplate.TabIndex = 0;
            this.buttonAddTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonAddLibrary
            // 
            this.buttonAddLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonAddLibrary.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconAddLibrary;
            this.buttonAddLibrary.Location = new System.Drawing.Point(153, 3);
            this.buttonAddLibrary.Name = "buttonAddLibrary";
            this.buttonAddLibrary.Size = new System.Drawing.Size(30, 30);
            this.buttonAddLibrary.TabIndex = 1;
            this.buttonAddLibrary.UseVisualStyleBackColor = true;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonDelete.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationDelete;
            this.buttonDelete.Location = new System.Drawing.Point(3, 3);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(30, 30);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderName});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(3, 3);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(180, 206);
            this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listView1.TabIndex = 1;
            this.listView1.TileSize = new System.Drawing.Size(64, 64);
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Template Name";
            this.columnHeaderName.Width = 170;
            // 
            // tabObstacle
            // 
            this.tabObstacle.Location = new System.Drawing.Point(4, 40);
            this.tabObstacle.Name = "tabObstacle";
            this.tabObstacle.Size = new System.Drawing.Size(192, 254);
            this.tabObstacle.TabIndex = 2;
            this.tabObstacle.Text = "Obstacle";
            this.tabObstacle.UseVisualStyleBackColor = true;
            // 
            // tabInteractive
            // 
            this.tabInteractive.Location = new System.Drawing.Point(4, 40);
            this.tabInteractive.Name = "tabInteractive";
            this.tabInteractive.Size = new System.Drawing.Size(192, 254);
            this.tabInteractive.TabIndex = 6;
            this.tabInteractive.Text = "Interactive";
            this.tabInteractive.UseVisualStyleBackColor = true;
            // 
            // tabParticle
            // 
            this.tabParticle.Location = new System.Drawing.Point(4, 40);
            this.tabParticle.Name = "tabParticle";
            this.tabParticle.Size = new System.Drawing.Size(192, 254);
            this.tabParticle.TabIndex = 4;
            this.tabParticle.Text = "Particle";
            this.tabParticle.UseVisualStyleBackColor = true;
            // 
            // tabLight
            // 
            this.tabLight.Location = new System.Drawing.Point(4, 40);
            this.tabLight.Name = "tabLight";
            this.tabLight.Size = new System.Drawing.Size(192, 254);
            this.tabLight.TabIndex = 3;
            this.tabLight.Text = "Light";
            this.tabLight.UseVisualStyleBackColor = true;
            // 
            // tabSound
            // 
            this.tabSound.Location = new System.Drawing.Point(4, 40);
            this.tabSound.Name = "tabSound";
            this.tabSound.Size = new System.Drawing.Size(192, 254);
            this.tabSound.TabIndex = 5;
            this.tabSound.Text = "Sound";
            this.tabSound.UseVisualStyleBackColor = true;
            // 
            // toolStripOperations
            // 
            this.toolStripOperations.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripOperations.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSaveLevel,
            this.toolStripSeparator1,
            this.toolStripButtonCut,
            this.toolStripButtonCopy,
            this.toolStripButtonPaste,
            this.toolStripSeparator2,
            this.toolStripButtonUndo,
            this.toolStripButtonRedo,
            this.toolStripSeparator3,
            this.toolStripButtonSelect,
            this.toolStripButtonMove,
            this.toolStripSeparator4});
            this.toolStripOperations.Location = new System.Drawing.Point(0, 0);
            this.toolStripOperations.Name = "toolStripOperations";
            this.toolStripOperations.Size = new System.Drawing.Size(668, 25);
            this.toolStripOperations.Stretch = true;
            this.toolStripOperations.TabIndex = 0;
            // 
            // toolStripButtonSaveLevel
            // 
            this.toolStripButtonSaveLevel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSaveLevel.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconSave;
            this.toolStripButtonSaveLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveLevel.Name = "toolStripButtonSaveLevel";
            this.toolStripButtonSaveLevel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSaveLevel.Text = "Save Level";
            this.toolStripButtonSaveLevel.ToolTipText = "Save Level (Ctrl + S)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonCut
            // 
            this.toolStripButtonCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCut.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationCut;
            this.toolStripButtonCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCut.Name = "toolStripButtonCut";
            this.toolStripButtonCut.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCut.Text = "Cut";
            this.toolStripButtonCut.ToolTipText = "Cut (Ctrl + X)";
            this.toolStripButtonCut.Click += new System.EventHandler(this.toolStripButtonCut_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonCopy.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationCopy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonCopy.Text = "Copy";
            this.toolStripButtonCopy.ToolTipText = "Copy (Ctrl + C)";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonPaste
            // 
            this.toolStripButtonPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonPaste.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationPaste;
            this.toolStripButtonPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPaste.Name = "toolStripButtonPaste";
            this.toolStripButtonPaste.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonPaste.Text = "Paste";
            this.toolStripButtonPaste.ToolTipText = "Paste (Ctrl + V)";
            this.toolStripButtonPaste.Click += new System.EventHandler(this.toolStripButtonPaste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonUndo
            // 
            this.toolStripButtonUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUndo.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationUndo;
            this.toolStripButtonUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUndo.Name = "toolStripButtonUndo";
            this.toolStripButtonUndo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUndo.Text = "Undo";
            this.toolStripButtonUndo.ToolTipText = "Undo (Ctrl + Z)";
            // 
            // toolStripButtonRedo
            // 
            this.toolStripButtonRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRedo.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.IconOperationRedo;
            this.toolStripButtonRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRedo.Name = "toolStripButtonRedo";
            this.toolStripButtonRedo.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRedo.Text = "Redo";
            this.toolStripButtonRedo.ToolTipText = "Redo (Ctrl + Y)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSelect.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.CursorSelect;
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSelect.Text = "Selection Mode";
            this.toolStripButtonSelect.ToolTipText = "Selection Mode";
            this.toolStripButtonSelect.Click += new System.EventHandler(this.toolStripButtonSelect_Click);
            // 
            // toolStripButtonMove
            // 
            this.toolStripButtonMove.BackColor = System.Drawing.Color.DarkGray;
            this.toolStripButtonMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMove.Image = global::RolePlayingGame.WorldEditor.Properties.Resources.CursorGrab;
            this.toolStripButtonMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMove.Name = "toolStripButtonMove";
            this.toolStripButtonMove.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMove.Text = "Move Mode";
            this.toolStripButtonMove.Click += new System.EventHandler(this.toolStripButtonMove_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // gridBasedViewer1
            // 
            this.gridBasedViewer1.BackColor = System.Drawing.Color.Black;
            this.gridBasedViewer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridBasedViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBasedViewer1.GridAxisColor = System.Drawing.Color.Gray;
            this.gridBasedViewer1.GridAxisWidth = 3F;
            this.gridBasedViewer1.GridHeight = 64;
            this.gridBasedViewer1.GridLineColor = System.Drawing.SystemColors.ControlDarkDark;
            this.gridBasedViewer1.GridLineWidth = 1F;
            this.gridBasedViewer1.GridWidth = 64;
            this.gridBasedViewer1.Location = new System.Drawing.Point(0, 0);
            this.gridBasedViewer1.MouseMode = RolePlayingGame.WorldEditor.GridBasedViewer.MouseModes.FreeToMove;
            this.gridBasedViewer1.Name = "gridBasedViewer1";
            this.gridBasedViewer1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.gridBasedViewer1.ShowGrids = true;
            this.gridBasedViewer1.Size = new System.Drawing.Size(464, 298);
            this.gridBasedViewer1.TabIndex = 0;
            this.gridBasedViewer1.TabStop = false;
            // 
            // FormGridBasedLevelEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(668, 369);
            this.Controls.Add(this.toolStripContainer);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormGridBasedLevelEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Level Editor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStripContainer.ContentPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer.TopToolStripPanel.PerformLayout();
            this.toolStripContainer.ResumeLayout(false);
            this.toolStripContainer.PerformLayout();
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            this.splitMain.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabTerrain.ResumeLayout(false);
            this.tableLayoutPanelTerrain.ResumeLayout(false);
            this.tableLayoutPanelTerrainButtons.ResumeLayout(false);
            this.toolStripOperations.ResumeLayout(false);
            this.toolStripOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBasedViewer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer;
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTerrain;
        private System.Windows.Forms.TabPage tabObstacle;
        private System.Windows.Forms.TabPage tabParticle;
        private System.Windows.Forms.TabPage tabLight;
        private System.Windows.Forms.TabPage tabSound;
        private System.Windows.Forms.TabPage tabInteractive;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTerrain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTerrainButtons;
        private System.Windows.Forms.Button buttonAddTemplate;
        private System.Windows.Forms.Button buttonAddLibrary;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLevelToolStripMenuItem;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ToolStripMenuItem aboutLevelEditorToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStripOperations;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonCut;
        private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripButton toolStripButtonPaste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonUndo;
        private System.Windows.Forms.ToolStripButton toolStripButtonRedo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGrid;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectionModeToolStripMenuItem;
        private GridBasedViewer gridBasedViewer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelect;
        private System.Windows.Forms.ToolStripButton toolStripButtonMove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem moveModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGridsToolStripMenuItem;
    }
}


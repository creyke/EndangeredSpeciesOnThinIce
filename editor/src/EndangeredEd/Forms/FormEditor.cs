// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Forms.FormEditor
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Entities;
using EndangeredEd.Xna;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EndangeredEd.Forms
{
  public class FormEditor : Form
  {
    public static string version = "1.0.1.6";
    private IContainer components = (IContainer) null;
    private Vector2 draggingOffset = Vector2.Zero;
    private Vector2 rightClickPos = Vector2.Zero;
    private Microsoft.Xna.Framework.Color hmColor = new Microsoft.Xna.Framework.Color(byte.MaxValue, byte.MaxValue, (byte) 0, (byte) 100);
    private Microsoft.Xna.Framework.Color hmDeathColor = new Microsoft.Xna.Framework.Color(byte.MaxValue, (byte) 0, (byte) 0, byte.MaxValue);
    private bool linkingNode = false;
    private bool unlinkingNode = false;
    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newToolStripMenuItem;
    private ToolStripMenuItem openToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripMenuItem saveAsToolStripMenuItem;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButton1;
    private StatusStrip statusStrip1;
    private Panel panelProperties;
    private ToolStripMenuItem helpToolStripMenuItem;
    private ToolStripMenuItem aboutToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripSeparator toolStripSeparator2;
    private OpenFileDialog openFileDialog1;
    private SaveFileDialog saveFileDialog1;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripComboBox toolStripComboBox1;
    private Panel panelEntites;
    private Panel panelLevel;
    private Panel levelCanvas;
    private PictureBox levelBackground;
    private ModelViewerControl xnaViewer;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem toolStripMenuItem1;
    private ToolStripMenuItem toolStripMenuItem2;
    private ToolStripButton toolStripButtonBuildLevel;
    private ToolStripMenuItem toolStripMenuItem3;
    private ToolStripMenuItem buildLevelToolStripMenuItem;
    private ToolStripMenuItem toolsToolStripMenuItem;
    private ToolStripMenuItem optionsToolStripMenuItem;
    private ToolStripButton toolStripButtonAnimate;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton toolStripButtonCreateEntity;
    private ToolStripMenuItem entitiesToolStripMenuItem;
    private ToolStripMenuItem createEntityToolStripMenuItem;
    private ToolStripButton toolStripButtonConvertEntity;
    private ToolStripMenuItem convertEntityToolStripMenuItem;
    private ToolStripMenuItem convertToolStripMenuItem;
    private ToolStripStatusLabel toolStripSelectedLabel;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private PropertyGrid propertyGrid1;
    private TabPage tabPage2;
    private ListView listView1;
    private ContextMenuStrip contextMenuStrip2;
    private ToolStripMenuItem addNodeToolStripMenuItem;
    private ToolStripMenuItem deleteNodeToolStripMenuItem;
    private ToolStripMenuItem linkNodeToolStripMenuItem;
    private ToolStripMenuItem unlinkNodeToolStripMenuItem;
    private ToolStripMenuItem sharkNodeToolStripMenuItem;
    private ToolStripMenuItem heatmapToolStripMenuItem;
    private ToolStripMenuItem loadHeatmapToolStripMenuItem;
    private ToolStripMenuItem closeHeatmapToolStripMenuItem;
    public static FormEditor INSTANCE;
    public static string APPLICATION_PATH;
    private ContentBuilder contentBuilder;
    private ContentManager contentManager;
    private PrimitiveBatch primitiveBatch;
    private bool dragging;
    private Heatmap heatmap;
    private Level level;
    private Timer renderTimer;
    private string openingLevel;
    private MA_Node currentNode;
    private Texture2D heatmapSpot;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (FormEditor));
      this.menuStrip = new MenuStrip();
      this.fileToolStripMenuItem = new ToolStripMenuItem();
      this.newToolStripMenuItem = new ToolStripMenuItem();
      this.openToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.saveToolStripMenuItem = new ToolStripMenuItem();
      this.saveAsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.exitToolStripMenuItem = new ToolStripMenuItem();
      this.entitiesToolStripMenuItem = new ToolStripMenuItem();
      this.createEntityToolStripMenuItem = new ToolStripMenuItem();
      this.convertEntityToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem3 = new ToolStripMenuItem();
      this.buildLevelToolStripMenuItem = new ToolStripMenuItem();
      this.toolsToolStripMenuItem = new ToolStripMenuItem();
      this.optionsToolStripMenuItem = new ToolStripMenuItem();
      this.heatmapToolStripMenuItem = new ToolStripMenuItem();
      this.loadHeatmapToolStripMenuItem = new ToolStripMenuItem();
      this.closeHeatmapToolStripMenuItem = new ToolStripMenuItem();
      this.helpToolStripMenuItem = new ToolStripMenuItem();
      this.aboutToolStripMenuItem = new ToolStripMenuItem();
      this.toolStrip1 = new ToolStrip();
      this.toolStripButton1 = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.toolStripButtonCreateEntity = new ToolStripButton();
      this.toolStripButtonConvertEntity = new ToolStripButton();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripButtonAnimate = new ToolStripButton();
      this.toolStripComboBox1 = new ToolStripComboBox();
      this.toolStripButtonBuildLevel = new ToolStripButton();
      this.statusStrip1 = new StatusStrip();
      this.toolStripSelectedLabel = new ToolStripStatusLabel();
      this.panelProperties = new Panel();
      this.tabControl1 = new TabControl();
      this.tabPage1 = new TabPage();
      this.propertyGrid1 = new PropertyGrid();
      this.tabPage2 = new TabPage();
      this.listView1 = new ListView();
      this.openFileDialog1 = new OpenFileDialog();
      this.saveFileDialog1 = new SaveFileDialog();
      this.panelEntites = new Panel();
      this.panelLevel = new Panel();
      this.xnaViewer = new ModelViewerControl();
      this.levelCanvas = new Panel();
      this.levelBackground = new PictureBox();
      this.contextMenuStrip1 = new ContextMenuStrip(this.components);
      this.toolStripMenuItem1 = new ToolStripMenuItem();
      this.convertToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripMenuItem2 = new ToolStripMenuItem();
      this.contextMenuStrip2 = new ContextMenuStrip(this.components);
      this.addNodeToolStripMenuItem = new ToolStripMenuItem();
      this.deleteNodeToolStripMenuItem = new ToolStripMenuItem();
      this.linkNodeToolStripMenuItem = new ToolStripMenuItem();
      this.unlinkNodeToolStripMenuItem = new ToolStripMenuItem();
      this.sharkNodeToolStripMenuItem = new ToolStripMenuItem();
      this.menuStrip.SuspendLayout();
      this.toolStrip1.SuspendLayout();
      this.statusStrip1.SuspendLayout();
      this.panelProperties.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.tabPage2.SuspendLayout();
      this.panelLevel.SuspendLayout();
      this.levelCanvas.SuspendLayout();
      ((ISupportInitialize) this.levelBackground).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      this.contextMenuStrip2.SuspendLayout();
      this.SuspendLayout();
      this.menuStrip.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.fileToolStripMenuItem,
        (ToolStripItem) this.entitiesToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem3,
        (ToolStripItem) this.toolsToolStripMenuItem,
        (ToolStripItem) this.helpToolStripMenuItem
      });
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new Size(1039, 24);
      this.menuStrip.TabIndex = 0;
      this.menuStrip.Text = "menuStrip1";
      this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.newToolStripMenuItem,
        (ToolStripItem) this.openToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.saveToolStripMenuItem,
        (ToolStripItem) this.saveAsToolStripMenuItem,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.exitToolStripMenuItem
      });
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.ShortcutKeys = Keys.N | Keys.Control;
      this.newToolStripMenuItem.Size = new Size(179, 22);
      this.newToolStripMenuItem.Text = "&New Level";
      this.newToolStripMenuItem.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.openToolStripMenuItem.Name = "openToolStripMenuItem";
      this.openToolStripMenuItem.ShortcutKeys = Keys.O | Keys.Control;
      this.openToolStripMenuItem.Size = new Size(179, 22);
      this.openToolStripMenuItem.Text = "&Open Level";
      this.openToolStripMenuItem.Click += new EventHandler(this.openToolStripMenuItem_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(176, 6);
      this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
      this.saveToolStripMenuItem.ShortcutKeys = Keys.S | Keys.Control;
      this.saveToolStripMenuItem.Size = new Size(179, 22);
      this.saveToolStripMenuItem.Text = "&Save";
      this.saveToolStripMenuItem.Click += new EventHandler(this.saveToolStripMenuItem_Click);
      this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
      this.saveAsToolStripMenuItem.ShortcutKeys = Keys.A | Keys.Control;
      this.saveAsToolStripMenuItem.Size = new Size(179, 22);
      this.saveAsToolStripMenuItem.Text = "Save &As";
      this.saveAsToolStripMenuItem.Click += new EventHandler(this.saveAsToolStripMenuItem_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(176, 6);
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new Size(179, 22);
      this.exitToolStripMenuItem.Text = "E&xit";
      this.exitToolStripMenuItem.Click += new EventHandler(this.exitToolStripMenuItem_Click);
      this.entitiesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.createEntityToolStripMenuItem,
        (ToolStripItem) this.convertEntityToolStripMenuItem
      });
      this.entitiesToolStripMenuItem.Name = "entitiesToolStripMenuItem";
      this.entitiesToolStripMenuItem.Size = new Size(54, 20);
      this.entitiesToolStripMenuItem.Text = "&Entities";
      this.createEntityToolStripMenuItem.Name = "createEntityToolStripMenuItem";
      this.createEntityToolStripMenuItem.ShortcutKeys = Keys.E | Keys.Control;
      this.createEntityToolStripMenuItem.Size = new Size(194, 22);
      this.createEntityToolStripMenuItem.Text = "&Create Entity";
      this.createEntityToolStripMenuItem.Click += new EventHandler(this.toolStripButtonCreateEntity_Click);
      this.convertEntityToolStripMenuItem.Name = "convertEntityToolStripMenuItem";
      this.convertEntityToolStripMenuItem.ShortcutKeys = Keys.D | Keys.Control;
      this.convertEntityToolStripMenuItem.Size = new Size(194, 22);
      this.convertEntityToolStripMenuItem.Text = "Con&vert Entity";
      this.convertEntityToolStripMenuItem.Click += new EventHandler(this.toolStripButtonConvertEntity_Click);
      this.toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.buildLevelToolStripMenuItem
      });
      this.toolStripMenuItem3.Name = "toolStripMenuItem3";
      this.toolStripMenuItem3.Size = new Size(41, 20);
      this.toolStripMenuItem3.Text = "&Build";
      this.buildLevelToolStripMenuItem.Name = "buildLevelToolStripMenuItem";
      this.buildLevelToolStripMenuItem.ShortcutKeys = Keys.F5;
      this.buildLevelToolStripMenuItem.Size = new Size(154, 22);
      this.buildLevelToolStripMenuItem.Text = "Build &Level";
      this.buildLevelToolStripMenuItem.Click += new EventHandler(this.BuildLevel);
      this.toolsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.optionsToolStripMenuItem,
        (ToolStripItem) this.heatmapToolStripMenuItem
      });
      this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
      this.toolsToolStripMenuItem.Size = new Size(44, 20);
      this.toolsToolStripMenuItem.Text = "&Tools";
      this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
      this.optionsToolStripMenuItem.Size = new Size(134, 22);
      this.optionsToolStripMenuItem.Text = "&Options...";
      this.optionsToolStripMenuItem.Visible = false;
      this.optionsToolStripMenuItem.Click += new EventHandler(this.optionsToolStripMenuItem_Click);
      this.heatmapToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.loadHeatmapToolStripMenuItem,
        (ToolStripItem) this.closeHeatmapToolStripMenuItem
      });
      this.heatmapToolStripMenuItem.Name = "heatmapToolStripMenuItem";
      this.heatmapToolStripMenuItem.Size = new Size(134, 22);
      this.heatmapToolStripMenuItem.Text = "Heat&map";
      this.loadHeatmapToolStripMenuItem.Name = "loadHeatmapToolStripMenuItem";
      this.loadHeatmapToolStripMenuItem.Size = new Size(157, 22);
      this.loadHeatmapToolStripMenuItem.Text = "&Load Heatmap";
      this.loadHeatmapToolStripMenuItem.Click += new EventHandler(this.loadHeatmapToolStripMenuItem_Click);
      this.closeHeatmapToolStripMenuItem.Name = "closeHeatmapToolStripMenuItem";
      this.closeHeatmapToolStripMenuItem.Size = new Size(157, 22);
      this.closeHeatmapToolStripMenuItem.Text = "&Close Heatmap";
      this.closeHeatmapToolStripMenuItem.Click += new EventHandler(this.closeHeatmapToolStripMenuItem_Click);
      this.helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.aboutToolStripMenuItem
      });
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new Size(40, 20);
      this.helpToolStripMenuItem.Text = "&Help";
      this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
      this.aboutToolStripMenuItem.Size = new Size(114, 22);
      this.aboutToolStripMenuItem.Text = "&About";
      this.toolStrip1.Items.AddRange(new ToolStripItem[8]
      {
        (ToolStripItem) this.toolStripButton1,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.toolStripButtonCreateEntity,
        (ToolStripItem) this.toolStripButtonConvertEntity,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripButtonAnimate,
        (ToolStripItem) this.toolStripComboBox1,
        (ToolStripItem) this.toolStripButtonBuildLevel
      });
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new Size(1039, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      this.toolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButton1.Image = (Image) componentResourceManager.GetObject("toolStripButton1.Image");
      this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton1.Name = "toolStripButton1";
      this.toolStripButton1.Size = new Size(23, 22);
      this.toolStripButton1.Text = "New Level";
      this.toolStripButton1.Visible = false;
      this.toolStripButton1.Click += new EventHandler(this.newToolStripMenuItem_Click);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      this.toolStripSeparator4.Size = new Size(6, 25);
      this.toolStripSeparator4.Visible = false;
      this.toolStripButtonCreateEntity.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonCreateEntity.Image = (Image) componentResourceManager.GetObject("toolStripButtonCreateEntity.Image");
      this.toolStripButtonCreateEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonCreateEntity.Name = "toolStripButtonCreateEntity";
      this.toolStripButtonCreateEntity.Size = new Size(23, 22);
      this.toolStripButtonCreateEntity.Text = "Create Entity";
      this.toolStripButtonCreateEntity.Click += new EventHandler(this.toolStripButtonCreateEntity_Click);
      this.toolStripButtonConvertEntity.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonConvertEntity.Image = (Image) componentResourceManager.GetObject("toolStripButtonConvertEntity.Image");
      this.toolStripButtonConvertEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonConvertEntity.Name = "toolStripButtonConvertEntity";
      this.toolStripButtonConvertEntity.Size = new Size(23, 22);
      this.toolStripButtonConvertEntity.Text = "Convert Entity";
      this.toolStripButtonConvertEntity.Click += new EventHandler(this.toolStripButtonConvertEntity_Click);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      this.toolStripSeparator3.Size = new Size(6, 25);
      this.toolStripButtonAnimate.CheckOnClick = true;
      this.toolStripButtonAnimate.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonAnimate.Image = (Image) componentResourceManager.GetObject("toolStripButtonAnimate.Image");
      this.toolStripButtonAnimate.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonAnimate.Name = "toolStripButtonAnimate";
      this.toolStripButtonAnimate.Size = new Size(23, 22);
      this.toolStripButtonAnimate.Text = "Animate All Entities";
      this.toolStripButtonAnimate.Click += new EventHandler(this.toolStripButtonAnimate_Click);
      this.toolStripComboBox1.Name = "toolStripComboBox1";
      this.toolStripComboBox1.Size = new Size(300, 25);
      this.toolStripComboBox1.Text = "C:\\Working\\Projects\\Game\\Game\\gfx";
      this.toolStripButtonBuildLevel.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonBuildLevel.Image = (Image) componentResourceManager.GetObject("toolStripButtonBuildLevel.Image");
      this.toolStripButtonBuildLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButtonBuildLevel.Name = "toolStripButtonBuildLevel";
      this.toolStripButtonBuildLevel.Size = new Size(23, 22);
      this.toolStripButtonBuildLevel.Text = "Build Level";
      this.toolStripButtonBuildLevel.Click += new EventHandler(this.BuildLevel);
      this.statusStrip1.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripSelectedLabel
      });
      this.statusStrip1.Location = new System.Drawing.Point(0, 601);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new Size(1039, 22);
      this.statusStrip1.TabIndex = 2;
      this.statusStrip1.Text = "statusStrip1";
      this.toolStripSelectedLabel.Name = "toolStripSelectedLabel";
      this.toolStripSelectedLabel.Size = new Size(0, 17);
      this.panelProperties.Controls.Add((Control) this.tabControl1);
      this.panelProperties.Dock = DockStyle.Right;
      this.panelProperties.Location = new System.Drawing.Point(739, 49);
      this.panelProperties.Name = "panelProperties";
      this.panelProperties.Size = new Size(300, 552);
      this.panelProperties.TabIndex = 3;
      this.tabControl1.Controls.Add((Control) this.tabPage1);
      this.tabControl1.Controls.Add((Control) this.tabPage2);
      this.tabControl1.Dock = DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new Size(300, 552);
      this.tabControl1.TabIndex = 4;
      this.tabPage1.Controls.Add((Control) this.propertyGrid1);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new Padding(3);
      this.tabPage1.Size = new Size(292, 526);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Entity Properties";
      this.tabPage1.UseVisualStyleBackColor = true;
      this.propertyGrid1.Dock = DockStyle.Fill;
      this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new Size(286, 520);
      this.propertyGrid1.TabIndex = 1;
      this.tabPage2.Controls.Add((Control) this.listView1);
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new Padding(3);
      this.tabPage2.Size = new Size(292, 526);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Entity Visibility";
      this.tabPage2.UseVisualStyleBackColor = true;
      this.listView1.Dock = DockStyle.Fill;
      this.listView1.Location = new System.Drawing.Point(3, 3);
      this.listView1.Name = "listView1";
      this.listView1.Size = new Size(286, 520);
      this.listView1.TabIndex = 4;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.openFileDialog1.FileName = "openFileDialog1";
      this.panelEntites.Dock = DockStyle.Left;
      this.panelEntites.Location = new System.Drawing.Point(0, 49);
      this.panelEntites.Name = "panelEntites";
      this.panelEntites.Size = new Size(200, 552);
      this.panelEntites.TabIndex = 5;
      this.panelLevel.AutoScroll = true;
      this.panelLevel.BorderStyle = BorderStyle.Fixed3D;
      this.panelLevel.Controls.Add((Control) this.xnaViewer);
      this.panelLevel.Controls.Add((Control) this.levelCanvas);
      this.panelLevel.Dock = DockStyle.Fill;
      this.panelLevel.Location = new System.Drawing.Point(200, 49);
      this.panelLevel.Name = "panelLevel";
      this.panelLevel.Size = new Size(539, 552);
      this.panelLevel.TabIndex = 6;
      this.panelLevel.Scroll += new ScrollEventHandler(this.panelLevel_Scroll);
      this.xnaViewer.Location = new System.Drawing.Point(0, 0);
      this.xnaViewer.Model = (Model) null;
      this.xnaViewer.Name = "xnaViewer";
      this.xnaViewer.Size = new Size(1024, 1024);
      this.xnaViewer.TabIndex = 1;
      this.xnaViewer.Text = "xnaViewer";
      this.levelCanvas.BackColor = SystemColors.Control;
      this.levelCanvas.Controls.Add((Control) this.levelBackground);
      this.levelCanvas.Location = new System.Drawing.Point(0, 0);
      this.levelCanvas.Name = "levelCanvas";
      this.levelCanvas.Size = new Size(1024, 1024);
      this.levelCanvas.TabIndex = 1;
      this.levelBackground.BackColor = SystemColors.AppWorkspace;
      this.levelBackground.Location = new System.Drawing.Point(0, 0);
      this.levelBackground.Name = "levelBackground";
      this.levelBackground.Size = new Size(100, 50);
      this.levelBackground.TabIndex = 2;
      this.levelBackground.TabStop = false;
      this.contextMenuStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripMenuItem1,
        (ToolStripItem) this.convertToolStripMenuItem,
        (ToolStripItem) this.toolStripMenuItem2
      });
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new Size(125, 70);
      this.contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new Size(124, 22);
      this.toolStripMenuItem1.Text = "Clone";
      this.convertToolStripMenuItem.Name = "convertToolStripMenuItem";
      this.convertToolStripMenuItem.Size = new Size(124, 22);
      this.convertToolStripMenuItem.Text = "Convert";
      this.toolStripMenuItem2.Name = "toolStripMenuItem2";
      this.toolStripMenuItem2.Size = new Size(124, 22);
      this.toolStripMenuItem2.Text = "Delete";
      this.contextMenuStrip2.Items.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.addNodeToolStripMenuItem,
        (ToolStripItem) this.deleteNodeToolStripMenuItem,
        (ToolStripItem) this.linkNodeToolStripMenuItem,
        (ToolStripItem) this.unlinkNodeToolStripMenuItem,
        (ToolStripItem) this.sharkNodeToolStripMenuItem
      });
      this.contextMenuStrip2.Name = "contextMenuStrip2";
      this.contextMenuStrip2.Size = new Size(167, 114);
      this.addNodeToolStripMenuItem.Name = "addNodeToolStripMenuItem";
      this.addNodeToolStripMenuItem.Size = new Size(166, 22);
      this.addNodeToolStripMenuItem.Text = "Add Node";
      this.addNodeToolStripMenuItem.Click += new EventHandler(this.addNodeToolStripMenuItem_Click);
      this.deleteNodeToolStripMenuItem.Name = "deleteNodeToolStripMenuItem";
      this.deleteNodeToolStripMenuItem.Size = new Size(166, 22);
      this.deleteNodeToolStripMenuItem.Text = "Delete Node";
      this.deleteNodeToolStripMenuItem.Click += new EventHandler(this.deleteNodeToolStripMenuItem_Click);
      this.linkNodeToolStripMenuItem.Name = "linkNodeToolStripMenuItem";
      this.linkNodeToolStripMenuItem.Size = new Size(166, 22);
      this.linkNodeToolStripMenuItem.Text = "Link Node";
      this.linkNodeToolStripMenuItem.Click += new EventHandler(this.linkNodeToolStripMenuItem_Click);
      this.unlinkNodeToolStripMenuItem.Name = "unlinkNodeToolStripMenuItem";
      this.unlinkNodeToolStripMenuItem.Size = new Size(166, 22);
      this.unlinkNodeToolStripMenuItem.Text = "Unlink Node";
      this.unlinkNodeToolStripMenuItem.Click += new EventHandler(this.unlinkNodeToolStripMenuItem_Click);
      this.sharkNodeToolStripMenuItem.Name = "sharkNodeToolStripMenuItem";
      this.sharkNodeToolStripMenuItem.Size = new Size(166, 22);
      this.sharkNodeToolStripMenuItem.Text = "Shark Start Point";
      this.sharkNodeToolStripMenuItem.Click += new EventHandler(this.sharkNodeToolStripMenuItem_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(1039, 623);
      this.Controls.Add((Control) this.panelLevel);
      this.Controls.Add((Control) this.panelEntites);
      this.Controls.Add((Control) this.panelProperties);
      this.Controls.Add((Control) this.statusStrip1);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.menuStrip);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MainMenuStrip = this.menuStrip;
      this.Name = nameof (FormEditor);
      this.Text = "EndangeredEd v0.0";
      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panelProperties.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.tabPage2.ResumeLayout(false);
      this.panelLevel.ResumeLayout(false);
      this.levelCanvas.ResumeLayout(false);
      ((ISupportInitialize) this.levelBackground).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      this.contextMenuStrip2.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public static string GRAPHICS_PATH
    {
      get
      {
        return FormEditor.INSTANCE.toolStripComboBox1.Text;
      }
    }

    public ModelViewerControl XnaViewer
    {
      get
      {
        return this.xnaViewer;
      }
    }

    public Level Level
    {
      get
      {
        return this.level;
      }
    }

    public ContentBuilder ContentBuilder
    {
      get
      {
        return this.contentBuilder;
      }
    }

    public ContentManager ContentManager
    {
      get
      {
        return this.contentManager;
      }
    }

    public FormEditor(string[] args)
    {
      FormEditor.INSTANCE = this;
      this.InitializeComponent();
      this.SetTitle();
      this.InitializeXna();
      this.InitializeEditor(args);
      this.Shown += new EventHandler(this.LoadCoreAssets);
      Console.Write(256000);
    }

    private void SetSelected(object selectedObj)
    {
      try
      {
        (this.propertyGrid1.SelectedObject as MA_Entity).Selected = false;
      }
      catch (Exception ex)
      {
      }
      this.propertyGrid1.SelectedObject = (object) null;
      if (selectedObj != null)
      {
        this.propertyGrid1.SelectedObject = selectedObj;
        try
        {
          (this.propertyGrid1.SelectedObject as MA_Entity).Selected = true;
        }
        catch (Exception ex)
        {
        }
      }
      string str = "Selected: ";
      if (this.propertyGrid1.SelectedObject != null)
        str += this.propertyGrid1.SelectedObject.GetType().Name;
      this.toolStripSelectedLabel.Text = str;
    }

    private void LoadCoreAssets(object sender, EventArgs e)
    {
      // TODO: Add back.
      return;
      this.Shown -= new EventHandler(this.LoadCoreAssets);
      MA_Entity.ORIGIN_TEXTURE = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\EntityOrigin.png"), this.xnaViewer.GraphicsDevice);
      MA_Node.LINKED_TEXTURE = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\NodeLinked.PNG"), this.xnaViewer.GraphicsDevice);
      MA_Node.UNLINKED_TEXTURE = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\NodeUnlinked.PNG"), this.xnaViewer.GraphicsDevice);
      MA_Node.SHARK_LINKED_TEXTURE = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\NodeSharkLinked.PNG"), this.xnaViewer.GraphicsDevice);
      MA_Node.SHARK_UNLINKED_TEXTURE = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\NodeSharkUnlinked.PNG"), this.xnaViewer.GraphicsDevice);
      this.heatmapSpot = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.APPLICATION_PATH + "\\HeatmapSpot.png"), this.xnaViewer.GraphicsDevice);
      MA_Tile.SetupTileIndexes();
      MA_Tile.LoadTileGroups(FormEditor.GRAPHICS_PATH + "\\Tiles", this.xnaViewer.GraphicsDevice);
      this.primitiveBatch = new PrimitiveBatch(this.xnaViewer.GraphicsDevice);
      this.xnaViewer.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
      if (this.openingLevel == null || this.openingLevel.Length <= 0)
        return;
      this.LoadLevel(this.openingLevel);
    }

    private void InitializeXna()
    {
      this.contentBuilder = new ContentBuilder();
      this.contentManager = new ContentManager((IServiceProvider) this.xnaViewer.Services, this.contentBuilder.OutputDirectory);
      this.xnaViewer.MouseMove += new MouseEventHandler(this.xnaViewer_MouseMove);
      this.xnaViewer.MouseDown += new MouseEventHandler(this.xnaViewer_MouseDown);
      this.xnaViewer.MouseUp += new MouseEventHandler(this.xnaViewer_MouseUp);
      this.renderTimer = new Timer();
      this.renderTimer.Interval = 50;
      this.renderTimer.Tick += new EventHandler(this.renderTimer_Tick);
      this.renderTimer.Start();
    }

    private void xnaViewer_MouseDown(object sender, MouseEventArgs e)
    {
      bool flag1 = false;
      bool flag2 = false;
      MA_Entity entity = (MA_Entity) null;
      MA_Node node = (MA_Node) null;
      if (this.level == null || this.level.Entities == null)
        return;
      for (int index = this.level.Entities.Count - 1; index >= 0; --index)
      {
        if (this.level.Entities[index].SelectCheck(e.X, e.Y))
        {
          this.SetSelected((object) this.level.Entities[index]);
          if (e.Button == MouseButtons.Left)
          {
            this.draggingOffset = Vector2.Subtract(this.level.Entities[index].Position, new Vector2((float) e.X, (float) e.Y));
            this.dragging = true;
          }
          else if (e.Button == MouseButtons.Right)
            this.showEntityContext(entity, new System.Drawing.Point(e.X, e.Y));
          if (this.level.Entities[index].GetType() == typeof (MA_Node))
          {
            node = this.level.Entities[index] as MA_Node;
            flag2 = true;
            if (this.linkingNode)
            {
              this.linkingNode = false;
              if (this.currentNode != null && this.level.Entities[index] != this.currentNode)
              {
                this.currentNode.AddNeighbour(this.level.Entities[index] as MA_Node);
                break;
              }
              break;
            }
            if (this.unlinkingNode)
            {
              this.unlinkingNode = false;
              if (this.currentNode != null && this.level.Entities[index] != this.currentNode)
                this.currentNode.RemoveNeighbour(this.level.Entities[index] as MA_Node);
              break;
            }
            break;
          }
          flag1 = true;
          break;
        }
      }
      if (!flag1)
      {
        if (e.Button == MouseButtons.Right)
          this.showNodeContext(node, new System.Drawing.Point(e.X, e.Y));
        if (!flag2)
          this.SetSelected((object) this.level);
      }
    }

    private void showEntityContext(MA_Entity entity, System.Drawing.Point location)
    {
      this.rightClickPos = new Vector2((float) location.X, (float) location.Y);
      this.contextMenuStrip1.Show((Control) this.xnaViewer, location, ToolStripDropDownDirection.BelowRight);
    }

    private void showNodeContext(MA_Node node, System.Drawing.Point location)
    {
      this.currentNode = node;
      this.rightClickPos = new Vector2((float) location.X, (float) location.Y);
      this.addNodeToolStripMenuItem.Enabled = this.currentNode == null;
      this.deleteNodeToolStripMenuItem.Enabled = this.currentNode != null && this.currentNode.Neighbours.Count == 0;
      this.linkNodeToolStripMenuItem.Enabled = this.currentNode != null;
      this.unlinkNodeToolStripMenuItem.Enabled = this.currentNode != null;
      this.sharkNodeToolStripMenuItem.Enabled = this.currentNode != null;
      this.sharkNodeToolStripMenuItem.Checked = this.currentNode != null && this.currentNode.SharkNode;
      this.contextMenuStrip2.Show((Control) this.xnaViewer, location, ToolStripDropDownDirection.BelowRight);
    }

    private void xnaViewer_MouseUp(object sender, MouseEventArgs e)
    {
      this.dragging = false;
    }

    private void xnaViewer_MouseMove(object sender, MouseEventArgs e)
    {
      try
      {
        if (!this.dragging || this.level == null || this.propertyGrid1.SelectedObject == null)
          return;
        (this.propertyGrid1.SelectedObject as MA_Entity).Position = new Vector2((float) e.X + (float) this.draggingOffset.X, (float) e.Y + (float) this.draggingOffset.Y);
      }
      catch (Exception ex)
      {
      }
    }

    private void renderTimer_Tick(object sender, EventArgs e)
    {
      this.xnaViewer.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
      if (this.level != null && this.xnaViewer.GraphicsDevice != null)
        this.level.Draw(this.xnaViewer.SpriteBatch, this.primitiveBatch, this.toolStripButtonAnimate.Checked, this.listView1.Items);
      if (this.heatmap == null || this.xnaViewer.GraphicsDevice == null)
        return;
      this.xnaViewer.SpriteBatch.Begin();
      for (int index = 0; index < this.heatmap.PositionPoints.Length; ++index)
        this.xnaViewer.SpriteBatch.Draw(this.heatmapSpot, Vector2.Subtract(this.heatmap.PositionPoints[index], new Vector2(7f, 7f)), this.heatmap.PointIds[index] == 1 ? this.hmDeathColor : this.hmColor);
      this.xnaViewer.SpriteBatch.End();
    }

    private void LoadModel(string fileName)
    {
      this.Cursor = Cursors.WaitCursor;
      this.xnaViewer.Model = (Model) null;
      this.contentManager.Unload();
      this.contentBuilder.Clear();
      this.contentBuilder.Add(fileName, "Model", (string) null, "ModelProcessor");
      string text = this.contentBuilder.Build();
      if (string.IsNullOrEmpty(text))
      {
        this.xnaViewer.Model = (Model) this.contentManager.Load<Model>("Model");
      }
      else
      {
        int num = (int) MessageBox.Show(text, "Error");
      }
      this.Cursor = Cursors.Arrow;
    }

    private void InitializeEditor(string[] args)
    {
      this.panelEntites.Visible = false;
      FormEditor.APPLICATION_PATH = Path.GetDirectoryName(Application.ExecutablePath);
      Console.WriteLine("APPLICATION_PATH = " + FormEditor.APPLICATION_PATH);
      List<string> allClasses = EngineHelper.GetAllClasses("EndangeredEd.Entities");
      this.listView1.CheckBoxes = true;
      this.listView1.View = View.List;
      for (int index = 0; index < allClasses.Count; ++index)
      {
        this.listView1.Items.Add(allClasses[index]);
        this.listView1.Items[this.listView1.Items.Count - 1].Checked = true;
      }
      string[] strArray = FormEditor.APPLICATION_PATH.Split(Path.DirectorySeparatorChar);
      string str = "";
      for (int index = 0; index < strArray.Length - 5; ++index)
        str = str + strArray[index] + (object) Path.DirectorySeparatorChar;
      this.toolStripComboBox1.Text = str + "Game" + (object) Path.DirectorySeparatorChar + "gfx" + (object) Path.DirectorySeparatorChar;
      if (false)
        this.openingLevel = "C:\\Working\\Projects\\Game\\Editor\\EndangeredEd\\bin\\x86\\Debug\\Levels\\Level 3 - Cold Feet Retreat.esl";
      else if (args.Length > 0 && Path.GetExtension(args[0]) == ".esl" && File.Exists(args[0]))
        this.openingLevel = args[0];
      else
        this.CreateNewLevel();
      this.levelCanvas.Visible = false;
    }

    private void CreateNewLevel()
    {
      if (this.xnaViewer.GraphicsDevice != null)
        this.xnaViewer.GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.Black);
      this.level = new Level(this.levelBackground, this.levelCanvas);
      this.propertyGrid1.SelectedObject = (object) this.level;
      this.SetTitle();
    }

    private void LoadLevel(string file)
    {
      this.level = Level.Load(file, this.levelBackground, this.levelCanvas);
      this.level.Width = this.level.Width;
      this.level.Height = this.level.Height;
      this.propertyGrid1.SelectedObject = (object) this.level;
      this.SetTitle();
    }

    private void SetTitle()
    {
      this.Text = "EndangeredEd v" + FormEditor.version;
      if (this.level == null)
        return;
      this.Text = this.Text + " - [" + this.level.FileName + "]";
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.CreateNewLevel();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.InitialDirectory = FormEditor.APPLICATION_PATH;
      this.openFileDialog1.Filter = "ES Level (*.esl)|*.esl|All files (*.*)|*.*";
      this.openFileDialog1.FilterIndex = 1;
      this.openFileDialog1.RestoreDirectory = true;
      this.openFileDialog1.FileName = "";
      if (this.openFileDialog1.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.LoadLevel(this.openFileDialog1.FileName);
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.level != null && this.level.FileName != "Untitled.esl")
        this.level.Save();
      else
        this.saveAsToolStripMenuItem_Click(sender, e);
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.saveFileDialog1.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.level.FileName = this.saveFileDialog1.FileName;
      this.saveToolStripMenuItem_Click(sender, e);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void panelLevel_Scroll(object sender, ScrollEventArgs e)
    {
      this.renderTimer_Tick(sender, (EventArgs) e);
    }

    private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {
      switch (e.ClickedItem.Text)
      {
        case "Clone":
          this.CloneEntity((float) this.rightClickPos.X, (float) this.rightClickPos.Y);
          break;
        case "Convert":
          this.toolStripButtonConvertEntity_Click((object) null, (EventArgs) null);
          break;
        case "Delete":
          this.DeleteEntity();
          break;
      }
    }

    private void CloneEntity(float cloneX, float cloneY)
    {
      MA_Entity maEntity = (this.propertyGrid1.SelectedObject as MA_Entity).Clone();
      maEntity.Position = new Vector2(cloneX, cloneY);
      maEntity.UpdateAsset();
      this.level.Entities.Add(maEntity);
      this.SetSelected((object) maEntity);
    }

    private void DeleteEntity()
    {
      this.level.Entities.Remove(this.propertyGrid1.SelectedObject as MA_Entity);
    }

    private void BuildLevel(object sender, EventArgs e)
    {
      bool flag = false;
      FormBuildProgress bpf = new FormBuildProgress();
      FormBuildProgress formBuildProgress = bpf;
      System.Drawing.Point location = this.Location;
      int x = location.X + this.Width / 2 - bpf.Width / 2;
      location = this.Location;
      int y = location.X + this.Height / 2 - bpf.Height / 2;
      System.Drawing.Point point = new System.Drawing.Point(x, y);
      formBuildProgress.Location = point;
      bpf.SetProgress(0);
      bpf.SetTask("Creating output file...");
      if (this.level != null && this.level.BuildPath != null && this.level.BuildPath.Length > 0 && Directory.Exists(Path.GetDirectoryName(this.level.BuildPath)))
      {
        bpf.SetProgress(15);
        bpf.SetTask("Writing level...");
        try
        {
          flag = true;
          LevelBuilder.Build(this.level.BuildPath, this.level, FormEditor.version, bpf);
          bpf.SetProgress(90);
          bpf.SetTask("Finalising...");
        }
        catch (Exception ex)
        {
          throw;
        }
      }
      if (flag)
      {
        bpf.SetProgress(100);
        bpf.SetTask("Done.");
        int num = (int) MessageBox.Show("Build of level '" + this.level.Name + "' to '" + Path.GetFileName(this.level.BuildPath) + "' complete.", "Build Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
      }
      else
      {
        bpf.SetProgress(0);
        bpf.SetTask("Failed.");
        int num = (int) MessageBox.Show("Build of level '" + this.level.Name + "' to '" + Path.GetFileName(this.level.BuildPath) + "' failed.", "Build Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
      }
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      FormOptions formOptions = new FormOptions();
      formOptions.StartPosition = FormStartPosition.CenterParent;
      int num = (int) formOptions.ShowDialog((IWin32Window) this);
    }

    private void formOptions_FormClosing(object sender, FormClosingEventArgs e)
    {
    }

    private void toolStripButtonAnimate_Click(object sender, EventArgs e)
    {
    }

    private void toolStripButtonCreateEntity_Click(object sender, EventArgs e)
    {
      int num = (int) new FormNewEntity(true, this.level, (MA_Entity) null, (PropertyGrid) null).ShowDialog((IWin32Window) this);
      if (this.propertyGrid1.SelectedObject == null)
        return;
      this.SetSelected(this.propertyGrid1.SelectedObject);
    }

    private void toolStripButtonConvertEntity_Click(object sender, EventArgs e)
    {
      bool flag = true;
      MA_Entity target = (MA_Entity) null;
      try
      {
        target = this.propertyGrid1.SelectedObject as MA_Entity;
        Console.WriteLine(target.Name);
      }
      catch (Exception ex)
      {
        flag = false;
      }
      if (!flag)
        return;
      int num = (int) new FormNewEntity(false, this.level, target, this.propertyGrid1).ShowDialog((IWin32Window) this);
    }

    private void addNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        MA_Node maNode = new MA_Node();
        maNode.NodeID = this.level.GetNextNodeId();
        maNode.Position = this.rightClickPos;
        maNode.Offset = new Vector2(8f);
        this.level.Entities.Add((MA_Entity) maNode);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to add node.");
        throw;
      }
    }

    private void deleteNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.currentNode.DeleteNode();
        this.level.Entities.Remove((MA_Entity) this.currentNode);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to delete node.");
        throw;
      }
    }

    private void linkNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.linkingNode = true;
        Console.WriteLine("linkingNode = " + (object) this.linkingNode);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to link node.");
        throw;
      }
    }

    private void unlinkNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      try
      {
        this.unlinkingNode = true;
        Console.WriteLine("unlinkingNode = " + (object) this.unlinkingNode);
      }
      catch (Exception ex)
      {
        Console.WriteLine("Failed to unlink node.");
        throw;
      }
    }

    private void sharkNodeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (this.currentNode == null)
        return;
      this.currentNode.SharkNode = !this.currentNode.SharkNode;
    }

    private void loadHeatmapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.openFileDialog1.InitialDirectory = FormEditor.APPLICATION_PATH;
      this.openFileDialog1.Filter = "ES Heatmap (*.esh)|*.esh|All files (*.*)|*.*";
      this.openFileDialog1.FilterIndex = 1;
      this.openFileDialog1.RestoreDirectory = true;
      this.openFileDialog1.FileName = "";
      if (this.openFileDialog1.ShowDialog((IWin32Window) this) != DialogResult.OK)
        return;
      this.LoadHeatmap(this.openFileDialog1.FileName);
    }

    private void LoadHeatmap(string path)
    {
      this.heatmap = (Heatmap) null;
      this.heatmap = new Heatmap(path);
    }

    private void closeHeatmapToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.heatmap = (Heatmap) null;
    }
  }
}

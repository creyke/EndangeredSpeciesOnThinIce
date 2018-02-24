// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Forms.FormNewEntity
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EndangeredEd.Forms
{
  public class FormNewEntity : Form
  {
    private IContainer components = (IContainer) null;
    private ListBox listBoxEntityTypes;
    private PropertyGrid propertyGrid1;
    private Button buttonAdd;
    private Button buttonCancel;
    private bool newEntity;
    private Level level;
    private MA_Entity target;
    private PropertyGrid grid;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.listBoxEntityTypes = new ListBox();
      this.propertyGrid1 = new PropertyGrid();
      this.buttonAdd = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.listBoxEntityTypes.FormattingEnabled = true;
      this.listBoxEntityTypes.Location = new Point(12, 12);
      this.listBoxEntityTypes.Name = "listBoxEntityTypes";
      this.listBoxEntityTypes.Size = new Size(179, 355);
      this.listBoxEntityTypes.TabIndex = 0;
      this.propertyGrid1.Location = new Point(199, 12);
      this.propertyGrid1.Name = "propertyGrid1";
      this.propertyGrid1.Size = new Size(193, 329);
      this.propertyGrid1.TabIndex = 1;
      this.buttonAdd.Location = new Point(199, 348);
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.Size = new Size(90, 23);
      this.buttonAdd.TabIndex = 2;
      this.buttonAdd.Text = "&Add";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new EventHandler(this.buttonAdd_Click);
      this.buttonCancel.Location = new Point(302, 348);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(90, 23);
      this.buttonCancel.TabIndex = 3;
      this.buttonCancel.Text = "&Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(404, 381);
      this.ControlBox = false;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonAdd);
      this.Controls.Add((Control) this.propertyGrid1);
      this.Controls.Add((Control) this.listBoxEntityTypes);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FormNewEntity);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "New Entity";
      this.ResumeLayout(false);
    }

    public FormNewEntity(bool newEntity, Level level, MA_Entity target, PropertyGrid grid)
    {
      this.level = level;
      this.newEntity = newEntity;
      this.target = target;
      this.grid = grid;
      this.InitializeComponent();
      this.Text = (newEntity ? "New" : "Convert") + " Entity";
      this.buttonAdd.Text = newEntity ? "&Add" : "&Convert";
      this.Shown += new EventHandler(this.FormNewEntity_Shown);
      this.listBoxEntityTypes.SelectedIndexChanged += new EventHandler(this.listBoxEntityTypes_SelectedIndexChanged);
    }

    private void listBoxEntityTypes_SelectedIndexChanged(object sender, EventArgs e)
    {
      Console.WriteLine(this.listBoxEntityTypes.SelectedItem);
      Console.WriteLine(this.listBoxEntityTypes.SelectedValue);
      if (this.listBoxEntityTypes.SelectedItem == null)
        return;
      MA_Entity instance = Assembly.GetExecutingAssembly().CreateInstance("EndangeredEd.Entities." + this.listBoxEntityTypes.SelectedItem) as MA_Entity;
      this.propertyGrid1.SelectedObject = (object) instance;
      if (!this.newEntity)
      {
        instance.ID = this.target.ID;
        instance.Name = this.target.Name;
        instance.Position = this.target.Position;
        instance.Offset = this.target.Offset;
        instance.SpriteAsset = this.target.SpriteAsset;
        instance.SpriteSize = this.target.SpriteSize;
      }
    }

    private void FormNewEntity_Shown(object sender, EventArgs e)
    {
      List<string> allClasses = EngineHelper.GetAllClasses("EndangeredEd.Entities");
      for (int index = 0; index < allClasses.Count; ++index)
        this.listBoxEntityTypes.Items.Add((object) allClasses[index]);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
      if (this.propertyGrid1.SelectedObject != null)
      {
        if (this.newEntity)
        {
          this.level.Entities.Add(this.propertyGrid1.SelectedObject as MA_Entity);
        }
        else
        {
          this.level.Entities[this.level.Entities.IndexOf(this.target)] = this.propertyGrid1.SelectedObject as MA_Entity;
          this.grid.SelectedObject = this.propertyGrid1.SelectedObject;
        }
      }
      this.Close();
    }
  }
}

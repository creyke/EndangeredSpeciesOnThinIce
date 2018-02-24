// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Forms.FormOptions
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EndangeredEd.Forms
{
  public class FormOptions : Form
  {
    private IContainer components = (IContainer) null;
    private Button buttonApply;
    private Button buttonCancel;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.buttonApply = new Button();
      this.buttonCancel = new Button();
      this.SuspendLayout();
      this.buttonApply.Location = new Point(180, 291);
      this.buttonApply.Name = "buttonApply";
      this.buttonApply.Size = new Size(75, 23);
      this.buttonApply.TabIndex = 0;
      this.buttonApply.Text = "&Apply";
      this.buttonApply.UseVisualStyleBackColor = true;
      this.buttonApply.Click += new EventHandler(this.buttonApply_Click);
      this.buttonCancel.Location = new Point(261, 291);
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.Size = new Size(75, 23);
      this.buttonCancel.TabIndex = 1;
      this.buttonCancel.Text = "&Cancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(348, 326);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonApply);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FormOptions);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Options";
      this.ResumeLayout(false);
    }

    public FormOptions()
    {
      this.InitializeComponent();
    }

    private void buttonApply_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}

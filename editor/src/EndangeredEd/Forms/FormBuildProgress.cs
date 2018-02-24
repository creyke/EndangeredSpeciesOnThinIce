// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Forms.FormBuildProgress
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EndangeredEd.Forms
{
  public class FormBuildProgress : Form
  {
    private IContainer components = (IContainer) null;
    private ProgressBar progressBar1;
    private Label labelProgress;

    public FormBuildProgress()
    {
      this.InitializeComponent();
    }

    public void SetProgress(int progress)
    {
      this.progressBar1.Value = progress;
    }

    public void SetTask(string task)
    {
      this.labelProgress.Text = task;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.progressBar1 = new ProgressBar();
      this.labelProgress = new Label();
      this.SuspendLayout();
      this.progressBar1.Location = new Point(12, 12);
      this.progressBar1.Name = "progressBar1";
      this.progressBar1.Size = new Size(349, 23);
      this.progressBar1.TabIndex = 0;
      this.progressBar1.Value = 47;
      this.labelProgress.Location = new Point(12, 40);
      this.labelProgress.Name = "labelProgress";
      this.labelProgress.Size = new Size(349, 19);
      this.labelProgress.TabIndex = 1;
      this.labelProgress.Text = "<Progress>";
      this.labelProgress.TextAlign = ContentAlignment.MiddleCenter;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(373, 68);
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelProgress);
      this.Controls.Add((Control) this.progressBar1);
      this.FormBorderStyle = FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (FormBuildProgress);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = "Building Endangered Species Level...";
      this.ResumeLayout(false);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Interface.SuperPictureBox
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using System;
using System.Drawing;
using System.Windows.Forms;

namespace EndangeredEd.Interface
{
  public class SuperPictureBox : PictureBox
  {
    private Random r = new Random();
    private Timer timer;

    public SuperPictureBox()
    {
      this.timer = new Timer();
      this.timer.Tick += new EventHandler(this.TickHandler);
      this.timer.Interval = 500;
      this.timer.Enabled = true;
    }

    protected void TickHandler(object sender, EventArgs e)
    {
      this.InvalidateEx();
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 32;
        return createParams;
      }
    }

    protected void InvalidateEx()
    {
      if (this.Parent == null)
        return;
      this.Parent.Invalidate(new Rectangle(this.Location, this.Size), true);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }
  }
}

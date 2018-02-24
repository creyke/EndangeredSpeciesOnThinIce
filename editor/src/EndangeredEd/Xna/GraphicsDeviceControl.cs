// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.GraphicsDeviceControl
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EndangeredEd.Xna
{
  public abstract class GraphicsDeviceControl : Control
  {
    private ServiceContainer services = new ServiceContainer();
    private GraphicsDeviceService graphicsDeviceService;

    public GraphicsDevice GraphicsDevice
    {
      get
      {
        if (this.graphicsDeviceService != null)
          return this.graphicsDeviceService.GraphicsDevice;
        return (GraphicsDevice) null;
      }
    }

    public ServiceContainer Services
    {
      get
      {
        return this.services;
      }
    }

    protected override void OnCreateControl()
    {
      if (!this.DesignMode)
      {
        IntPtr handle = this.Handle;
        Size clientSize = this.ClientSize;
        int width = clientSize.Width;
        clientSize = this.ClientSize;
        int height = clientSize.Height;
        this.graphicsDeviceService = GraphicsDeviceService.AddRef(handle, width, height);
        this.services.AddService<IGraphicsDeviceService>((IGraphicsDeviceService) this.graphicsDeviceService);
        this.Initialize();
      }
      base.OnCreateControl();
    }

    protected override void Dispose(bool disposing)
    {
      if (this.graphicsDeviceService != null)
      {
        this.graphicsDeviceService.Release(disposing);
        this.graphicsDeviceService = (GraphicsDeviceService) null;
      }
      base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      string text = this.BeginDraw();
      if (string.IsNullOrEmpty(text))
      {
        this.Draw();
        this.EndDraw();
      }
      else
        this.PaintUsingSystemDrawing(e.Graphics, text);
    }

    private string BeginDraw()
    {
      if (this.graphicsDeviceService == null)
        return this.Text + "\n\n" + (object) this.GetType();
      string str = this.HandleDeviceReset();
      if (!string.IsNullOrEmpty(str))
        return str;
      Viewport viewport = (Viewport) null;
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_X(0);
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_Y(0);
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_Width(this.ClientSize.Width);
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_Height(this.ClientSize.Height);
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_MinDepth(0.0f);
      // ISSUE: explicit reference operation
      ((Viewport) @viewport).set_MaxDepth(1f);
      this.GraphicsDevice.set_Viewport(viewport);
      return (string) null;
    }

    private void EndDraw()
    {
      try
      {
        Rectangle rectangle;
        // ISSUE: explicit reference operation
        // ISSUE: variable of a reference type
        Rectangle& local = @rectangle;
        int num1 = 0;
        int num2 = 0;
        Size clientSize = this.ClientSize;
        int width = clientSize.Width;
        clientSize = this.ClientSize;
        int height = clientSize.Height;
        ((Rectangle) local).\u002Ector(num1, num2, width, height);
        this.GraphicsDevice.Present(new Rectangle?(rectangle), new Rectangle?(), this.Handle);
      }
      catch
      {
      }
    }

    private string HandleDeviceReset()
    {
      bool flag;
      switch (this.GraphicsDevice.get_GraphicsDeviceStatus() - 1)
      {
        case 0:
          return "Graphics device lost";
        case 1:
          flag = true;
          break;
        default:
          PresentationParameters presentationParameters = this.GraphicsDevice.get_PresentationParameters();
          flag = this.ClientSize.Width > presentationParameters.get_BackBufferWidth() || this.ClientSize.Height > presentationParameters.get_BackBufferHeight();
          break;
      }
      if (flag)
      {
        try
        {
          GraphicsDeviceService graphicsDeviceService = this.graphicsDeviceService;
          Size clientSize = this.ClientSize;
          int width = clientSize.Width;
          clientSize = this.ClientSize;
          int height = clientSize.Height;
          graphicsDeviceService.ResetDevice(width, height);
        }
        catch (Exception ex)
        {
          return "Graphics device reset failed\n\n" + (object) ex;
        }
      }
      return (string) null;
    }

    protected virtual void PaintUsingSystemDrawing(System.Drawing.Graphics graphics, string text)
    {
      graphics.Clear(Color.CornflowerBlue);
      using (Brush brush = (Brush) new SolidBrush(Color.Black))
      {
        using (StringFormat format = new StringFormat())
        {
          format.Alignment = StringAlignment.Center;
          format.LineAlignment = StringAlignment.Center;
          graphics.DrawString(text, this.Font, brush, (RectangleF) this.ClientRectangle, format);
        }
      }
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
    }

    protected abstract void Initialize();

    protected abstract void Draw();
  }
}

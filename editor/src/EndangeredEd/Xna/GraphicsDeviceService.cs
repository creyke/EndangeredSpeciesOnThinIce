// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.GraphicsDeviceService
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace EndangeredEd.Xna
{
  internal class GraphicsDeviceService : IGraphicsDeviceService
  {
    private static GraphicsDeviceService singletonInstance;
    private static int referenceCount;
    private GraphicsDevice graphicsDevice;
    private PresentationParameters parameters;

    private GraphicsDeviceService(IntPtr windowHandle, int width, int height)
    {
      this.parameters = new PresentationParameters();
      this.parameters.BackBufferWidth = Math.Max(width, 1);
      this.parameters.BackBufferHeight = Math.Max(height, 1);
      //this.parameters.BackBufferFormat = (SurfaceFormat) 1; // TODO: Validate.
      this.parameters.DeviceWindowHandle = windowHandle;
      //this.parameters.set_EnableAutoDepthStencil(true); // TODO: Validate.
      //this.parameters.set_AutoDepthStencilFormat((DepthFormat) 51); // TODO: Validate.
      this.graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, this.parameters);
      //this.graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, /*(DeviceType) 1, windowHandle,*/ this.parameters); // TODO: Validate.
    }
    
    event EventHandler<EventArgs> IGraphicsDeviceService.DeviceCreated
    {
        add
        {
        }

        remove
        {
        }
    }
    
    event EventHandler<EventArgs> IGraphicsDeviceService.DeviceDisposing
    {
        add
        {
        }

        remove
        {
        }
    }
    
    event EventHandler<EventArgs> IGraphicsDeviceService.DeviceReset
    {
        add
        {
        }

        remove
        {
        }
    }
    
    event EventHandler<EventArgs> IGraphicsDeviceService.DeviceResetting
    {
        add
        {
        }

        remove
        {
        }
    }
    
    public static GraphicsDeviceService AddRef(IntPtr windowHandle, int width, int height)
    {
      if (Interlocked.Increment(ref GraphicsDeviceService.referenceCount) == 1)
        GraphicsDeviceService.singletonInstance = new GraphicsDeviceService(windowHandle, width, height);
      return GraphicsDeviceService.singletonInstance;
    }

    public void Release(bool disposing)
    {
      if (Interlocked.Decrement(ref GraphicsDeviceService.referenceCount) != 0)
        return;
      if (disposing)
      {
        if (this.DeviceDisposing != null)
          this.DeviceDisposing((object) this, EventArgs.Empty);
        this.graphicsDevice.Dispose();
      }
      this.graphicsDevice = (GraphicsDevice) null;
    }

    public void ResetDevice(int width, int height)
    {
      if (this.DeviceResetting != null)
        this.DeviceResetting((object) this, EventArgs.Empty);
      this.parameters.BackBufferWidth = Math.Max(this.parameters.BackBufferWidth, width);
      this.parameters.BackBufferHeight = Math.Max(this.parameters.BackBufferHeight, height);
      this.graphicsDevice.Reset(this.parameters);
      if (this.DeviceReset == null)
        return;
      this.DeviceReset((object) this, EventArgs.Empty);
    }

    public GraphicsDevice GraphicsDevice
    {
      get
      {
        return this.graphicsDevice;
      }
    }

    public event EventHandler DeviceCreated;

    public event EventHandler DeviceDisposing;

    public event EventHandler DeviceReset;

    public event EventHandler DeviceResetting;
  }
}

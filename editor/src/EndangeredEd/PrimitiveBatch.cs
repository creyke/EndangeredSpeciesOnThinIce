// Decompiled with JetBrains decompiler
// Type: EndangeredEd.PrimitiveBatch
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EndangeredEd
{
  public class PrimitiveBatch : IDisposable
  {
    private VertexPositionColor[] vertices = new VertexPositionColor[500];
    private int positionInBuffer = 0;
    private bool hasBegun = false;
    private bool isDisposed = false;
    private const int DefaultBufferSize = 500;
    private VertexDeclaration vertexDeclaration;
    private BasicEffect basicEffect;
    private GraphicsDevice device;
    private PrimitiveType primitiveType;
    private int numVertsPerPrimitive;

    public PrimitiveBatch(GraphicsDevice graphicsDevice)
    {
      if (graphicsDevice == null)
        throw new ArgumentNullException(nameof (graphicsDevice));
      this.device = graphicsDevice;
      this.vertexDeclaration = new VertexDeclaration(/*graphicsDevice, */(VertexElement[]) VertexPositionColor.VertexDeclaration.GetVertexElements()); // TODO: Validate.
      this.basicEffect = new BasicEffect(graphicsDevice); // TODO: Validate., (EffectPool) null);
      this.basicEffect.VertexColorEnabled = true;
      BasicEffect basicEffect = this.basicEffect;
      double num1 = 0.0;
      Viewport viewport = graphicsDevice.Viewport;
      // ISSUE: explicit reference operation
      double width = (double) ((Viewport) @viewport).Width;
      viewport = graphicsDevice.Viewport;
      // ISSUE: explicit reference operation
      double height = (double) ((Viewport) @viewport).Height;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 1.0;
      Matrix orthographicOffCenter = Matrix.CreateOrthographicOffCenter((float) num1, (float) width, (float) height, (float) num2, (float) num3, (float) num4);
      basicEffect.Projection = orthographicOffCenter;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!disposing || this.isDisposed)
        return;
      if (this.vertexDeclaration != null)
        this.vertexDeclaration.Dispose();
      if (this.basicEffect != null)
        ((Effect) this.basicEffect).Dispose();
      this.isDisposed = true;
    }

    public void Begin(PrimitiveType primitiveType)
    {
      if (this.hasBegun)
        throw new InvalidOperationException("End must be called before Begin can be called again.");
      if (primitiveType == PrimitiveType.LineStrip) // TODO: Validate. || primitiveType == 6 || primitiveType == 5)
        throw new NotSupportedException("The specified primitiveType is not supported by PrimitiveBatch.");
      this.primitiveType = primitiveType;
      this.numVertsPerPrimitive = PrimitiveBatch.NumVertsPerPrimitive(primitiveType);
      //this.device.set_VertexDeclaration(this.vertexDeclaration); TODO: Validate.
      BasicEffect basicEffect = this.basicEffect;
      double num1 = 0.0;
      Viewport viewport = this.device.Viewport;
      // ISSUE: explicit reference operation
      double width = (double) ((Viewport) @viewport).Width;
      viewport = this.device.Viewport;
      // ISSUE: explicit reference operation
      double height = (double) ((Viewport) @viewport).Height;
      double num2 = 0.0;
      double num3 = 0.0;
      double num4 = 1.0;
      Matrix orthographicOffCenter = Matrix.CreateOrthographicOffCenter((float) num1, (float) width, (float) height, (float) num2, (float) num3, (float) num4);
      basicEffect.Projection = orthographicOffCenter;
      // TODO: Validate.
      //((Effect) this.basicEffect).Begin();
      //((Effect) this.basicEffect).get_CurrentTechnique().get_Passes().get_Item(0).Begin();
      // TODO: Validate.
      this.hasBegun = true;
    }

    public void AddVertex(Vector2 vertex, Color color)
    {
      if (!this.hasBegun)
        throw new InvalidOperationException("Begin must be called before AddVertex can be called.");
      if (this.positionInBuffer % this.numVertsPerPrimitive == 0 && this.positionInBuffer + this.numVertsPerPrimitive >= this.vertices.Length)
        this.Flush();
      this.vertices[this.positionInBuffer].Position = new Vector3(vertex, 0.0f);
      this.vertices[this.positionInBuffer].Color = color;
      ++this.positionInBuffer;
    }

    public void End()
    {
      if (!this.hasBegun)
        throw new InvalidOperationException("Begin must be called before End can be called.");
      this.Flush();
      // TODO: Validate.
      //((Effect) this.basicEffect).get_CurrentTechnique().get_Passes().get_Item(0).End();
      //((Effect) this.basicEffect).End();
      // TODO: Validate.
      this.hasBegun = false;
    }

    private void Flush()
    {
      if (!this.hasBegun)
        throw new InvalidOperationException("Begin must be called before Flush can be called.");
      if (this.positionInBuffer == 0)
        return;
      this.device.DrawUserPrimitives<VertexPositionColor>(this.primitiveType, this.vertices, 0, this.positionInBuffer / this.numVertsPerPrimitive);
      this.positionInBuffer = 0;
    }

    private static int NumVertsPerPrimitive(PrimitiveType primitive)
    {
      int num;
      switch (primitive - 1)
      {
        case PrimitiveType.TriangleList:
          num = 1;
          break;
        case PrimitiveType.TriangleStrip:
          num = 2;
          break;
        case PrimitiveType.LineStrip:
          num = 3;
          break;
        default:
          throw new InvalidOperationException("primitive is not valid");
      }
      return num;
    }
  }
}

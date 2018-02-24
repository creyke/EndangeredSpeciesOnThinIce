// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.ModelViewerControl
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace EndangeredEd.Xna
{
  public class ModelViewerControl : GraphicsDeviceControl
  {
    private Model model;
    private SpriteBatch spriteBatch;
    private Matrix[] boneTransforms;
    private Vector3 modelCenter;
    private float modelRadius;
    private Stopwatch timer;

    public Model Model
    {
      get
      {
        return this.model;
      }
      set
      {
        this.model = value;
        if (this.model == null)
          return;
        this.MeasureModel();
      }
    }

    public Level Level
    {
      get
      {
        return FormEditor.INSTANCE.Level;
      }
    }

    public SpriteBatch SpriteBatch
    {
      get
      {
        return this.spriteBatch;
      }
    }

    protected override void Initialize()
    {
      this.timer = Stopwatch.StartNew();
      Application.Idle += (EventHandler) delegate
      {
        this.Invalidate();
      };
      this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
    }

    protected override void Draw()
    {
    }

    private void MeasureModel()
    {
      this.boneTransforms = new Matrix[((ReadOnlyCollection<ModelBone>) this.model.get_Bones()).Count];
      this.model.CopyAbsoluteBoneTransformsTo(this.boneTransforms);
      this.modelCenter = Vector3.get_Zero();
      using (ModelMeshCollection.Enumerator enumerator = this.model.get_Meshes().GetEnumerator())
      {
        // ISSUE: explicit reference operation
        while (((ModelMeshCollection.Enumerator) @enumerator).MoveNext())
        {
          // ISSUE: explicit reference operation
          ModelMesh current = ((ModelMeshCollection.Enumerator) @enumerator).get_Current();
          Vector3 vector3 = Vector3.Transform((Vector3) current.get_BoundingSphere().Center, this.boneTransforms[current.get_ParentBone().get_Index()]);
          ModelViewerControl modelViewerControl = this;
          modelViewerControl.modelCenter = Vector3.op_Addition(modelViewerControl.modelCenter, vector3);
        }
      }
      ModelViewerControl modelViewerControl1 = this;
      modelViewerControl1.modelCenter = Vector3.op_Division(modelViewerControl1.modelCenter, (float) ((ReadOnlyCollection<ModelMesh>) this.model.get_Meshes()).Count);
      this.modelRadius = 0.0f;
      using (ModelMeshCollection.Enumerator enumerator = this.model.get_Meshes().GetEnumerator())
      {
        // ISSUE: explicit reference operation
        while (((ModelMeshCollection.Enumerator) @enumerator).MoveNext())
        {
          // ISSUE: explicit reference operation
          ModelMesh current = ((ModelMeshCollection.Enumerator) @enumerator).get_Current();
          BoundingSphere boundingSphere = current.get_BoundingSphere();
          Matrix boneTransform = this.boneTransforms[current.get_ParentBone().get_Index()];
          Vector3 vector3_1 = Vector3.Transform((Vector3) boundingSphere.Center, boneTransform);
          // ISSUE: explicit reference operation
          Vector3 vector3_2 = ((Matrix) @boneTransform).get_Forward();
          // ISSUE: explicit reference operation
          float num = ((Vector3) @vector3_2).Length();
          vector3_2 = Vector3.op_Subtraction(vector3_1, this.modelCenter);
          // ISSUE: explicit reference operation
          this.modelRadius = Math.Max(this.modelRadius, ((Vector3) @vector3_2).Length() + (float) boundingSphere.Radius * num);
        }
      }
    }
  }
}

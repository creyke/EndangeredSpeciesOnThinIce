// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_FinishGate
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_FinishGate : MA_EnvironmentEntity
  {
    public override MA_Entity Clone()
    {
      MA_FinishGate maFinishGate = new MA_FinishGate();
      maFinishGate.id = this.id;
      maFinishGate.name = this.name;
      maFinishGate.asset = this.asset;
      maFinishGate.spriteAsset = this.spriteAsset;
      maFinishGate.spriteSize = this.spriteSize;
      maFinishGate.position = Vector2.get_Zero();
      maFinishGate.offset = this.offset;
      return (MA_Entity) maFinishGate;
    }
  }
}

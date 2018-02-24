// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_StartGate
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_StartGate : MA_EnvironmentEntity
  {
    public override MA_Entity Clone()
    {
      MA_StartGate maStartGate = new MA_StartGate();
      maStartGate.id = this.id;
      maStartGate.name = this.name;
      maStartGate.asset = this.asset;
      maStartGate.spriteAsset = this.spriteAsset;
      maStartGate.spriteSize = this.spriteSize;
      maStartGate.position = Vector2.get_Zero();
      maStartGate.offset = this.offset;
      return (MA_Entity) maStartGate;
    }
  }
}

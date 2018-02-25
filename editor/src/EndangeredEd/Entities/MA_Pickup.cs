// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Pickup
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_Pickup : MA_Entity
  {
    public override MA_Entity Clone()
    {
      MA_Pickup maPickup = new MA_Pickup();
      maPickup.id = this.id;
      maPickup.name = this.name;
      maPickup.asset = this.asset;
      maPickup.spriteAsset = this.spriteAsset;
      maPickup.spriteSize = this.spriteSize;
      maPickup.position = Vector2.Zero;
      maPickup.offset = this.offset;
      return (MA_Entity) maPickup;
    }
  }
}

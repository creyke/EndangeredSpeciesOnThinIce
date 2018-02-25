// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_PlayerPolarBear
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_PlayerPolarBear : MA_PlayerCharacter
  {
    public override MA_Entity Clone()
    {
      MA_PlayerPolarBear maPlayerPolarBear = new MA_PlayerPolarBear();
      maPlayerPolarBear.id = this.id;
      maPlayerPolarBear.name = this.name;
      maPlayerPolarBear.asset = this.asset;
      maPlayerPolarBear.spriteAsset = this.spriteAsset;
      maPlayerPolarBear.spriteSize = this.spriteSize;
      maPlayerPolarBear.position = Vector2.Zero;
      maPlayerPolarBear.offset = this.offset;
      return (MA_Entity) maPlayerPolarBear;
    }
  }
}

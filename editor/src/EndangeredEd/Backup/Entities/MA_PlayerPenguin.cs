// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_PlayerPenguin
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_PlayerPenguin : MA_PlayerCharacter
  {
    public override MA_Entity Clone()
    {
      MA_PlayerPenguin maPlayerPenguin = new MA_PlayerPenguin();
      maPlayerPenguin.id = this.id;
      maPlayerPenguin.name = this.name;
      maPlayerPenguin.asset = this.asset;
      maPlayerPenguin.spriteAsset = this.spriteAsset;
      maPlayerPenguin.spriteSize = this.spriteSize;
      maPlayerPenguin.position = Vector2.get_Zero();
      maPlayerPenguin.offset = this.offset;
      return (MA_Entity) maPlayerPenguin;
    }
  }
}

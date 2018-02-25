// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_CharacterEntity
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_CharacterEntity : MA_Entity
  {
    public override MA_Entity Clone()
    {
      MA_CharacterEntity maCharacterEntity = new MA_CharacterEntity();
      maCharacterEntity.id = this.id;
      maCharacterEntity.name = this.name;
      maCharacterEntity.asset = this.asset;
      maCharacterEntity.spriteAsset = this.spriteAsset;
      maCharacterEntity.spriteSize = this.spriteSize;
      maCharacterEntity.position = Vector2.Zero;
      maCharacterEntity.offset = this.offset;
      return (MA_Entity) maCharacterEntity;
    }
  }
}

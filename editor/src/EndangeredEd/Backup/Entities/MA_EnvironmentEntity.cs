// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_EnvironmentEntity
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_EnvironmentEntity : MA_Entity
  {
    public override MA_Entity Clone()
    {
      MA_EnvironmentEntity environmentEntity = new MA_EnvironmentEntity();
      environmentEntity.id = this.id;
      environmentEntity.name = this.name;
      environmentEntity.asset = this.asset;
      environmentEntity.spriteAsset = this.spriteAsset;
      environmentEntity.spriteSize = this.spriteSize;
      environmentEntity.position = Vector2.get_Zero();
      environmentEntity.offset = this.offset;
      return (MA_Entity) environmentEntity;
    }
  }
}

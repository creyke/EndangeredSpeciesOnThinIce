// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_IceBlock
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Entities
{
  public class MA_IceBlock : MA_EnvironmentEntity
  {
    public override MA_Entity Clone()
    {
      MA_IceBlock maIceBlock = new MA_IceBlock();
      maIceBlock.id = this.id;
      maIceBlock.name = this.name;
      maIceBlock.asset = this.asset;
      maIceBlock.spriteAsset = this.spriteAsset;
      maIceBlock.spriteSize = this.spriteSize;
      maIceBlock.position = Vector2.Zero;
      maIceBlock.offset = this.offset;
      return (MA_Entity) maIceBlock;
    }
  }
}

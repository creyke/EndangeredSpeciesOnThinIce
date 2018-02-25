// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Checkpoint
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using System.Xml.Serialization;

namespace EndangeredEd.Entities
{
  [XmlRoot("MA_Checkpoint")]
  public class MA_Checkpoint : MA_EnvironmentEntity
  {
    public override MA_Entity Clone()
    {
      MA_Checkpoint maCheckpoint = new MA_Checkpoint();
      maCheckpoint.id = this.id;
      maCheckpoint.name = this.name;
      maCheckpoint.asset = this.asset;
      maCheckpoint.spriteAsset = this.spriteAsset;
      maCheckpoint.spriteSize = this.spriteSize;
      maCheckpoint.position = Vector2.Zero;
      maCheckpoint.offset = this.offset;
      return (MA_Entity) maCheckpoint;
    }
  }
}

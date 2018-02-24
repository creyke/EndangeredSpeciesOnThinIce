// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Sign
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using System.ComponentModel;

namespace EndangeredEd.Entities
{
  public class MA_Sign : MA_EnvironmentEntity
  {
    protected string signText;

    [Description("The text this sign displays.")]
    [Category("MA_Sign")]
    public string SignText
    {
      get
      {
        return this.signText;
      }
      set
      {
        this.signText = value;
      }
    }

    public override MA_Entity Clone()
    {
      MA_Sign maSign = new MA_Sign();
      maSign.id = this.id;
      maSign.name = this.name;
      maSign.asset = this.asset;
      maSign.spriteAsset = this.spriteAsset;
      maSign.spriteSize = this.spriteSize;
      maSign.position = Vector2.get_Zero();
      maSign.offset = this.offset;
      maSign.signText = this.signText;
      return (MA_Entity) maSign;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Enums.TGL
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;

namespace EndangeredEd.Enums
{
  public class TGL
  {
    public int tileId;
    public Vector2 rel;

    public TGL(int tileId, int relX, int relY)
    {
      this.tileId = tileId;
      this.rel = new Vector2((float) relX, (float) relY);
    }
  }
}

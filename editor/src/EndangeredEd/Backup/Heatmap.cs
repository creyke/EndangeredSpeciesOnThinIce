// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Heatmap
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using System;
using System.IO;

namespace EndangeredEd
{
  public class Heatmap
  {
    private Vector2[] positionPoints;
    private int[] pointIds;

    public Vector2[] PositionPoints
    {
      get
      {
        return this.positionPoints;
      }
    }

    public int[] PointIds
    {
      get
      {
        return this.pointIds;
      }
    }

    public Heatmap(string path)
    {
      string[] strArray1 = new StreamReader(path).ReadToEnd().Split(new string[1]
      {
        ", "
      }, StringSplitOptions.None);
      this.positionPoints = new Vector2[strArray1.Length];
      this.pointIds = new int[strArray1.Length];
      for (int index = 0; index < strArray1.Length; ++index)
      {
        string[] strArray2 = strArray1[index].Split(new string[1]
        {
          ": "
        }, StringSplitOptions.None);
        if (strArray2[0] == "| ")
          break;
        this.positionPoints[index] = new Vector2((float) (Convert.ToInt32(this.CleanStr(strArray2[0])) >> 8), (float) (Convert.ToInt32(this.CleanStr(strArray2[1])) >> 8));
        this.pointIds[index] = strArray2[2] == " d " ? 1 : 0;
        if (index < 100)
          Console.WriteLine((object) this.positionPoints[index]);
      }
    }

    private string CleanStr(string s)
    {
      string str = "";
      for (int startIndex = 0; startIndex < s.Length; ++startIndex)
      {
        for (int index = 0; index < 10; ++index)
        {
          if (s.Substring(startIndex, 1) == string.Concat((object) index))
            str += (string) (object) s[startIndex];
        }
      }
      return str;
    }
  }
}

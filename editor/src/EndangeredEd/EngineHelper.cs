// Decompiled with JetBrains decompiler
// Type: EndangeredEd.EngineHelper
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace EndangeredEd
{
  public static class EngineHelper
  {
    public static List<string> GetAllClasses(string nameSpace)
    {
      Assembly executingAssembly = Assembly.GetExecutingAssembly();
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      foreach (Type type in executingAssembly.GetTypes())
      {
        if (type.Namespace == nameSpace)
          stringList1.Add(type.Name);
      }
      foreach (string str in stringList1)
        stringList2.Add(str);
      return stringList2;
    }

    public static Vector2 GetSpriteSize(SpriteSize spriteSize)
    {
      switch (spriteSize)
      {
        case SpriteSize.OBJ_SIZE_16X16:
          return new Vector2(16f, 16f);
        case SpriteSize.OBJ_SIZE_32X32:
          return new Vector2(32f, 32f);
        case SpriteSize.OBJ_SIZE_64X64:
          return new Vector2(64f, 64f);
        default:
          return new Vector2(32f, 32f);
      }
    }

    public static Texture2D XNATextureFromBitmap(Bitmap b, GraphicsDevice device)
    {
      Texture2D texture2D = new Texture2D(device, b.Width, b.Height);
      System.Drawing.Color[] colorArray = new System.Drawing.Color[b.Width * b.Height];
      int index = 0;
      for (int y = 0; y < b.Height; ++y)
      {
        for (int x = 0; x < b.Width; ++x)
        {
          System.Drawing.Color pixel = b.GetPixel(x, y);
          if ((int) pixel.R == (int) byte.MaxValue && (int) pixel.G == 0 && (int) pixel.B == (int) byte.MaxValue && (int) pixel.A == (int) byte.MaxValue)
          {
            colorArray[index] = System.Drawing.Color.FromArgb((byte)0, byte.MaxValue, (byte) 0, byte.MaxValue);
          }
          else
          {
            colorArray[index] = System.Drawing.Color.FromArgb(byte.MaxValue, pixel.R, pixel.G, pixel.B);
          }
          ++index;
        }
      }
      texture2D.SetData<System.Drawing.Color>(colorArray);
      return texture2D;
    }

    public static string EvaluateRelativePath(string mainDirPath, string absoluteFilePath)
    {
      string[] strArray1 = mainDirPath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
      string[] strArray2 = absoluteFilePath.Trim(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
      int num = 0;
      for (int index = 0; index < Math.Min(strArray1.Length, strArray2.Length) && strArray1[index].ToLower().Equals(strArray2[index].ToLower()); ++index)
        ++num;
      if (num == 0)
        return absoluteFilePath;
      string str = string.Empty;
      for (int index = num; index < strArray1.Length; ++index)
      {
        if (index > num)
          str += (string) (object) Path.DirectorySeparatorChar;
        str += "..";
      }
      if (str.Length == 0)
        str = ".";
      for (int index = num; index < strArray2.Length; ++index)
        str = str + (object) Path.DirectorySeparatorChar + strArray2[index];
      return str;
    }
  }
}

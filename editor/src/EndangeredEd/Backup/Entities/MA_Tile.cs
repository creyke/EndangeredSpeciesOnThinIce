// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Tile
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Enums;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;

namespace EndangeredEd.Entities
{
  public class MA_Tile : MA_Entity
  {
    private TileGroup tileGroup = TileGroup.NoGroup;
    public const float SHADOW_MULT = 0.2f;
    public static Texture2D[] tileTextures;
    private bool isMoving;
    private Vector2 moveVector;

    [Description("Defines whether this entity follow a path or is it static.")]
    [Category("MA_Tile")]
    public bool IsMoving
    {
      get
      {
        return this.isMoving;
      }
      set
      {
        this.isMoving = value;
      }
    }

    [Description("Defines which tile group this tile uses.")]
    [Category("MA_Tile")]
    public TileGroup TileGroup
    {
      get
      {
        return this.tileGroup;
      }
      set
      {
        this.tileGroup = value;
      }
    }

    [Category("MA_Tile")]
    [Description("The relative movement point target for this entity.")]
    public Vector2 MoveVector
    {
      get
      {
        return this.moveVector;
      }
      set
      {
        this.moveVector = value;
      }
    }

    public static void SetupTileIndexes()
    {
    }

    public static void LoadTileGroups(string gfxPath, GraphicsDevice graphics)
    {
      FileInfo[] files = new DirectoryInfo(gfxPath).GetFiles("*.bmp", SearchOption.TopDirectoryOnly);
      MA_Tile.tileTextures = new Texture2D[files.Length];
      for (int index = 0; index < files.Length; ++index)
        MA_Tile.tileTextures[index] = EngineHelper.XNATextureFromBitmap(new Bitmap(files[index].FullName), graphics);
    }

    public override MA_Entity Clone()
    {
      MA_Tile maTile = new MA_Tile();
      maTile.id = this.id;
      maTile.name = this.name;
      maTile.asset = this.asset;
      maTile.spriteAsset = this.spriteAsset;
      maTile.spriteSize = this.spriteSize;
      maTile.position = Vector2.get_Zero();
      maTile.offset = this.offset;
      maTile.isMoving = this.isMoving;
      maTile.moveVector = this.moveVector;
      maTile.tileGroup = this.tileGroup;
      return (MA_Entity) maTile;
    }

    public override void Draw(SpriteBatch spriteBatch, bool animate)
    {
      if (this.tileGroup == TileGroup.NoGroup)
      {
        base.Draw(spriteBatch, animate);
      }
      else
      {
        this.SpecialDraw(spriteBatch, animate, Vector2.get_Zero(), false);
        if (this.isMoving && Vector2.op_Inequality(this.moveVector, Vector2.get_Zero()))
          this.SpecialDraw(spriteBatch, animate, this.moveVector, true);
      }
    }

    protected void SpecialDraw(SpriteBatch spriteBatch, bool animate, Vector2 specialOffset, bool shadow)
    {
      this.animationFrame = 0U;
      this.srcRectangle.Y = (__Null) 0;
      Color color = this.selected ? new Color(byte.MaxValue, (byte) 0, (byte) 0, (byte) 128) : new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      if (shadow)
      {
        // ISSUE: explicit reference operation
        // ISSUE: explicit reference operation
        ((Color) @color).set_A(Convert.ToByte((float) Convert.ToInt32(((Color) @color).get_A()) * 0.2f));
      }
      spriteBatch.Draw(MA_Tile.tileTextures[(int) this.tileGroup], Vector2.op_Addition(new Vector2((float) this.destRectangle.X, (float) this.destRectangle.Y), specialOffset), color);
      spriteBatch.Draw(MA_Entity.ORIGIN_TEXTURE, Vector2.op_Subtraction(this.position, new Vector2(7f, 7f)), Color.get_White());
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Entity
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Enums;
using EndangeredEd.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EndangeredEd.Entities
{
  [XmlInclude(typeof (MA_EnvironmentEntity))]
  [XmlInclude(typeof (MA_Tile))]
  [XmlInclude(typeof (MA_PlayerCharacter))]
  [XmlInclude(typeof (MA_CharacterEntity))]
  [XmlInclude(typeof (MA_PlayerPenguin))]
  [XmlInclude(typeof (MA_PlayerPolarBear))]
  [XmlInclude(typeof (MA_IceBlock))]
  [XmlInclude(typeof (MA_Node))]
  [XmlInclude(typeof (MA_StartGate))]
  [XmlInclude(typeof (MA_FinishGate))]
  [XmlInclude(typeof (MA_Pickup))]
  [XmlInclude(typeof (MA_Checkpoint))]
  [XmlInclude(typeof (MA_Sign))]
  public class MA_Entity
  {
    protected uint animationFrame = 0;
    protected Vector2 position = Vector2.get_Zero();
    protected Vector2 offset = Vector2.get_Zero();
    protected Rectangle destRectangle = Rectangle.get_Empty();
    protected Rectangle srcRectangle = Rectangle.get_Empty();
    public static Texture2D ORIGIN_TEXTURE;
    protected string asset;
    protected Texture2D assetTexture;
    protected uint id;
    protected PictureBox image;
    protected string name;
    protected string spriteAsset;
    protected SpriteSize spriteSize;
    protected bool selected;

    [Browsable(false)]
    [XmlIgnore]
    public bool Selected
    {
      get
      {
        return this.selected;
      }
      set
      {
        this.selected = value;
      }
    }

    [ReadOnly(true)]
    [Description("The internal id of this entity.")]
    [Category("Information")]
    public uint ID
    {
      get
      {
        return this.id;
      }
      set
      {
        this.id = value;
      }
    }

    [Description("The name of this entity.")]
    [Category("Information")]
    public string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        this.name = value;
      }
    }

    [Category("Sprite")]
    [Description("The asset of the sprite of this entity.")]
    public string SpriteAsset
    {
      get
      {
        return this.spriteAsset;
      }
      set
      {
        this.spriteAsset = value;
        this.UpdateAsset();
      }
    }

    [Category("Sprite")]
    [Description("The size of the entity in pixels.")]
    public SpriteSize SpriteSize
    {
      get
      {
        return this.spriteSize;
      }
      set
      {
        this.spriteSize = value;
        this.UpdateWorldRectangle();
      }
    }

    [Description("The position of the entity in pixels.")]
    [Category("Translation")]
    public Vector2 Position
    {
      get
      {
        return this.position;
      }
      set
      {
        this.position = value;
        this.UpdateWorldRectangle();
      }
    }

    [Description("The offset of the sprite from the entity's position.")]
    [Category("Translation")]
    public Vector2 Offset
    {
      get
      {
        return this.offset;
      }
      set
      {
        this.offset = value;
        this.UpdateWorldRectangle();
      }
    }

    public virtual MA_Entity Clone()
    {
      return new MA_Entity()
      {
        id = this.id,
        name = this.name,
        asset = this.asset,
        spriteAsset = this.spriteAsset,
        spriteSize = this.spriteSize,
        position = Vector2.get_Zero(),
        offset = this.offset
      };
    }

    public bool SelectCheck(int pX, int pY)
    {
      // ISSUE: explicit reference operation
      return ((Rectangle) @this.destRectangle).Contains(pX, pY);
    }

    public void LoadContent(ContentManager manager)
    {
      this.assetTexture = (Texture2D) manager.Load<Texture2D>(FormEditor.GRAPHICS_PATH + this.asset);
    }

    public void UpdateAsset()
    {
      if (this.spriteAsset == null || this.spriteAsset.Length <= 0)
        return;
      this.assetTexture = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.GRAPHICS_PATH + "\\" + this.spriteAsset), FormEditor.INSTANCE.XnaViewer.GraphicsDevice);
    }

    public void UpdateWorldRectangle()
    {
      Vector2 vector2 = Vector2.op_Subtraction(this.position, this.offset);
      Vector2 spriteSize = EngineHelper.GetSpriteSize(this.spriteSize);
      this.destRectangle.X = (__Null) (int) vector2.X;
      this.destRectangle.Y = (__Null) (int) vector2.Y;
      this.destRectangle.Width = (__Null) (int) spriteSize.X;
      this.destRectangle.Height = (__Null) (int) spriteSize.Y;
      this.srcRectangle.Width = (__Null) (int) spriteSize.X;
      this.srcRectangle.Height = (__Null) (int) spriteSize.Y;
    }

    public virtual void Draw(SpriteBatch spriteBatch, bool animate)
    {
      if (this.assetTexture != null)
      {
        if (animate)
        {
          uint num = (uint) (this.assetTexture.get_Height() / this.destRectangle.Height);
          ++this.animationFrame;
          if (this.animationFrame >= num)
            this.animationFrame = 0U;
          this.srcRectangle.Y = (__Null) (int) ((double) this.animationFrame * EngineHelper.GetSpriteSize(this.spriteSize).Y);
        }
        else
        {
          this.animationFrame = 0U;
          this.srcRectangle.Y = (__Null) 0;
        }
        if (this.selected)
          spriteBatch.Draw(this.assetTexture, this.destRectangle, new Rectangle?(this.srcRectangle), new Color(byte.MaxValue, (byte) 0, (byte) 0, (byte) 128));
        else
          spriteBatch.Draw(this.assetTexture, this.destRectangle, new Rectangle?(this.srcRectangle), Color.get_White());
      }
      spriteBatch.Draw(MA_Entity.ORIGIN_TEXTURE, Vector2.op_Subtraction(this.position, new Vector2(7f, 7f)), Color.get_White());
    }
  }
}

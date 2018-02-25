// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Level
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Entities;
using EndangeredEd.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace EndangeredEd
{
  public class Level
  {
    public const string DEFAULT_FILE_NAME = "Untitled.esl";
    protected List<MA_Entity> entities;
    protected string fileName;
    protected PictureBox levelBackground;
    protected Panel levelCanvas;
    protected List<EndangeredEd.Entities.MA_Node> nodes;
    protected string author;
    protected string background;
    protected string buildPath;
    protected uint height;
    protected string name;
    protected uint width;
    protected uint targetFishCountGold;
    protected uint targetFishCountSilver;
    protected uint targetFishCountBronze;
    protected int newTargetTimeGold;
    protected int newTargetTimeSilver;
    protected int newTargetTimeBronze;
    protected TimeSpan targetTimeGold;
    protected TimeSpan targetTimeSilver;
    protected TimeSpan targetTimeBronze;
    protected string asset;
    protected Texture2D assetTexture;
    protected int totalNodesGen;

    [XmlIgnore]
    [Browsable(false)]
    public string FileName
    {
      get
      {
        return this.fileName;
      }
      set
      {
        this.fileName = value;
      }
    }

    [XmlIgnore]
    [Browsable(false)]
    public PictureBox LevelBackground
    {
      get
      {
        return this.levelBackground;
      }
      set
      {
        this.levelBackground = value;
        this.UpdateBackgroundImage();
      }
    }

    [Browsable(false)]
    [XmlIgnore]
    public Panel LevelCanvas
    {
      get
      {
        return this.levelCanvas;
      }
      set
      {
        this.levelCanvas = value;
      }
    }

    [Category("Entities")]
    [Description("All entities in the level.")]
    public List<MA_Entity> Entities
    {
      get
      {
        return this.entities;
      }
      set
      {
        this.entities = value;
      }
    }

    [XmlIgnore]
    [Browsable(false)]
    public List<EndangeredEd.Entities.MA_Node> Nodes
    {
      get
      {
        return this.nodes;
      }
      set
      {
        this.nodes = value;
      }
    }

    [Browsable(false)]
    [XmlIgnore]
    public List<EndangeredEd.Entities.MA_Node> MA_Node
    {
      get
      {
        return this.nodes;
      }
      set
      {
        this.nodes = value;
      }
    }

    [Category("Info")]
    [Description("The author of the level.")]
    public string Author
    {
      get
      {
        return this.author;
      }
      set
      {
        this.author = value;
      }
    }

    [Description("The background image for the level.")]
    [Category("Info")]
    public string Background
    {
      get
      {
        return this.background;
      }
      set
      {
        this.background = value;
        this.UpdateBackgroundImage();
      }
    }

    [Description("The path of the .cpp source file built from the .esl file.")]
    [Category("Info")]
    public string BuildPath
    {
      get
      {
        return this.buildPath;
      }
      set
      {
        this.buildPath = value;
      }
    }

    [Category("Info")]
    [Description("The name of the level.")]
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

    [Category("Translation")]
    [Description("The height of the level in pixels.")]
    public uint Height
    {
      get
      {
        return this.height;
      }
      set
      {
        this.height = value;
        if (this.levelBackground != null)
        {
          this.levelBackground.Height = (int) value;
        }
        if (this.levelCanvas != null)
        {
          this.levelCanvas.Height = (int) value + 32;
        }
        this.UpdateBackgroundImage();
      }
    }

    [Description("The width of the level in pixels.")]
    [Category("Translation")]
    public uint Width
    {
      get
      {
        return this.width;
      }
      set
      {
        this.width = value;
        if (this.levelBackground != null)
        {
          this.levelBackground.Width = (int) value;
        }
        if (this.levelCanvas != null)
        {
          this.levelCanvas.Width = (int) value + 32;
        }
        this.UpdateBackgroundImage();
      }
    }

    [Category("Target Fish Count")]
    [Description("The target number of fish to achieve a gold medal.")]
    public uint TargetFishCountGold
    {
      get
      {
        return this.targetFishCountGold;
      }
      set
      {
        this.targetFishCountGold = value;
      }
    }

    [Category("Target Fish Count")]
    [Description("The target number of fish to achieve a silver medal.")]
    public uint TargetFishCountSilver
    {
      get
      {
        return this.targetFishCountSilver;
      }
      set
      {
        this.targetFishCountSilver = value;
      }
    }

    [Description("The target number of fish to achieve a bronze medal.")]
    [Category("Target Fish Count")]
    public uint TargetFishCountBronze
    {
      get
      {
        return this.targetFishCountBronze;
      }
      set
      {
        this.targetFishCountBronze = value;
      }
    }

    [Category("Target Times")]
    [Description("The target time to achieve a gold medal.")]
    public int NewTargetTime1Gold
    {
      get
      {
        return this.newTargetTimeGold;
      }
      set
      {
        this.newTargetTimeGold = value;
      }
    }

    [Description("The target time to achieve a silver medal.")]
    [Category("Target Times")]
    public int NewTargetTime2Silver
    {
      get
      {
        return this.newTargetTimeSilver;
      }
      set
      {
        this.newTargetTimeSilver = value;
      }
    }

    [Category("Target Times")]
    [Description("The target time to achieve a bronze medal.")]
    public int NewTargetTime3Bronze
    {
      get
      {
        return this.newTargetTimeBronze;
      }
      set
      {
        this.newTargetTimeBronze = value;
      }
    }

    [Description("The target time to achieve a gold medal.")]
    [Browsable(false)]
    [Category("Target Times")]
    public TimeSpan TargetTimeGold
    {
      get
      {
        return this.targetTimeGold;
      }
      set
      {
        this.targetTimeGold = value;
      }
    }

    [Description("The target time to achieve a silver medal.")]
    [Browsable(false)]
    [Category("Target Times")]
    public TimeSpan TargetTimeSilver
    {
      get
      {
        return this.targetTimeSilver;
      }
      set
      {
        this.targetTimeSilver = value;
      }
    }

    [Browsable(false)]
    [Description("The target time to achieve a bronze medal.")]
    [Category("Target Times")]
    public TimeSpan TargetTimeBronze
    {
      get
      {
        return this.targetTimeBronze;
      }
      set
      {
        this.targetTimeBronze = value;
      }
    }

    [ReadOnly(true)]
    [Description("The total nodes ever generated in this level.")]
    [Category("Info")]
    public int TotalNodesGen
    {
      get
      {
        return this.totalNodesGen;
      }
      set
      {
        this.totalNodesGen = value;
      }
    }

    public Level()
    {
      this.totalNodesGen = 0;
    }

    public Level(PictureBox levelBackground, Panel levelCanvas)
    {
      this.author = "";
      this.name = "Untitled Level";
      this.fileName = "Untitled.esl";
      this.levelBackground = levelBackground;
      this.levelCanvas = levelCanvas;
      this.entities = new List<MA_Entity>();
      this.nodes = new List<EndangeredEd.Entities.MA_Node>();
      this.Width = 512U;
      this.Height = 512U;
      this.levelBackground.BackgroundImage = (Image) new Bitmap((int) this.Width, (int) this.Height);
    }

    public int GetNextNodeId()
    {
      ++this.totalNodesGen;
      return this.totalNodesGen;
    }

    public static Level Load(string fileName, PictureBox levelBackground, Panel levelCanvas)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (Level));
      TextReader textReader = (TextReader) new StreamReader(fileName);
      Level level = (Level) xmlSerializer.Deserialize(textReader);
      textReader.Close();
      level.FileName = fileName;
      level.LevelBackground = levelBackground;
      level.LevelCanvas = levelCanvas;
      return level;
    }

    public void LoadContent(ContentManager manager)
    {
      this.assetTexture = (Texture2D) manager.Load<Texture2D>(FormEditor.GRAPHICS_PATH + this.asset);
    }

    public void Save()
    {
      XmlSerializer xmlSerializer = new XmlSerializer(this.GetType());
      TextWriter textWriter = (TextWriter) new StreamWriter(this.fileName);
      try
      {
        xmlSerializer.Serialize(textWriter, (object) this);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        textWriter.Close();
      }
    }

    private void UpdateBackgroundImage()
    {
      FormEditor.INSTANCE.XnaViewer.Width = (int) this.Width;
      FormEditor.INSTANCE.XnaViewer.Height = (int) this.Height;
      if (this.background == null || this.background.Length <= 0)
        return;
      this.assetTexture = EngineHelper.XNATextureFromBitmap(new Bitmap(FormEditor.GRAPHICS_PATH + "\\" + this.background), FormEditor.INSTANCE.XnaViewer.GraphicsDevice);
    }

    public void Draw(SpriteBatch spriteBatch, PrimitiveBatch primitiveBatch, bool animate, ListView.ListViewItemCollection entVis)
    {
      if (this.assetTexture != null)
      {
        spriteBatch.Begin(SpriteSortMode.Immediate); // TODO: Validate. (SpriteBlendMode) 1);
        for (int index1 = 0; (long) index1 < 1L + (long) this.Width / (long) this.assetTexture.Width; ++index1)
        {
          for (int index2 = 0; (long) index2 < 1L + (long) this.Height / (long) this.assetTexture.Height; ++index2)
            spriteBatch.Draw(this.assetTexture, new Vector2((float) (index1 * this.assetTexture.Width), (float) (index2 * this.assetTexture.Height)), Microsoft.Xna.Framework.Color.White);
        }
        spriteBatch.End();
      }
      // TODO: Add back.
      return;
      primitiveBatch.Begin((PrimitiveType) 2);
      for (int index1 = 0; index1 < this.entities.Count; ++index1)
      {
        if (this.entities[index1].GetType() == typeof (EndangeredEd.Entities.MA_Node))
        {
          for (int index2 = 0; index2 < (this.entities[index1] as EndangeredEd.Entities.MA_Node).Neighbours.Count; ++index2)
          {
            primitiveBatch.AddVertex(this.entities[index1].Position, Microsoft.Xna.Framework.Color.White);
            for (int index3 = 0; index3 < this.entities.Count; ++index3)
            {
              if (this.entities[index3].GetType() == typeof (EndangeredEd.Entities.MA_Node) && (this.entities[index3] as EndangeredEd.Entities.MA_Node).NodeID == (this.entities[index1] as EndangeredEd.Entities.MA_Node).Neighbours[index2])
              {
                primitiveBatch.AddVertex(this.entities[index3].Position, Microsoft.Xna.Framework.Color.White);
                break;
              }
            }
          }
        }
      }
      primitiveBatch.End();
      spriteBatch.Begin();
      for (int index1 = 0; index1 < this.entities.Count; ++index1)
      {
        for (int index2 = 0; index2 < entVis.Count; ++index2)
        {
          if (this.entities[index1].GetType().Name == entVis[index2].Text)
          {
            if (entVis[index2].Checked)
              this.entities[index1].Draw(spriteBatch, animate);
            index2 = entVis.Count;
          }
        }
      }
      spriteBatch.End();
    }
  }
}

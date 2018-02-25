// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Entities.MA_Node
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace EndangeredEd.Entities
{
  public class MA_Node : MA_Entity
  {
    public static Texture2D LINKED_TEXTURE;
    public static Texture2D UNLINKED_TEXTURE;
    public static Texture2D SHARK_LINKED_TEXTURE;
    public static Texture2D SHARK_UNLINKED_TEXTURE;
    protected int nodeId;
    protected List<int> neighbours;
    protected bool sharkNode;

    public int NodeID
    {
      get
      {
        return this.nodeId;
      }
      set
      {
        this.nodeId = value;
      }
    }

    public List<int> Neighbours
    {
      get
      {
        return this.neighbours;
      }
      set
      {
        this.neighbours = value;
      }
    }

    public bool SharkNode
    {
      get
      {
        return this.sharkNode;
      }
      set
      {
        this.sharkNode = value;
      }
    }

    public MA_Node()
    {
      this.neighbours = new List<int>();
    }

    public void AddNeighbour(MA_Node neighbour)
    {
      for (int index = 0; index < this.neighbours.Count; ++index)
      {
        if (this.neighbours[index] == neighbour.NodeID)
          return;
      }
      this.neighbours.Add(neighbour.NodeID);
      neighbour.Neighbours.Add(this.NodeID);
    }

    public void RemoveNeighbour(MA_Node neighbour)
    {
      Console.WriteLine("RemoveNeighbour()");
      try
      {
        this.neighbours.Remove(neighbour.NodeID);
        neighbour.Neighbours.Remove(this.NodeID);
      }
      catch (Exception ex)
      {
      }
    }

    public void DeleteNode()
    {
      this.neighbours.Clear();
    }

    public override void Draw(SpriteBatch spriteBatch, bool animate)
    {
      this.animationFrame = 0U;
      this.srcRectangle.Y = 0;
      Texture2D texture2D = this.neighbours.Count <= 0 ? (this.sharkNode ? MA_Node.SHARK_UNLINKED_TEXTURE : MA_Node.UNLINKED_TEXTURE) : (this.sharkNode ? MA_Node.SHARK_LINKED_TEXTURE : MA_Node.LINKED_TEXTURE);
      spriteBatch.Draw(texture2D, this.destRectangle, new Rectangle?(this.srcRectangle), this.selected ? new Color(byte.MaxValue, (byte) 0, (byte) 0, (byte) 128) : Color.White);
      int num = 0;
      while (num < this.neighbours.Count)
        ++num;
    }
  }
}

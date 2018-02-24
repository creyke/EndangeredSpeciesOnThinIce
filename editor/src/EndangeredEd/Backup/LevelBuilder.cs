// Decompiled with JetBrains decompiler
// Type: EndangeredEd.LevelBuilder
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using EndangeredEd.Entities;
using EndangeredEd.Enums;
using EndangeredEd.Forms;
using System;
using System.Collections.Generic;
using System.IO;

namespace EndangeredEd
{
  public static class LevelBuilder
  {
    public const string DQ = "\"";

    public static void Build(string buildPath, Level level, string version, FormBuildProgress bpf)
    {
      LevelBuilder.WriteHFile(buildPath, level, version, bpf);
      LevelBuilder.WriteCPPFile(buildPath, level, version, bpf);
    }

    private static void WriteHFile(string buildPath, Level level, string version, FormBuildProgress bpf)
    {
      string withoutExtension = Path.GetFileNameWithoutExtension(buildPath);
      StreamWriter text = File.CreateText(Path.GetDirectoryName(buildPath) + "\\" + withoutExtension + ".h");
      LevelBuilder.WriteHeaderComment(text, level, version);
      text.WriteLine("#pragma once");
      text.WriteLine("");
      text.WriteLine("#include \"MA_LevelDescription.h\"");
      text.WriteLine("");
      text.WriteLine("class " + withoutExtension + " : public MA_LevelDescription");
      text.WriteLine("{");
      text.WriteLine("public:");
      text.WriteLine("    " + withoutExtension + "();");
      text.WriteLine("};");
      text.WriteLine("");
      text.Close();
    }

    private static void WriteCPPFile(string buildPath, Level level, string version, FormBuildProgress bpf)
    {
      StreamWriter text = File.CreateText(buildPath);
      string withoutExtension = Path.GetFileNameWithoutExtension(buildPath);
      LevelBuilder.WriteHeaderComment(text, level, version);
      text.WriteLine("#include \"MA_LevelContainer.h\"");
      text.WriteLine("#include \"" + withoutExtension + ".h\"");
      text.WriteLine("#include \"all_gfx.h\"");
      text.WriteLine("");
      text.WriteLine(withoutExtension + "::" + withoutExtension + "() : MA_LevelDescription()");
      text.WriteLine("{");
      text.WriteLine("    // NB all coordinates are (x<<8)");
      text.WriteLine("    this->levelName = \"" + level.Name + "\";");
      text.WriteLine("    ");
      text.WriteLine("    // Set the dimension of the level");
      text.WriteLine("    this->levelWidth = " + (object) level.Width + "<<8;");
      text.WriteLine("    this->levelHeight = " + (object) level.Height + "<<8;");
      text.WriteLine("    ");
      text.WriteLine("    // Define the goal requirements for pickups (gold, silver, bronze)");
      text.WriteLine("    this->pickupRequirements[0] = " + (object) level.TargetFishCountGold + ";");
      text.WriteLine("    this->pickupRequirements[1] = " + (object) level.TargetFishCountSilver + ";");
      text.WriteLine("    this->pickupRequirements[2] = " + (object) level.TargetFishCountBronze + ";");
      text.WriteLine("    ");
      text.WriteLine("    // Define the time allowance in seconds for gold, silver, bronze");
      text.WriteLine("    this->totalTimeRequirements[0] = " + (object) level.NewTargetTime1Gold + ";");
      text.WriteLine("    this->totalTimeRequirements[1] = " + (object) level.NewTargetTime2Silver + ";");
      text.WriteLine("    this->totalTimeRequirements[2] = " + (object) level.NewTargetTime3Bronze + ";");
      text.WriteLine("    ");
      text.WriteLine("    // Add some tiles (xPos, yPos, tileIndex, moving, moveVectorX, movevectorY, movespeed)");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_Tile) == entity.GetType())
        {
          MA_Tile maTile = entity as MA_Tile;
          if (maTile.TileGroup == TileGroup.NoGroup)
            text.WriteLine("    this->AddTile(" + (object) (int) maTile.Position.X + "<<8, " + (object) (int) maTile.Position.Y + "<<8, " + (object) 0 + ", " + (maTile.IsMoving ? (object) "true" : (object) "false") + ", " + (object) (int) maTile.MoveVector.X + "<<8, " + (object) (int) maTile.MoveVector.Y + "<<8, " + (object) 1 + ");");
          else
            text.WriteLine("    this->CreateTileSet(" + (object) (int) maTile.Position.X + "<<8, " + (object) (int) maTile.Position.Y + "<<8, " + (object) maTile.TileGroup + ", " + (maTile.IsMoving ? (object) "true" : (object) "false") + ", " + (object) (int) maTile.MoveVector.X + "<<8, " + (object) (int) maTile.MoveVector.Y + "<<8, " + (object) 1 + ");");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add pickups");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_Pickup) == entity.GetType())
        {
          MA_Pickup maPickup = entity as MA_Pickup;
          text.WriteLine("    this->AddCollectable(" + (object) (int) maPickup.Position.X + "<<8, " + (object) (int) maPickup.Position.Y + "<<8, " + (object) (int) maPickup.Offset.X + "<<8, " + (object) (int) maPickup.Offset.Y + "<<8, (void*)fishjump_Sprite, " + (object) maPickup.SpriteSize + ");");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add signs");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_Sign) == entity.GetType())
        {
          MA_Sign maSign = entity as MA_Sign;
          text.WriteLine("    this->AddSign(" + (object) (int) maSign.Position.X + "<<8, " + (object) (int) maSign.Position.Y + "<<8, " + (object) (int) maSign.Offset.X + "<<8, " + (object) (int) maSign.Offset.Y + "<<8, (void*)sign_3_Sprite, " + (object) maSign.SpriteSize + ", \"" + maSign.SignText + "\");");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add checkpoints");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_Checkpoint) == entity.GetType())
        {
          MA_Checkpoint maCheckpoint = entity as MA_Checkpoint;
          text.WriteLine("    this->AddCheckpoint(" + (object) (int) maCheckpoint.Position.X + "<<8, " + (object) (int) maCheckpoint.Position.Y + "<<8, " + (object) (int) maCheckpoint.Offset.X + "<<8, " + (object) (int) maCheckpoint.Offset.Y + "<<8, (void*)snowman_Sprite, " + (object) maCheckpoint.SpriteSize + ");");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add penguin");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_PlayerPenguin) == entity.GetType())
        {
          MA_PlayerPenguin maPlayerPenguin = entity as MA_PlayerPenguin;
          text.WriteLine("    this->AddPenguin(" + (object) (int) maPlayerPenguin.Position.X + "<<8, " + (object) (int) maPlayerPenguin.Position.Y + "<<8);");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add polar bear(s)");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_PlayerPolarBear) == entity.GetType())
        {
          MA_PlayerPolarBear maPlayerPolarBear = entity as MA_PlayerPolarBear;
          text.WriteLine("    this->AddPolarBear(" + (object) (int) maPlayerPolarBear.Position.X + "<<8, " + (object) (int) maPlayerPolarBear.Position.Y + "<<8);");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add ice blocks");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_IceBlock) == entity.GetType())
        {
          MA_IceBlock maIceBlock = entity as MA_IceBlock;
          text.WriteLine("    this->AddIceBlock(" + (object) (int) maIceBlock.Position.X + "<<8, " + (object) (int) maIceBlock.Position.Y + "<<8);");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add start gate");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_StartGate) == entity.GetType())
        {
          MA_StartGate maStartGate = entity as MA_StartGate;
          text.WriteLine("    this->AddStartGate(" + (object) (int) maStartGate.Position.X + "<<8, " + (object) (int) maStartGate.Position.Y + "<<8);");
        }
      }
      text.WriteLine("    ");
      text.WriteLine("    // Add finish gate");
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_FinishGate) == entity.GetType())
        {
          MA_FinishGate maFinishGate = entity as MA_FinishGate;
          text.WriteLine("    this->AddFinishGate(" + (object) (int) maFinishGate.Position.X + "<<8, " + (object) (int) maFinishGate.Position.Y + "<<8);");
        }
      }
      text.WriteLine("    ");
      int num = 0;
      foreach (object entity in level.Entities)
      {
        if (typeof (MA_Node) == entity.GetType())
          ++num;
      }
      text.WriteLine("    // Create shark nodes - make sure to give the nodes neighbours otherwise the shark will get stuck");
      text.WriteLine("    this->sharkNodeCount = " + (object) num + ";");
      text.WriteLine("    ");
      text.WriteLine("    // Create an array of nodes");
      text.WriteLine("    this->sharkNodes = new MA_Node[this->sharkNodeCount];");
      text.WriteLine("    ");
      List<MA_Node> maNodeList = new List<MA_Node>();
      foreach (MA_Entity entity in level.Entities)
      {
        if (typeof (MA_Node) == entity.GetType())
          maNodeList.Add(entity as MA_Node);
      }
      for (int index1 = 0; index1 < maNodeList.Count; ++index1)
      {
        MA_Node maNode = maNodeList[index1];
        text.WriteLine("    this->sharkNodes[" + (object) index1 + "].X = " + (object) (float) maNode.Position.X + " << 8;");
        text.WriteLine("    this->sharkNodes[" + (object) index1 + "].Y = " + (object) (float) maNode.Position.Y + " << 8;");
        for (int index2 = 0; index2 < maNode.Neighbours.Count; ++index2)
        {
          for (int index3 = 0; index3 < maNodeList.Count; ++index3)
          {
            if (maNodeList[index3].NodeID == maNode.Neighbours[index2])
              text.WriteLine("    this->sharkNodes[" + (object) index1 + "].AddNeighbour(" + (object) index3 + ");");
          }
        }
        if (maNode.SharkNode)
          text.WriteLine("    this->AddShark(" + (object) index1 + ");");
        text.WriteLine("    ");
      }
      text.WriteLine("}");
      text.Close();
    }

    private static void WriteHeaderComment(StreamWriter file, Level level, string version)
    {
      file.WriteLine("// All code Copyright © 2010 Mobile Asylum");
      file.WriteLine("//   Level generated with EndangeredEd v" + version);
      file.WriteLine("//");
      file.WriteLine("// Level Name:          " + level.Name);
      file.WriteLine("// Level Author(s):     " + level.Author);
      file.WriteLine("// Build Date/Time:     " + (object) DateTime.Now);
      file.WriteLine("// Map File Location:   \"" + Path.GetDirectoryName(level.FileName) + "\"");
      file.WriteLine("// Map File Name:       \"" + Path.GetFileName(level.FileName) + "\"");
      file.WriteLine("//");
      file.WriteLine("");
    }

    private static string ConstructEntity(MA_Entity entity)
    {
      return "new " + entity.GetType().Name + "(" + "\"" + entity.Name + "\", " + (object) (float) entity.Position.X + ", " + (object) (float) entity.Position.Y + ", " + Path.GetFileNameWithoutExtension(entity.SpriteAsset) + "_Sprite, " + (object) entity.SpriteSize + ")";
    }
  }
}

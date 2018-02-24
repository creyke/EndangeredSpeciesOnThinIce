// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.ContentBuilder
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Build.BuildEngine;
using Microsoft.Build.Framework;
using System;
using System.Diagnostics;
using System.IO;

namespace EndangeredEd.Xna
{
  public class ContentBuilder : IDisposable
  {
    private static string[] pipelineAssemblies = new string[4]
    {
      "Microsoft.Xna.Framework.Content.Pipeline.FBXImporter, Version=3.1.0.0, PublicKeyToken=6d5c3888ef60e27d",
      "Microsoft.Xna.Framework.Content.Pipeline.XImporter, Version=3.1.0.0, PublicKeyToken=6d5c3888ef60e27d",
      "Microsoft.Xna.Framework.Content.Pipeline.TextureImporter, Version=3.1.0.0, PublicKeyToken=6d5c3888ef60e27d",
      "Microsoft.Xna.Framework.Content.Pipeline.EffectImporter, Version=3.1.0.0, PublicKeyToken=6d5c3888ef60e27d"
    };
    private const string xnaVersion = ", Version=3.1.0.0, PublicKeyToken=6d5c3888ef60e27d";
    private Engine msBuildEngine;
    private Project msBuildProject;
    private ErrorLogger errorLogger;
    private string buildDirectory;
    private string processDirectory;
    private string baseDirectory;
    private static int directorySalt;
    private bool isDisposed;

    public string OutputDirectory
    {
      get
      {
        return Path.Combine(this.buildDirectory, "bin/Content");
      }
    }

    public ContentBuilder()
    {
      this.CreateTempDirectory();
      this.CreateBuildProject();
    }

    ~ContentBuilder()
    {
      this.Dispose(false);
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.isDisposed)
        return;
      this.isDisposed = true;
      this.DeleteTempDirectory();
    }

    private void CreateBuildProject()
    {
      string str = Path.Combine(this.buildDirectory, "content.contentproj");
      string propertyValue = Path.Combine(this.buildDirectory, "bin");
      this.msBuildEngine = new Engine();
      this.errorLogger = new ErrorLogger();
      this.msBuildEngine.RegisterLogger((ILogger) this.errorLogger);
      this.msBuildProject = new Project(this.msBuildEngine);
      this.msBuildProject.FullFileName = str;
      this.msBuildProject.SetProperty("XnaPlatform", "Windows");
      this.msBuildProject.SetProperty("XnaFrameworkVersion", "v2.0");
      this.msBuildProject.SetProperty("Configuration", "Release");
      this.msBuildProject.SetProperty("OutputPath", propertyValue);
      foreach (string pipelineAssembly in ContentBuilder.pipelineAssemblies)
        this.msBuildProject.AddNewItem("Reference", pipelineAssembly);
      this.msBuildProject.AddNewImport("$(MSBuildExtensionsPath)\\Microsoft\\XNA Game Studio\\v3.1\\Microsoft.Xna.GameStudio.ContentPipeline.targets", (string) null);
    }

    public void Add(string filename, string name, string importer, string processor)
    {
      BuildItem buildItem = this.msBuildProject.AddNewItem("Compile", filename);
      buildItem.SetMetadata("Link", Path.GetFileName(filename));
      buildItem.SetMetadata("Name", name);
      if (!string.IsNullOrEmpty(importer))
        buildItem.SetMetadata("Importer", importer);
      if (string.IsNullOrEmpty(processor))
        return;
      buildItem.SetMetadata("Processor", processor);
    }

    public void Clear()
    {
      this.msBuildProject.RemoveItemsByName("Compile");
    }

    public string Build()
    {
      this.errorLogger.Errors.Clear();
      if (!this.msBuildProject.Build())
        return string.Join("\n", this.errorLogger.Errors.ToArray());
      return (string) null;
    }

    private void CreateTempDirectory()
    {
      this.baseDirectory = Path.Combine(Path.GetTempPath(), this.GetType().FullName);
      this.processDirectory = Path.Combine(this.baseDirectory, Process.GetCurrentProcess().Id.ToString());
      ++ContentBuilder.directorySalt;
      this.buildDirectory = Path.Combine(this.processDirectory, ContentBuilder.directorySalt.ToString());
      Directory.CreateDirectory(this.buildDirectory);
      this.PurgeStaleTempDirectories();
    }

    private void DeleteTempDirectory()
    {
      Directory.Delete(this.buildDirectory, true);
      if (Directory.GetDirectories(this.processDirectory).Length != 0)
        return;
      Directory.Delete(this.processDirectory);
      if (Directory.GetDirectories(this.baseDirectory).Length == 0)
        Directory.Delete(this.baseDirectory);
    }

    private void PurgeStaleTempDirectories()
    {
      foreach (string directory in Directory.GetDirectories(this.baseDirectory))
      {
        int result;
        if (int.TryParse(Path.GetFileName(directory), out result))
        {
          try
          {
            Process.GetProcessById(result);
          }
          catch (ArgumentException ex)
          {
            Directory.Delete(directory, true);
          }
        }
      }
    }
  }
}

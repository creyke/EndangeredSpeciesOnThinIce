// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.ErrorLogger
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using Microsoft.Build.Framework;
using System.Collections.Generic;

namespace EndangeredEd.Xna
{
  internal class ErrorLogger : ILogger
  {
    private List<string> errors = new List<string>();
    private LoggerVerbosity verbosity = LoggerVerbosity.Normal;
    private string parameters;

    public void Initialize(IEventSource eventSource)
    {
      if (eventSource == null)
        return;
      eventSource.ErrorRaised += new BuildErrorEventHandler(this.ErrorRaised);
    }

    public void Shutdown()
    {
    }

    private void ErrorRaised(object sender, BuildErrorEventArgs e)
    {
      this.errors.Add(e.Message);
    }

    public List<string> Errors
    {
      get
      {
        return this.errors;
      }
    }

    string ILogger.Parameters
    {
      get
      {
        return this.parameters;
      }
      set
      {
        this.parameters = value;
      }
    }

    LoggerVerbosity ILogger.Verbosity
    {
      get
      {
        return this.verbosity;
      }
      set
      {
        this.verbosity = value;
      }
    }
  }
}

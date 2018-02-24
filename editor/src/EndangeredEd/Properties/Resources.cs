// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Properties.Resources
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace EndangeredEd.Properties
{
  [DebuggerNonUserCode]
  [CompilerGenerated]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (EndangeredEd.Properties.Resources.resourceMan == null)
          EndangeredEd.Properties.Resources.resourceMan = new ResourceManager("EndangeredEd.Properties.Resources", typeof (EndangeredEd.Properties.Resources).Assembly);
        return EndangeredEd.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return EndangeredEd.Properties.Resources.resourceCulture;
      }
      set
      {
        EndangeredEd.Properties.Resources.resourceCulture = value;
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: EndangeredEd.Xna.ServiceContainer
// Assembly: EndangeredEd, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A9D3335-6488-4FF6-AEAD-B31776F888E4
// Assembly location: C:\Working\Uni\Wiki\editor\EndangeredEd1016\EndangeredEd1016\Editor\EndangeredEd\bin\x86\Debug\EndangeredEd.exe

using System;
using System.Collections.Generic;

namespace EndangeredEd.Xna
{
  public class ServiceContainer : IServiceProvider
  {
    private Dictionary<Type, object> services = new Dictionary<Type, object>();

    public void AddService<T>(T service)
    {
      this.services.Add(typeof (T), (object) service);
    }

    public object GetService(Type serviceType)
    {
      object obj;
      this.services.TryGetValue(serviceType, out obj);
      return obj;
    }
  }
}

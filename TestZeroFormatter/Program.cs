using System;
using System.Collections.Generic;
using System.IO;
using ZeroFormatter;

namespace TestZeroFormatter
{
  internal class Program
  {
    private const string Dir = "../serialized";

    public static void Main(string[] args) {
      // directory check
      if (!Directory.Exists(Dir)) {
        Directory.CreateDirectory(Dir);
      }

      Console.WriteLine("start packing...");

      List<Int32> a = new List<Int32>() {1,2,3};

        // packing
      PackSimple<Int32>(123);
      PackSimple<List<Int32>>(a, "ListInt32");
      PackObject<Data.Primitive>();
      PackObject<Data.PrimitiveNullable>();

      Console.WriteLine("completed.");
    }

    private static void PackSimple<T>(T value, string name = "")
    {
      var data = ZeroFormatterSerializer.Serialize<T>(value);
      SaveAndCheck<T>(data, name);
    }

    private static void PackObject<T>(string name = "") where T : Base, new()
    {
      T obj = new T();
      obj.DataSet();
      var data = ZeroFormatterSerializer.Serialize<T>(obj);
      SaveAndCheck<T>(data, name);
    }

    private static void SaveAndCheck<T>(byte[] data, string name)
    {
      // save
      File.WriteAllBytes(PackName<T>(name), data);
      Console.WriteLine(typeof(T).Name + " is packed !!");

      // deserialize check
      FileStream fs = new FileStream(PackName<T>(name), FileMode.Open);
      byte[] bs = new byte[fs.Length];
      fs.Read(bs, 0, bs.Length);

      // deserialize
      ZeroFormatterSerializer.Deserialize<T>(bs);
      Console.WriteLine("deserialize ok");
    }

    private static string PackName<T>(string name)
    {
      if (name.Length < 1)
      {
        name = typeof(T).Name;
      }
      return Dir + "/" + name + ".pack";
    }
  }
}
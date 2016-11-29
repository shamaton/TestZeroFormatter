using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
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

      // packing
      PackSimple<Int32>(123);
      PackObject<Data.Primitive>();
      PackObject<Data.PrimitiveNullable>();

      Console.WriteLine("completed.");
    }

    private static void PackSimple<T>(T value)
    {
      var data = ZeroFormatterSerializer.Serialize<T>(value);
      SaveAndCheck<T>(data);
    }

    private static void PackObject<T>() where T : Base, new()
    {
      T obj = new T();
      obj.DataSet();
      var data = ZeroFormatterSerializer.Serialize<T>(obj);
      SaveAndCheck<T>(data);
    }

    private static void SaveAndCheck<T>(byte[] data)
    {
      // save
      File.WriteAllBytes(PackName<T>(), data);
      Console.WriteLine(typeof(T).Name + " is packed !!");

      // deserialize check
      FileStream fs = new FileStream(PackName<T>(), FileMode.Open);
      byte[] bs = new byte[fs.Length];
      fs.Read(bs, 0, bs.Length);

      // deserialize
      ZeroFormatterSerializer.Deserialize<T>(bs);
      Console.WriteLine("deserialize ok");
    }

    private static string PackName<T>()
    {
      return Dir + "/" + typeof(T).Name + ".pack";
    }
  }
}
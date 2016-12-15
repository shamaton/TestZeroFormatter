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

      List<int> ints = new List<int>() {1,2,3,4,5,6,7,8,9,Int32.MaxValue};
      List<string> strings = new List<string>() {"Can","you","see","this","array","message","?"};

      Dictionary<int, int> intMap = new Dictionary<int, int>()
      {
        {1,2},{3,4}
      };
      Dictionary<string, string> stringMap = new Dictionary<string, string>()
      {
        {"one","two"},{"three","four"},{"five","six"}
      };

      // packing
      PackSimple<Int16>(-16);
      PackSimple<Int32>(-32);
      PackSimple<Int64>(-64);
      PackSimple<UInt16>(16);
      PackSimple<UInt32>(32);
      PackSimple<UInt64>(64);
      PackSimple<Single>(1.23456f);
      PackSimple<Double>(2.3456789);
      PackSimple<bool>(false);
      PackSimple<Byte>(255);
      PackSimple<SByte>(-127);
      PackSimple<Char>('a');
      PackSimple<TimeSpan>(TimeSpan.FromSeconds(10));
      PackSimple<DateTime>(DateTime.Now);
      PackSimple<DateTimeOffset>(DateTimeOffset.Now);
      PackSimple<String>("This is simple pack.");

      PackSimple<List<int>>(ints, "ListInt");
      PackSimple<List<string>>(strings, "ListString");

      PackSimple<Dictionary<int, int>>(intMap, "MapInt");
      PackSimple<Dictionary<string, string>>(stringMap, "MapString");

      PackObject<Data.Primitive>();
      PackObject<Data.PrimitiveNullable>();
      PackObject<Data.Comparison>();

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
      string s = name.Length < 1 ? typeof(T).Name : name;
      // save
      File.WriteAllBytes(PackName<T>(name), data);
      Console.WriteLine("packed : " + s );

      // deserialize check
      FileStream fs = new FileStream(PackName<T>(name), FileMode.Open);
      byte[] bs = new byte[fs.Length];
      fs.Read(bs, 0, bs.Length);

      // deserialize
      ZeroFormatterSerializer.Deserialize<T>(bs);
      //Console.WriteLine("deserialize ok");
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
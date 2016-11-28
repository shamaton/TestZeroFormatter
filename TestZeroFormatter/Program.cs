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

      // packing
      Pack<Data.Primitive>();
      Pack<Data.PrimitiveNullable>();

      // desealize
      CheckPack<Data.Primitive>();
      CheckPack<Data.PrimitiveNullable>();
      Console.WriteLine("data check sucessfully!!");
    }

    private static void Pack<T>() where T : Base, new()
    {
      Console.WriteLine(typeof(T).Name + " is packing...");

      T obj = new T();
      obj.DataSet();
      var data = ZeroFormatterSerializer.Serialize<T>(obj);
      File.WriteAllBytes(PackName<T>(), data);

      Console.WriteLine(typeof(T).Name + " is packed !!");
    }

    private static void CheckPack<T>() where T : new()
    {
      // StreamReaderでファイルを読み込む
      FileStream fs = new FileStream(PackName<T>(), FileMode.Open);

      //ファイルを読み込むバイト型配列を作成する
      byte[] bs = new byte[fs.Length];
      //ファイルの内容をすべて読み込む
      fs.Read(bs, 0, bs.Length);

      var data = ZeroFormatterSerializer.Deserialize<T>(bs);
    }

    private static string PackName<T>()
    {
      return Dir + "/" + typeof(T).Name + ".pack";
    }
  }
}
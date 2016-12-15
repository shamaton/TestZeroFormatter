using System;
using ZeroFormatter;

namespace TestZeroFormatter
{
  namespace Data
  {
    [ZeroFormattable]
    public class Comparison : Base
    {
      [Index(0)]  public virtual int             Int32          { get; set; }
      [Index(1)]  public virtual uint            UInt32         { get; set; }
      [Index(2)]  public virtual float           Float          { get; set; }
      [Index(3)]  public virtual double          Double         { get; set; }
      [Index(4)]  public virtual bool            Bool           { get; set; }
      [Index(5)] public virtual string          String         { get; set; }

      public override void DataSet() {
        Int32          = Int32.MinValue;
        UInt32         = UInt32.MaxValue;
        Float          = Single.MinValue;
        Double         = Double.MaxValue;
        Bool           = true;
        String         = "Hello!! Can you see this text?";
      }
    }
  }
}
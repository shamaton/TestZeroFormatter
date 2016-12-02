using System;
using ZeroFormatter;

namespace TestZeroFormatter
{
  namespace Data
  {
    [ZeroFormattable]
    public class Primitive : Base
    {
      [Index(0)]  public virtual Int16           Int16          { get; set; }
      [Index(1)]  public virtual int             Int32          { get; set; }
      [Index(2)]  public virtual Int64           Int64          { get; set; }
      [Index(3)]  public virtual UInt16          UInt16         { get; set; }
      [Index(4)]  public virtual uint            UInt32         { get; set; }
      [Index(5)]  public virtual UInt64          UInt64         { get; set; }
      [Index(6)]  public virtual float           Float          { get; set; }
      [Index(7)]  public virtual double          Double         { get; set; }
      [Index(8)]  public virtual bool            Bool           { get; set; }
      [Index(9)]  public virtual byte            Byte           { get; set; }
      [Index(10)] public virtual sbyte           SByte          { get; set; }
      [Index(11)] public virtual char            Char           { get; set; }
      [Index(12)] public virtual TimeSpan        TimeSpan       { get; set; }
      [Index(13)] public virtual DateTime        DateTime       { get; set; }
      [Index(14)] public virtual DateTimeOffset  DateTimeOffset { get; set; }
      [Index(15)] public virtual string          String         { get; set; }

      public override void DataSet() {
        Int16          = Int16.MinValue;
        Int32          = Int32.MinValue;
        Int64          = Int64.MinValue;
        UInt16         = UInt16.MaxValue;
        UInt32         = UInt32.MaxValue;
        UInt64         = UInt64.MaxValue;
        Float          = Single.MinValue;
        Double         = Double.MaxValue;
        Bool           = true;
        Byte           = Byte.MinValue;
        SByte          = SByte.MaxValue;
        Char           = 'a';
        TimeSpan       = TimeSpan.FromSeconds(1);
        DateTime       = DateTime.Now;
        DateTimeOffset = new DateTimeOffset(DateTime);
        String         = "Hello!! Can you see this text?";
      }
    }

    [ZeroFormattable]
    public class PrimitiveNullable : Base
    {
      [Index(0)]  public virtual Int16?          Int16Nullable          { get; set; }
      [Index(1)]  public virtual int?            Int32Nullable          { get; set; }
      [Index(2)]  public virtual Int64?          Int64Nullable          { get; set; }
      [Index(3)]  public virtual UInt16?         UInt16Nullable         { get; set; }
      [Index(4)]  public virtual uint?           UInt32Nullable         { get; set; }
      [Index(5)]  public virtual UInt64?         UInt64Nullable         { get; set; }
      [Index(6)]  public virtual float?          SingleNullable         { get; set; }
      [Index(7)]  public virtual double?         DoubleNullable         { get; set; }
      [Index(8)]  public virtual bool?           BooleanNullable        { get; set; }
      [Index(9)]  public virtual byte?           ByteNullable           { get; set; }
      [Index(10)] public virtual sbyte?          SByteNullable          { get; set; }
      [Index(11)] public virtual char?           CharNullable           { get; set; }
      [Index(12)] public virtual TimeSpan?       TimeSpanNullable       { get; set; }
      [Index(13)] public virtual DateTime?       DateTimeNullable       { get; set; }
      [Index(14)] public virtual DateTimeOffset? DateTimeOffsetNullable { get; set; }

      public override void DataSet() {
        Int16Nullable          = null;
        Int32Nullable          = null;
        Int64Nullable          = null;
        UInt16Nullable         = null;
        UInt32Nullable         = null;
        UInt64Nullable         = null;
        SingleNullable         = null;
        DoubleNullable         = null;
        BooleanNullable        = null;
        ByteNullable           = null;
        SByteNullable          = null;
        CharNullable           = null;
        TimeSpanNullable       = null;
        DateTimeNullable       = null;
        DateTimeOffsetNullable = null;
      }
    }
  }
}

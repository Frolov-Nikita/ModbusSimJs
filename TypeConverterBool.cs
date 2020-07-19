using System;

namespace ModbusSimJs
{
    public class TypeConverterBool : TypeConverterAbstract
    {
        public override ModbusValueType ValueType => ModbusValueType.Bool;

        public override int ByteLength => 1;

        public override object FromWords(ushort[] buffer)
        {
            return buffer[0] > 0;
        }

        public override ushort[] ToWords(object value)
        {
            return new ushort[] { (ushort)Convert.ChangeType(value, typeof(ushort)) > 0 ? (ushort)1 : (ushort)0 };
        }
    }
}

using System;

namespace ModbusSimJs
{
    public class TypeConverterInt16 : TypeConverterAbstract
    {
        public override ModbusValueType ValueType => ModbusValueType.Int16;

        public override int ByteLength => 2;

        public override object FromWords(ushort[] buffer)
        {
            return buffer[0];
        }

        public override ushort[] ToWords(object value)
        {
            return new ushort[] { (ushort)Convert.ChangeType(value, typeof(ushort)) };
        }
    }
}

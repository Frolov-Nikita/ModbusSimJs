using System;

namespace ModbusSimJs
{
    public class TypeConverterInt32 : TypeConverterAbstract
    {
        public override ModbusValueType ValueType => ModbusValueType.Int32;

        public override int ByteLength => 4;

        public override object FromWords(ushort[] buffer)
        {
            byte[] buff = new byte[ByteLength];
            for (int i = 0; i < WordsLength; i++)
                BitConverter.GetBytes(buffer[i]).CopyTo(buff, i * 2);

            return BitConverter.ToInt32(buff, 0);
        }

        public override ushort[] ToWords(object value)
        {
            var buff = BitConverter.GetBytes((Int32)Convert.ChangeType(value, typeof(Int32)));//(Int16)Convert.ChangeType(value, typeof(Int16))
            ushort[] buffer = new ushort[WordsLength];
            for (int i = 0; i < WordsLength; i++)
                buffer[i] = BitConverter.ToUInt16(buff, i * 2);
            return buffer;
        }
    }
}

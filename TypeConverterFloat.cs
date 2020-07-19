using System;

namespace ModbusSimJs
{
    public class TypeConverterFloat : TypeConverterAbstract
    {
        public override ModbusValueType ValueType => ModbusValueType.Float;

        public override int ByteLength => 4;

        public override object FromWords(ushort[] buffer)
        {
            byte[] buff = new byte[ByteLength];
            for (int i = 0; i < WordsLength; i++)
                BitConverter.GetBytes(buffer[i]).CopyTo(buff, i * 2);

            return BitConverter.ToSingle(buff, 0);
        }

        public override ushort[] ToWords(object value)
        {
            var buff = BitConverter.GetBytes((float)Convert.ChangeType(value, typeof(float)));
            ushort[] buffer = new ushort[WordsLength];
            for (int i = 0; i < WordsLength; i++)
                buffer[i] = BitConverter.ToUInt16(buff, i * 2);
            return buffer;
        }
    }
}

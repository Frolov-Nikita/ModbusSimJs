using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ModbusSimJs
{

    public class TagInfo
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        public virtual ushort Address { get; set; }

        public virtual object Value { get; set; }

        public virtual ModbusRegion Region { get; set; }

        public virtual ModbusValueType ValueType { get; set; }

        protected static readonly Dictionary<ValueType, TypeConverterAbstract> Converters = new Dictionary<ValueType, TypeConverterAbstract>
        {
            [ModbusValueType.Bool] = new TypeConverterBool(),
            [ModbusValueType.Float] = new TypeConverterFloat(),
            [ModbusValueType.Int16] = new TypeConverterInt16(),
            [ModbusValueType.Int32] = new TypeConverterInt32(),
        };

        // type name address // description \r\n
        // bool var1 1 // some usefull info  //// coils
        // bool var1 100_001 // some usefull info  //// discete inputs
        // int16 var1 300_001 // some usefull info //// inputregister
        // float var1 400_001 // some usefull info //// holdingregister

        // CurrentPV AT %MD53: REAL := 0;
        // Posision AT %MW108: INT := 0;
        // MainMotor_Tm       AT %MW430: ARRAY[0..1] OF UINT := [20, 60];
        public static bool TryParse(string line, out TagInfo info)
        {
            info = null;

            var src = line;
            var descr = "";
            var i = line.IndexOf("//");
            if (i != -1)
            {
                descr = line.Substring(i + 2).Trim();
                src = line.Substring(0, i).Trim();
            }

            src = src.Replace("\t", " ")
                .Replace(new String(' ', 320), " ")
                .Replace(new String(' ', 160), " ")
                .Replace(new String(' ', 80), " ")
                .Replace(new String(' ', 40), " ")
                .Replace(new String(' ', 20), " ")
                .Replace(new String(' ', 10), " ")
                .Replace(new String(' ', 5), " ")
                .Replace("   ", " ")
                .Replace("  ", " ");

            var success = TryParseFmt1(src, out info) ||
                TryParseCoDeSys(src, out info);

            if(success)
                info.Description = descr;

            return success;
        }

        private static bool TryParseFmt1(string line, out TagInfo info)
        {
            // bool var1 1 = true
            // bool var1 100_001 = 1
            // int16 var1 300_001 =2
            // float var1 400_001 =3
            info = null;

            var parts = line.Split(new char[] {' ', ':', '=' }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
                return false;

            var regexpName = new Regex(@"^[\$_A-z]+[\$_A-z0-9]*$");
            if (!regexpName.IsMatch(parts[1]))
                return false;

            if (!TryParseType(parts[0], out ModbusValueType type))
                return false;

            if (!TryParseAddress(parts[2], out ModbusRegion region, out ushort addr))
                return false;

            info = new TagInfo
            {
                Name = parts[1],
                Region = region,
                Address = addr,
                ValueType = type,
            };

            if ((parts.Length > 4) && (TryParseVal(parts[4], type, out object val)))
                info.Value = val;

            return true;
        }

        private static bool TryParseCoDeSys(string line, out TagInfo info)
        {
            // CurrentPV AT %MD53: REAL := 0;
            // Posision AT %MW108: INT := 0;
            // MainMotor_Tm       AT %MW430: ARRAY[0..1] OF UINT := [20, 60];//anything
            info = null;

            var lineLo = line.ToLower();
            if ((!lineLo.Contains(" at "))||
                (!lineLo.Contains(":")))
                return false;

            // имя
            var atIdx = lineLo.IndexOf(" at ");
            
            var name = line.Substring(0, atIdx).Trim();
            var regexpName = new Regex(@"^[\$_A-z]+[\$_A-z0-9]*$");
            if (!regexpName.IsMatch(name))
                return false;

            var colonIdx = lineLo.IndexOf(":");
            var addrStr = line.Substring(atIdx + 4, colonIdx - atIdx - 4).Trim();

            if (!TryParseAddress(addrStr, out ModbusRegion region, out ushort addr))
                return false;

            var semicolonIdx = line.IndexOf(";");
            semicolonIdx = semicolonIdx > 0 ? semicolonIdx : line.Length;
            var rest = line.Substring(colonIdx + 1, semicolonIdx - colonIdx - 1)
                .Replace(":=","=");
            var eqIdx = rest.IndexOf("=");
            var typeStr = rest.Substring(0, eqIdx).Trim();

            if (!TryParseType(typeStr, out ModbusValueType type))
                return false;

            info = new TagInfo
            {
                Name = name,
                Region = region,
                Address = addr,
                ValueType = type,                
            };

            if (TryParseVal(rest.Substring(eqIdx), type, out object val))
                info.Value = val;

            return true;
        }

        private static bool TryParseVal(string src, ModbusValueType type, out object val)
        {
            val = null;

            var defValStr = src
                .Trim()
                .ToLower()
                .Replace(',', '.')
                .Replace("_", "");

            if (defValStr == "")
            {
                switch (type)
                {
                    case ModbusValueType.Bool:
                        val = false;
                        break;
                    case ModbusValueType.Float:
                        val = 0.0f;
                        break;
                    case ModbusValueType.Int16:
                        val = (Int16)0;
                        break;
                    case ModbusValueType.Int32:
                        val = (Int32)0;
                        break;
                }
                return false;
            }

            bool success;

            switch (type)
            {
                case ModbusValueType.Bool:
                    val = defValStr != "0" && defValStr != "false";
                    success = true;
                    break;
                case ModbusValueType.Float:
                    success = float.TryParse(defValStr, out float valf);
                    if (success)
                        val = valf;
                    break;
                case ModbusValueType.Int16:
                    success = Int16.TryParse(defValStr, out Int16 vals);
                    if (success)
                        val = vals;
                    break;
                case ModbusValueType.Int32:
                    success = Int32.TryParse(defValStr, out Int32 vali);
                    if (success)
                        val = vali;
                    break;
                default:
                    return false;
            }

            return success;
        }

        private static bool TryParseType(string src, out ModbusValueType type)
        {
            type = ModbusValueType.Int16;

            var a = src.Trim().ToLower();
            if (a.StartsWith("array"))
                if (a.Contains(" "))
                    a = a.Substring(a.LastIndexOf(' '));
                else
                    return false;

            if (Enum.TryParse(a, true, out ModbusValueType tagType))
                return true;

            // экзотика
            switch (a)
            {
                case "bit":
                    type = ModbusValueType.Bool;
                    break;

                case "real":
                    type = ModbusValueType.Float;
                    break;

                case "sint":
                case "byte":
                case "word":
                case "int":
                    type = ModbusValueType.Int16;
                    break;

                case "usint":
                case "uint":
                    type = ModbusValueType.Int16;
                    break;

                case "dword":
                case "dint":
                    type = ModbusValueType.Int32;
                    break;

                case "lword":
                case "lint":
                case "ulint":
                case "lreal":
                default:
                    return false;
            }

            return true;
        }

        private static bool TryParseAddress(string src, out ModbusRegion region, out ushort addr) => 
            TryParseAddressFmtCoDeSys(src, out region, out addr) || 
            TryParseAddressFmt1(src, out region, out addr) ||
            TryParseAddressFmt2(src, out region, out addr);        

        private static bool TryParseAddressFmt1(string src, out ModbusRegion region, out ushort addr)
        {
            // offset format
            region = ModbusRegion.HoldingRegisters;
            addr = 1;

            if (!int.TryParse(src.Trim().Replace("_", ""), out int num))
                return false;

            if (num < 100_000)
            {
                region = ModbusRegion.Coils;
                num -= 1;
            }

            if ((num > 100_000) && (num < 300_000))
            {
                region = ModbusRegion.DiscreteInputs;
                num -= 100_001;
            }

            if ((num > 300_000) && (num < 400_000))
            {
                region = ModbusRegion.InputRegisters;
                num -= 300_001;
            }

            if ((num > 400_000) && (num < 500_000))
            {
                region = ModbusRegion.HoldingRegisters;
                num -= 400_001;
            }

            if ((num < 0) || num > ushort.MaxValue)
                return false;

            addr = (ushort)num;

            return true;
        }

        private static bool TryParseAddressFmt2(string src, out ModbusRegion region, out ushort addr)
        {
            // very old offset format
            region = ModbusRegion.HoldingRegisters;
            addr = 1;

            if (!int.TryParse(src.Trim().Replace("_", ""), out int num))
                return false;

            if (num < 10_000)
            {
                region = ModbusRegion.Coils;
                num -= 1;
            }

            if ((num > 10_000) && (num < 30_000))
            {
                region = ModbusRegion.DiscreteInputs;
                num -= 100_001;
            }

            if ((num > 30_000) && (num < 40_000))
            {
                region = ModbusRegion.InputRegisters;
                num -= 300_001;
            }

            if ((num > 40_000) && (num < 50_000))
            {
                region = ModbusRegion.HoldingRegisters;
                num -= 400_001;
            }

            if ((num < 0) || num > ushort.MaxValue)
                return false;

            addr = (ushort)num;

            return true;
        }

        private static bool TryParseAddressFmtCoDeSys( string src, out ModbusRegion region, out ushort addr)
        {
            // CoDeSys addr format ex.: %MW32768 %MW32768.16 %MW32768.16

            region = ModbusRegion.HoldingRegisters;
            addr = 1;

            bool isNum(char c) => c >= 0x30 && c <= 0x39;
            
            var a = src.Trim().Replace("%", "").ToUpper();
            
            var r = new Regex(@"^[MIQ0]+[A-Z]*[\.0-9]+$");
            if ((!r.IsMatch(a)) || (a.Length > 11) || (a.Length < 2))
                return false;

            var i = 1;
            for (; i < 5; i++)
                if (isNum(a[i]))
                    break;

            var regSrc = a.Substring(0, i);
            var aSrc = a.Substring(i).Split('.');

            // получим адрес
            if(aSrc.Length > 1)
                aSrc[0] += aSrc[1].PadLeft(2, '0');

            if(!ushort.TryParse(aSrc[0], out addr))
                return false;

            var isInput = regSrc.StartsWith("I");

            // получим регион
            if (regSrc.Length > 1)
            {
                region = isInput ? ModbusRegion.InputRegisters : ModbusRegion.HoldingRegisters;
                // Корректировка адреса по флагу размера
                switch (regSrc[1])
                {
                    case 'D':
                        addr *= 2;
                        break;
                    case 'L':
                        addr *= 4;
                        break;
                }
            }
            else
                region = isInput ? ModbusRegion.DiscreteInputs : ModbusRegion.Coils;
            
            return true;

        }
    }
}

using NModbus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs
{

    public class Tag : TagInfo, INotifyPropertyChanged
    {
        protected ISlaveDataStore SlaveStorage { get; }


        private ModbusValueType valueType = ModbusValueType.Int16;


        public Tag(ISlaveDataStore slaveStorage)
        {
            SlaveStorage = slaveStorage;
            Name = "NewTag";
            Address = 0;
            ValueType = ModbusValueType.Int16;
            Region = ModbusRegion.HoldingRegisters;
        }

        public Tag(TagInfo tagInfo, ISlaveDataStore slaveStorage)
        {
            SlaveStorage = slaveStorage;

            Name = tagInfo.Name;
            Description = tagInfo.Description;
            Address = tagInfo.Address;
            ValueType = tagInfo.ValueType;
            Region = tagInfo.Region;

            if (tagInfo.Value != default)
                Value = tagInfo.Value;
        }

        protected ushort ValueWordLength => Converters[ValueType].WordsLength;

        private string name;
        public override string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string description;

        public override string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    NotifyPropertyChanged();
                }
            }
        }

        ushort address = 0;
        public override ushort Address
        {
            get => address;
            set
            {
                if (address != value)
                {
                    address = value;
                    NotifyPropertyChanged();
                }
            }
        }

        ModbusRegion region = ModbusRegion.HoldingRegisters;
        public override ModbusRegion Region
        {
            get => region;
            set
            {
                if (region != value)
                {

                    region = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public override object Value
        {
            get
            {
                if (SlaveStorage == default)
                    return null;

                ushort[] words;
                switch (Region)
                {
                    case ModbusRegion.Coils:
                        return SlaveStorage.CoilDiscretes.ReadPoints(Address, 1)[0];
                    case ModbusRegion.DiscreteInputs:
                        return SlaveStorage.CoilInputs.ReadPoints(Address, 1)[0];
                    case ModbusRegion.InputRegisters:
                        words = SlaveStorage.InputRegisters.ReadPoints(Address, ValueWordLength);
                        break;
                    case ModbusRegion.HoldingRegisters:
                        words = SlaveStorage.HoldingRegisters.ReadPoints(Address, ValueWordLength);
                        break;
                    default:
                        throw new Exception("it can't be happand");
                }

                return Converters[ValueType].FromWords(words);
            }
            set
            {
                if (SlaveStorage == default)
                    return;

                switch (Region)
                {
                    case ModbusRegion.Coils:
                        SlaveStorage.CoilDiscretes.WritePoints(Address, new bool[] { (bool)value });
                        break;
                    case ModbusRegion.DiscreteInputs:
                        SlaveStorage.CoilInputs.WritePoints(Address, new bool[] { (bool)value });
                        break;
                    case ModbusRegion.InputRegisters:
                        SlaveStorage.InputRegisters.WritePoints(
                            Address,
                            Converters[ValueType].ToWords(value)
                            );
                        break;
                    case ModbusRegion.HoldingRegisters:
                        SlaveStorage.HoldingRegisters.WritePoints(
                            Address,
                            Converters[ValueType].ToWords(value)
                            );
                        break;
                    default:
                        throw new Exception("it can't be happand");
                }
                NotifyPropertyChanged();
            }
        }

        public override ModbusValueType ValueType
        {
            get
            {
                if ((Region == ModbusRegion.Coils) ||
                    (Region == ModbusRegion.DiscreteInputs))
                    return ModbusValueType.Bool;
                return valueType;
            }
            set
            {
                if (valueType != value)
                {
                    NotifyPropertyChanged();
                    valueType = value;
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

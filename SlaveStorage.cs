using NModbus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs
{
    internal class SlaveStorage : ISlaveDataStore
    {
        public SlaveStorage()
        {
        }

        public IPointSource<bool> CoilDiscretes { get; } = new PointSource<bool>();

        public IPointSource<bool> CoilInputs { get; } = new PointSource<bool>();

        public IPointSource<ushort> HoldingRegisters { get; } = new PointSource<ushort>();

        public IPointSource<ushort> InputRegisters { get; } = new PointSource<ushort>();

    }
}

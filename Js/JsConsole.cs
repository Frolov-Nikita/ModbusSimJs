using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs.Js
{
    public delegate void consoleMessageDelegate(consoleMessageType type, string msg);
    public delegate void consoleClearDelegate();

    public enum consoleMessageType
    {
        warn,
        log,
        error,
        info,
        comment
    }

    public class JsConsole
    {
        public event consoleMessageDelegate ConsoleMessageEvent;

        public event consoleClearDelegate ConsoleClearEvent;

        public void Clear() => ConsoleClearEvent?.Invoke();

        public void log(object msg) => ConsoleMessageEvent?.Invoke(consoleMessageType.log, msg.ToString());

        public void warn(object msg) => ConsoleMessageEvent?.Invoke(consoleMessageType.warn, msg.ToString());

        public void error(object msg) => ConsoleMessageEvent?.Invoke(consoleMessageType.error, msg.ToString());
    }
}

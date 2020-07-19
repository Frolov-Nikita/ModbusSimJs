using Microsoft.ClearScript.V8;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusSimJs.Js
{
    public class JsFile
    {
        V8ScriptEngine engine;

        V8Script code;

        public bool Ok { get; private set; } = false;

        public void Load(string fileName, Dictionary<string, object> hostObjects = null)
        {
            var src = File.ReadAllText(fileName);
            compileScript(src, hostObjects);
        }

        private void compileScript(string src, Dictionary<string, object> hostObjects = null)
        {
            Ok = false;
            engine = new V8ScriptEngine();
            code = engine.Compile(src);

            if(hostObjects != null)
                foreach(var kvp in hostObjects)
                    engine.AddHostObject(kvp.Key, kvp.Value);

            engine.Execute(code);
            Ok = true;

        }

        public void Loop()
        {
            if(Ok)
                engine?.Script?.loop();
        }
        

    }
}

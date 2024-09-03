using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EGGS.ScriptInterpreterComponents
{
    public abstract class MainInterpreter
    {
        public string _script;
        public JsonDocument jsonFile;
        public JsonElement curr;


        public MainInterpreter(string json)
        {

            string inBin = Directory.GetCurrentDirectory();
            string overBin = Directory.GetParent(inBin).FullName;
            string overOverBin = Directory.GetParent(overBin).FullName;
            string scriptPath = Directory.GetParent(overOverBin).FullName;
            this._script = Path.Combine(scriptPath, @"Scripts\" + json);

            string readJson = File.ReadAllText(_script);// read contents
            jsonFile = JsonDocument.Parse(readJson);
            JsonElement root = jsonFile.RootElement;

            this.curr = root[0];
        }

        virtual public string JsonInterpreter()
        {
            return String.Empty;
        }
    }
}

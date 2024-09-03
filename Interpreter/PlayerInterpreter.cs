// PlayerInterpreter.cs

using System.IO;

namespace EGGS.ScriptInterpreterComponents
{
    internal class PlayerInterpreter : MainInterpreter
    {
        public PlayerInterpreter(string json) : base(json)
        {
        }

        
        public override string JsonInterpreter()
        {
            StringWriter sw = new StringWriter();
            try
            {
                sw.Write(curr.GetProperty("Lives").GetString() + ",");
                sw.Write(curr.GetProperty("Speed").GetString());
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }
    }
}

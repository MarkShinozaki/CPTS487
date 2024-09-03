// PInputInterpreter.cs

using System.IO;

namespace EGGS.ScriptInterpreterComponents
{
    internal class PInputInterpreter : MainInterpreter
    {
        public PInputInterpreter(string json) : base(json)
        {
        }

        
        public override string JsonInterpreter()
        {
            StringWriter sw = new StringWriter();
            try
            {
                sw.Write(curr.GetProperty("SlowdownMultiplier").GetString() + ",");
                sw.Write(curr.GetProperty("SprintMultiplier").GetString());
            }
            catch
            {
                
            }
            return sw.ToString();
        }
    }
}

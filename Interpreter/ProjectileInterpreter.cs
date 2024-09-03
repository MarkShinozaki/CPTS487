// ProjectileInterpreter.cs

using System.IO;

namespace EGGS.ScriptInterpreterComponents
{
    internal class ProjectileInterpreter : MainInterpreter
    {

        public ProjectileInterpreter(string json) : base(json)
        {
        }

        
        public override string JsonInterpreter()
        {
            StringWriter sw = new StringWriter();
            try
            {
                sw.Write(curr.GetProperty("ProjectileLimit").GetString());
            }
            catch
            {
                //event to stop game due to file having wrong format
            }
            return sw.ToString();
        }

    }

}

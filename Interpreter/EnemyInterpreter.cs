// EnemyInterpreter.cs 

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace EGGS.ScriptInterpreterComponents
{
    public class EnemyDefinition
    {
        public int EnemyID { get; set; }
        public string Type { get; set; }
        public int Health { get; set; }
        public float Speed { get; set; }
        public string MovementPattern { get; set; }
        public string AttackPattern { get; set; }
    }

    internal class EnemyInterpreter : MainInterpreter
    {
        public EnemyInterpreter(string json) : base(json) { }

        public override string JsonInterpreter()
        {
            throw new NotImplementedException();
        }

        public List<EnemyDefinition> ReadEnemyDefinitions()
        {
            List<EnemyDefinition> definitions = new List<EnemyDefinition>();
            foreach (JsonElement element in jsonFile.RootElement.EnumerateArray())
            {
                EnemyDefinition def = new EnemyDefinition
                {
                    EnemyID = element.GetProperty("EnemyID").GetInt32(),
                    Type = element.GetProperty("Type").GetString(),
                    Health = element.GetProperty("Health").GetInt32(),
                    Speed = element.GetProperty("Speed").GetSingle(),
                    MovementPattern = element.GetProperty("MovementPattern").GetString(),
                    AttackPattern = element.GetProperty("AttackPattern").GetString(),
                };
                definitions.Add(def);
            }
            return definitions;
        }
    }

    
}

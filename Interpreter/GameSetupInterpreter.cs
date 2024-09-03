using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EGGS.ScriptInterpreterComponents
{
    public class GameSetup
    {
        public string ID { get; set; }
        public string BackgroundColor { get; set; }
        // Add other properties as needed
    }

    public class GameSetupContainer
    {
        public List<GameSetup> GameSetups { get; set; }
    }

    public class GameSetupInterpreter
    {
        public GameSetup ReadGameSetup(string filePath, string setupId = "default")
        {
            var jsonString = File.ReadAllText(filePath);
            // Adjusting the deserialization to expect an array at the root
            var containers = JsonSerializer.Deserialize<List<GameSetupContainer>>(jsonString);
            // Assuming we want the first container's setups, and then find the setup by ID
            var gameSetup = containers?.FirstOrDefault()?.GameSetups?.Find(setup => setup.ID == setupId);
            return gameSetup;
        }
    }
}

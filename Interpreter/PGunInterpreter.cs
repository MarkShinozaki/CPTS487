using EGGS.PlayerComponents;
using System;
using System.Text.Json;

namespace EGGS.ScriptInterpreterComponents
{
    internal class PGunInterpreter : MainInterpreter
    {
        public PGunInterpreter(string json) : base(json)
        {
        }

        // Method to load weapon configuration from JSON into the provided weapon instance
        public void LoadWeaponConfig(Weapon weapon)
        {
            if (jsonFile.RootElement.ValueKind == JsonValueKind.Array && jsonFile.RootElement.GetArrayLength() > 0)
            {
                var config = jsonFile.RootElement[0];

                weapon.Spread = config.GetProperty("Spread").GetSingle();
                weapon.Damage = config.GetProperty("Damage").GetInt32();
                weapon.FireRate = config.GetProperty("FireRate").GetSingle();
                weapon.ProjectileSize = config.GetProperty("ProjectileSize").GetSingle();
                weapon.ProjectileSpeed = config.GetProperty("ProjectileSpeed").GetSingle();
            }
            else
            {
                throw new InvalidOperationException("JSON file does not contain any configurations or is not in the expected array format.");
            }
        }
    }
}

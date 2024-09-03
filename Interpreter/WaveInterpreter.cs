// WaveInterpreter.cs 

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace EGGS.ScriptInterpreterComponents
{
    // Placeholder class definitions
    internal class EnemyInWave
    {
        public int EnemyID { get; set; }
        public int EnemyAmount { get; set; }
        public int SpawnInterval { get; set; }
        public string SpawnPoint { get; set; }
    }

    internal class Wave
    {
        public string WaveID { get; set; }
        public int Difficulty { get; set; }
        public List<EnemyInWave> Enemies { get; set; }
    }

    internal class WavesConfig
    {
        public List<Wave> Waves { get; set; }
    }

    internal class WaveInterpreter : MainInterpreter
    {
        public WaveInterpreter(string json) : base(json) { }

        public WavesConfig ReadWavesConfig()
        {
            var wavesConfig = new WavesConfig { Waves = new List<Wave>() };

            try
            {
                var wavesArray = jsonFile.RootElement.EnumerateArray();
                foreach (var topLevelElement in wavesArray)
                {
                    foreach (var waveElement in topLevelElement.GetProperty("Waves").EnumerateArray())
                    {
                        var wave = new Wave
                        {
                            WaveID = waveElement.GetProperty("WaveID").GetString(),
                            Difficulty = waveElement.GetProperty("Difficulty").GetInt32(),
                            Enemies = new List<EnemyInWave>()
                        };

                        Console.WriteLine($"Reading wave {wave.WaveID} - Difficulty: {wave.Difficulty}");

                        foreach (var enemyElement in waveElement.GetProperty("Enemies").EnumerateArray())
                        {
                            var enemyInWave = new EnemyInWave
                            {
                                EnemyID = enemyElement.GetProperty("EnemyID").GetInt32(),
                                EnemyAmount = enemyElement.GetProperty("EnemyAmount").GetInt32(),
                                SpawnInterval = enemyElement.GetProperty("SpawnInterval").GetInt32(),
                                SpawnPoint = enemyElement.GetProperty("SpawnPoint").GetString()
                            };

                            // Debug output for each enemy in the wave
                            Console.WriteLine($"  Enemy ID: {enemyInWave.EnemyID}, Amount: {enemyInWave.EnemyAmount}, Interval: {enemyInWave.SpawnInterval}, SpawnPoint: {enemyInWave.SpawnPoint}");

                            wave.Enemies.Add(enemyInWave);
                        }

                        wavesConfig.Waves.Add(wave);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception, e.g., log it or throw a custom exception
                Console.WriteLine($"Error reading waves configuration: {ex.Message}");
            }

            return wavesConfig;
        }


    }


}

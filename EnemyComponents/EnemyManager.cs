// EnemyManager.cs 

using EGGS.ScriptInterpreterComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGGS.EnemyComponents
{
    public class EnemyManager
    {
        private List<EnemyBase> enemies = new List<EnemyBase>();
        private EnemyFactory factory;
        private WaveInterpreter waveInterpreter;
       

        // Constructor requires an EnemyFactory to create enemies.
        public EnemyManager(EnemyFactory factory, string waveJson)
        {
            Console.WriteLine($"Loading wave configuration from {waveJson}");
            this.factory = factory;
            InitializeWaveInterpreter(waveJson);
        }

        private void InitializeWaveInterpreter(string waveJson)
        {
            waveInterpreter = new WaveInterpreter(waveJson);
        }

        // Starts spawning waves based on a JSON string configuration.
        public void StartWaves()
        {
            WavesConfig currentWavesConfig = waveInterpreter.ReadWavesConfig();
            ProcessWaves(currentWavesConfig);
        }

        // Processes and starts spawning the next wave of enemies.
        private void ProcessWaves(WavesConfig wavesConfig)
        {
            foreach (var wave in wavesConfig.Waves)
            {
                Console.WriteLine($"Starting wave {wave.WaveID}");
                foreach (var enemyInWave in wave.Enemies)
                {
                    string spawnPoint = enemyInWave.SpawnPoint;
                    

                    for (int i = 0; i < enemyInWave.EnemyAmount; i++)
                    {
                        // Add a delay based on SpawnInterval before spawning each enemy
                        Task.Delay(TimeSpan.FromSeconds(enemyInWave.SpawnInterval)).ContinueWith(_ =>
                        {
                            SpawnEnemy(enemyInWave.EnemyID, position);
                        });
                    }
                }
            }
        }


        // Spawns an enemy based on its ID and determined position.

        private void SpawnEnemy(int enemyID, Vector2 position)
        {
            var definition = new EnemyDefinition { EnemyID = enemyID };
            var enemy = factory.CreateEnemy(definition);
            if (enemy != null)
            {
                enemy.Position = position;
                enemies.Add(enemy);

                Console.WriteLine($"Enemy {enemy.GetType().Name} created at position ({position.X}, {position.Y})");
            }
        }


        // Updates the state of enemies, removing them if conditions are met.
        public void Update(GameTime gameTime)
        {
            for (int i = enemies.Count - 1; i >= 0; i--)
            {
                var enemy = enemies[i];
                enemy.Update(gameTime);
            }
        }

        // Draws all enemies on the screen.
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var enemy in enemies)
            {
                enemy.Draw(spriteBatch);
            }
        }



       
    }
}

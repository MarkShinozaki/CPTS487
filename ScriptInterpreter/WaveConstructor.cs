namespace EGGS.ScriptInterpreter
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Newtonsoft.Json;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    using EGGS.EnemyComponents;
    using EGGS.Factory;
    using EGGS.MovementDesign;
    
    /// <summary>
    /// 
    /// </summary>
    class WaveConstructor
    {
        private EnemyFactory _creator;
        private String dirpath = "../../../../EGGS/Scripts/";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wavenum"></param>
        /// <param name="_content"></param>
        /// <returns></returns>
        public Wave BuildWave(int wavenum, ContentManager _content)
        {
            Wave newWave = new Wave(wavenum);
            if (wavenum == 1)
            {
                buildWaveFromFile(newWave, "FirstWave.json", _content);
            }
            else if (wavenum == 2)
            {
                buildWaveFromFile(newWave, "SecondWave.json", _content);
            }
            else if (wavenum == 3)
            {
                buildWaveFromFile(newWave, "ThirdWave.json", _content);
            }
            else if (wavenum == 4)
            {
                buildWaveFromFile(newWave, "FourthWave.json", _content);
            }
            else if (wavenum == 5)
            {
                buildWaveFromFile(newWave, "FifthWave.json", _content);
            }
            return newWave;
        }

        private void buildEnemyAWave1(Wave newWave, ContentManager _content)
        {
            _creator = new EnemyACreator();
            for (int j = 0; j < 4; j++)
            {
                EnemyMovement moves = new EnemyMovement();
                for (int i = 0; i < 10; i++)
                {
                    moves.addMovement(new MR(6.0));
                    moves.addMovement(new ML(6.0));
                }
                Vector2 pos = new Vector2(j * 100, j * 100);
                Vector2 vel = new Vector2(-1, 1);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));
            }
        }

        private void buildEnemyBWave1(Wave newWave, ContentManager _content)
        {
            _creator = new EnemyBCreator();
            int height = 50;
            for (int j = 1; j < 5; j++)
            {
                EnemyMovement moves = new EnemyMovement();
                for (int i = 0; i < 10; i++)
                {
                    moves.addMovement(new ML(6.0));
                    moves.addMovement(new MR(6.0));

                }
                Vector2 pos = new Vector2(800 - (j * 100), height);
                Vector2 vel = new Vector2(-1, 1);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));
                height += 100;
            }
        }

        private void buildEnemyAWave2(Wave newWave, ContentManager _content)
        {
            _creator = new EnemyACreator();
            for (int j = 0; j < 4; j++)
            {
                EnemyMovement moves = new EnemyMovement();
                for (int i = 0; i < 10; i++)
                {
                    moves.addMovement(new MD(3.0));
                    moves.addMovement(new MU(3.0));
                }
                Vector2 pos = new Vector2(j * 100, 0);
                Vector2 vel = new Vector2(-1, 1);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));
            }
        }

        private void buildEnemyAWave3(Wave newWave, ContentManager _content)
        {
            _creator = new EnemyACreator();
            for (int j = 0; j < 4; j++)
            {
                EnemyMovement moves = new EnemyMovement();
                for (int i = 0; i < 10; i++)
                {
                    moves.addMovement(new MDR(3.0));
                    moves.addMovement(new MUL(3.0));
                }
                Vector2 pos = new Vector2(j * 100, 0);
                Vector2 vel = new Vector2(-1, 1);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));
            }
        }

        private void buildEnemyBWave2(Wave newWave, ContentManager _content)
        {
            _creator = new EnemyBCreator();
            int width = 350;
            for (int j = 1; j < 5; j++)
            {
                EnemyMovement moves = new EnemyMovement();
                for (int i = 0; i < 10; i++)
                {
                    moves.addMovement(new MU(3.0));
                    moves.addMovement(new MD(3.0));

                }
                Vector2 pos = new Vector2(width, 300);
                Vector2 vel = new Vector2(-1, 1);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));
                width += 100;
            }
        }

        private void buildMidBossWave(Wave newWave, ContentManager _content)
        {
            _creator = new MidBossCreator();
            Vector2 pos = new Vector2(300, 50);
            newWave.addEnemy(_creator.CreateEnemy(pos, Vector2.One, _content, new EnemyMovement()));
        }

        private void buildFinalBossWave(Wave newWave, ContentManager _content)
        {
            _creator = new FinalBossCreator();
            Vector2 pos = new Vector2(300, 50);
            newWave.addEnemy(_creator.CreateEnemy(pos, Vector2.One, _content, new EnemyMovement()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newWave"></param>
        /// <param name="filename"></param>
        /// <param name="_content"></param>
        private void buildWaveFromFile(Wave newWave, String filename, ContentManager _content)
        {
            waveObj JSON = JsonConvert.DeserializeObject<waveObj>(File.ReadAllText(dirpath + filename));
            //'C:\Users\elifo\Desktop\MyStuff\School Projects\487sp19_bulletgame\content\BulletGame\wave5.json'.'
            for (int enemyIdx = 0;  enemyIdx < JSON.enemies.Count; enemyIdx++)
            {

                if (JSON.enemies[enemyIdx].type == "EnemyA")
                {
                    _creator = new EnemyACreator();
                }
                else if (JSON.enemies[enemyIdx].type == "EnemyB")
                {
                    _creator = new EnemyBCreator();
                }
                else if (JSON.enemies[enemyIdx].type == "MidBoss")
                {
                    _creator = new MidBossCreator();
                }
                else if (JSON.enemies[enemyIdx].type == "FinalBoss")
                {
                    _creator = new FinalBossCreator();
                }
                EnemyMovement moves = new EnemyMovement();
                MovementsFactory movementFactory = new MovementsFactory();
                for (int rep = 0; rep < JSON.enemies[enemyIdx].movementRepetitions; rep++)
                {
                    for (int moveIdx = 0; moveIdx < JSON.enemies[enemyIdx].movements.Count; moveIdx++)
                    {
                        moves.addMovement(movementFactory.makeMovement(JSON.enemies[enemyIdx].movements[moveIdx].type, JSON.enemies[enemyIdx].movements[moveIdx].duration));
                    }
                }

                Vector2 pos = new Vector2(JSON.enemies[enemyIdx].startPos[0], JSON.enemies[enemyIdx].startPos[1]);
                Vector2 vel = new Vector2(JSON.enemies[enemyIdx].startVel[0], JSON.enemies[enemyIdx].startVel[1]);
                newWave.addEnemy(_creator.CreateEnemy(pos, vel, _content, moves));

            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class waveObj
    {
        public List<enemyObj> enemies;
    }
    class enemyObj
    {
        public string type;
        public List<int> startPos;
        public List<int> startVel;
        public List<moveObj> movements;
        public int movementRepetitions;
    }
    class moveObj
    {
        public string type;
        public double duration;
    }
}

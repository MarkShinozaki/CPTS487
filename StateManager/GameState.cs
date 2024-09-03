namespace EGGS.StateManager
{

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Timers;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework;

    using EGGS.OnScreenUnits;
    using EGGS.EnemyComponents;
    using EGGS.ScriptInterpreter;
    using EGGS.PlayerFolder;

    /// <summary>
    /// 
    /// </summary>
    public class GameState : State
    {
        List<Enemy> _enemies = new List<Enemy>();
        Random random = new Random();
        private static Timer GameTimer;
        Texture2D backgroundTexture;
        ReadyPlayerOne playerOne;
        GraphicsDeviceManager _graphics;
        int waveNumber;
        WaveConstructor waves;
        int curLives = 3;
        Texture2D lifeTexture;
        Reward reward;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="content"></param>
        public GameState(PlayGame game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            _graphics = graphicsDevice;
            _content = content;
            playerOne = new ReadyPlayerOne(content);
            playerOne.Initialize(100f, new Vector2((graphicsDevice.PreferredBackBufferWidth / 2), (graphicsDevice.PreferredBackBufferHeight) - 75));
            playerOne.Load(content.Load<Texture2D>("Textures/Player"));
            backgroundTexture = content.Load<Texture2D>("Textures/Background");
            lifeTexture = _content.Load<Texture2D>("Textures/lives3");

            reward = new Reward(content, graphicsDevice.PreferredBackBufferWidth, graphicsDevice.PreferredBackBufferHeight);


            SetWaveTimers();
            waves = new WaveConstructor();
            Wave wave1 = waves.BuildWave(1, _content);
            _enemies = wave1.getAllEnemies();
            waveNumber = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creator"></param>
        void AddEnemy(EnemyFactory creator)
        {
            int randY = random.Next(100, 300); // height of viewport is 400

            Enemy enemy = creator.AddEnemy(_content, randY);
            _enemies.Add(enemy);
        }

        /// <summary>
        /// 
        /// </summary>
        private void SetWaveTimers()
        {
            int i = 1;
            for (; i < 5; ++i)
            {
                GameTimer = new System.Timers.Timer(25000 * i);
                GameTimer.Elapsed += loadNextWave;
                GameTimer.Enabled = true;
                GameTimer.AutoReset = false;
            }

            // Auto-win timer
            GameTimer = new System.Timers.Timer(25000 * i);
            GameTimer.Elapsed += AutomaticWin;
            GameTimer.Enabled = true;
            GameTimer.AutoReset = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void loadNextWave(Object source, ElapsedEventArgs e)
        {
            waveNumber++;
            Wave newWave = waves.BuildWave(waveNumber, _content);
            _enemies.AddRange(newWave.getAllEnemies());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void AutomaticWin(Object source, ElapsedEventArgs e)
        {
            _game.ChangeState(new WinState(_game, _graphicsDevice, _content));
        }

        /// <summary>
        /// 
        /// </summary>
        public void CleanupEnemies()
        {
            for (int i = 0; i < _enemies.Count; i++)
            {
                if (!_enemies[i].isVisible)
                {
                    _enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void removeAllBullets()
        {
            foreach (Enemy enemy in _enemies)
            {
                enemy.removeBullets(); //remove enemy bullets
            }
            playerOne.removeBullets(); //remove players bullets
        }

        /// <summary>
        /// 
        /// </summary>
        public void updateLivesTexture()
        {
            if (playerOne.getLives() == 1)
                lifeTexture = _content.Load<Texture2D>("Textures/lives1");
            else if (playerOne.getLives() == 2)
                lifeTexture = _content.Load<Texture2D>("Textures/lives2");
            else if (playerOne.getLives() == 3)
                lifeTexture = _content.Load<Texture2D>("Textures/lives3");
            else if (playerOne.getLives() == 4)
                lifeTexture = _content.Load<Texture2D>("Textures/lives4");
            else if (playerOne.getLives() == 5)
                lifeTexture = _content.Load<Texture2D>("Textures/lives5");
            else if (playerOne.getLives() == 6)
                lifeTexture = _content.Load<Texture2D>("Textures/lives6");
            else if (playerOne.getLives() == 7)
                lifeTexture = _content.Load<Texture2D>("Textures/lives7");
            else if (playerOne.getLives() == 8)
                lifeTexture = _content.Load<Texture2D>("Textures/lives8");
            else if (playerOne.getLives() == 9)
                lifeTexture = _content.Load<Texture2D>("Textures/lives9");
        }

        /// <summary>
        /// 
        /// </summary>
        public void checkHit()
        {
            if (curLives > playerOne.getLives())
            {
                curLives = playerOne.getLives();
                removeAllBullets();
                updateLivesTexture();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void IsPlayerDead()
        {
            if (playerOne.getLives() == 0)
            {
                _game.ChangeState(new LoseState(_game, _graphicsDevice, _content));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DidPlayerWin()
        {
            if (playerOne.IsWinner() == 1)
            {
                _game.ChangeState(new WinState(_game, _graphicsDevice, _content));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(
                backgroundTexture,
                new Rectangle(0, 0, 900, 1000),
                Color.White);

            spriteBatch.Draw(
                lifeTexture,
                new Vector2(lifeTexture.Width / 2, lifeTexture.Height / 2),
                null,
                Color.White,
                0f,
                new Vector2(lifeTexture.Width / 2, lifeTexture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);

            playerOne.Draw(spriteBatch);

            if (waveNumber == 4) // load reward on the 4th wave
            {
                if (reward != null)
                {
                    reward.Draw(spriteBatch);
                }
            }

            foreach (Enemy enemy in _enemies.ToList())
            {
                enemy.Draw(spriteBatch);
            }

            spriteBatch.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            if (waveNumber == 4) // when there is a reward
            {
                if (reward != null)
                {
                    if (reward.position.X <= playerOne.position.X + 5 && reward.position.Y <= playerOne.position.Y + 5
                                && reward.position.X >= playerOne.position.X - 5 && reward.position.Y >= playerOne.position.Y - 5)
                    {
                        playerOne.AddLife(5); // update player life
                        updateLivesTexture();
                        reward = null; // remove reward
                    }
                }
            }

            foreach (Enemy enemy in _enemies)
            {
                enemy.Update(_graphics, gameTime);
                for (int i = 0; i < enemy.bullets.Count; i++)
                {
                    if (enemy.bullets[i].position.X + 4 >= playerOne.position.X &&
                        enemy.bullets[i].position.X <= playerOne.position.X + 28 &&
                        enemy.bullets[i].position.Y + 18 >= playerOne.position.Y &&
                        enemy.bullets[i].position.Y <= playerOne.position.Y + 14 &&
                        playerOne.invincible == false && playerOne.isGod == false)
                    {
                        playerOne.bulletHit();
                        enemy.bullets[i].isVisible = false;
                    }
                }
                for (int i = 0; i < playerOne.bullets.Count; i++)
                {
                    if (playerOne.bullets[i].position.X + 4 >= enemy.position.X &&
                        playerOne.bullets[i].position.X <= enemy.position.X + enemy.width &&
                        playerOne.bullets[i].position.Y + 18 >= enemy.position.Y &&
                        playerOne.bullets[i].position.Y <= enemy.position.Y + enemy.height)
                    {
                        enemy.lives -= 1;
                        playerOne.bullets[i].isVisible = false;
                        if (enemy.lives <= 0)
                        {
                            enemy.isVisible = false;
                        }
                    }
                }
            }

            CleanupEnemies();
            playerOne.Update(gameTime);
            playerOne.boundsCheck(_graphics);
            IsPlayerDead();
            DidPlayerWin();
            checkHit();
        }
    }
}

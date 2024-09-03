

namespace EGGS.PlayerFolder
{
    using System;
    using System.Timers;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

    using EGGS.Factory;
    using EGGS.OnScreenUnits.BulletType;
    using EGGS.MovementDesign;
    using EGGS.OnScreenUnits;

    /// <summary>
    /// 
    /// </summary>
    class ReadyPlayerOne : Entity
    {
        private double speed; // current speed 

        private double originalSpeed;

        private double slowModeModifier;
        public bool isGod; // update
        public List<Bullet> bullets; //may depend on design
        public BulletFactory factory;
        private bool isInSlowMode = false;

        ContentManager Content;
        private int winner = 0;
        private int lives = 0;
        private Vector2 initPos;
        public bool invincible = true;
        private static Timer invincibilityTimer;
        private Vector2 velocity = new Vector2(-2, 2);

        //Key mapping
        Keys upKey = Keys.Up;
        Keys downKey = Keys.Down;
        Keys leftKey = Keys.Left;
        Keys rightKey = Keys.Right;
        Keys shootKey = Keys.Space;
        Keys slowMode = Keys.S;
        Keys godMode = Keys.G;

        Keys win = Keys.W;
        Keys die = Keys.D;
        Keys hit = Keys.H; 

        KeyboardState pastKey;

        public ReadyPlayerOne(ContentManager gameContent)
        {
            Content = gameContent;
            isGod = false;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public void bulletsUpdateAndCleanup(GameTime gameTime)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update(gameTime);

                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initSpeed"></param>
        /// <param name="initPosition"></param>
        public void Initialize(float initSpeed, Vector2 initPosition)
        {

            initPos = initPosition;
            originalSpeed =  speed  = initSpeed;
            position = initPosition;
            slowModeModifier = 4.0;
            lives = 3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initTexture"></param>
        public void Load(Texture2D initTexture)
        {
            texture = initTexture;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            var kstate = Keyboard.GetState();

            // Define the normal movement speed factor
            //double normalSpeedFactor = 1.0;
            double slowSpeedFactor = 1.0 / slowModeModifier;

            // Adjust velocity based on whether slowMode is active
            Vector2 currentVelocity = velocity;
            if (kstate.IsKeyDown(slowMode))
            {
                currentVelocity *= (float)slowSpeedFactor;
            }

            // Check god mode toggle
            if (kstate.IsKeyDown(godMode) && pastKey.IsKeyUp(godMode))
            {
                isGod = !isGod;
            }

            // Handle hit detection
            if (kstate.IsKeyDown(hit) && pastKey.IsKeyUp(hit) && !invincible)
            {
                bulletHit();
            }

            // Apply the adjusted velocity to movement directions
            if (kstate.IsKeyDown(upKey))
                position = new MU(currentVelocity.Y).getNewPosition(position, currentVelocity);
            if (kstate.IsKeyDown(downKey))
                position = new MD(currentVelocity.Y).getNewPosition(position, currentVelocity);
            if (kstate.IsKeyDown(leftKey))
                position = new ML(currentVelocity.X).getNewPosition(position, currentVelocity);
            if (kstate.IsKeyDown(rightKey))
                position = new MR(currentVelocity.X).getNewPosition(position, currentVelocity);

            // Handle shooting
            if (kstate.IsKeyDown(shootKey) && pastKey.IsKeyUp(shootKey))
            {
                shoot();
            }

            // Store the keyboard state for the next update cycle
            pastKey = Keyboard.GetState();

            // Update and cleanup bullets
            bulletsUpdateAndCleanup(gameTime);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                null,
                Color.White,
                0f,
                new Vector2(texture.Width / 2, texture.Height / 2),
                Vector2.One,
                SpriteEffects.None,
                0f);

            foreach (Bullet bullet in bullets)
                bullet.Draw(spriteBatch);
        }

        /// <summary>
        /// 
        /// </summary>
        public void shoot()
        {
            if (!isGod)
            {
                Bullet newBullet = factory.bulletFactory("bullet4", position, new Vector2(0, -10), true, 1);
                newBullet.position = position; //allow setting through constructor?

                if (bullets.Count < 30)
                    bullets.Add(newBullet);
            }
            else
            {
                BulletSpread spread = (BulletSpread)factory.bulletFactory("spread", position, Vector2.Zero, true, 5);
                foreach (Bullet bullet in spread.bullets)
                {
                    if (bullets.Count < 100)
                    {
                        bullets.Add(bullet);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        public void boundsCheck(GraphicsDeviceManager graphics)
        {
            position.X = MathHelper.Min(MathHelper.Max(texture.Width / 2, position.X), graphics.PreferredBackBufferWidth - texture.Width / 2);
            position.Y = MathHelper.Min(MathHelper.Max(texture.Height / 2, position.Y), graphics.PreferredBackBufferHeight - texture.Height / 2);
        }

        /// <summary>
        /// 
        /// </summary>
        public void bulletHit()
        {
            originSpot();
            subtractLife();
            Invincibility();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Invincibility()
        {
            texture = Content.Load<Texture2D>("Textures/PlayerShield");
            invincible = true;
            invincibilityTimer = new System.Timers.Timer(5000);
            invincibilityTimer.Elapsed += setInvincibilityFalse;
            invincibilityTimer.Enabled = true;
            invincibilityTimer.AutoReset = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private void setInvincibilityFalse(Object source, ElapsedEventArgs e)
        {
            invincible = false;
            texture = Content.Load<Texture2D>("Textures/Player");
        }

        /// <summary>
        /// 
        /// </summary>
        private void originSpot()
        {
            position = initPos;
        }

        /// <summary>
        /// 
        /// </summary>
        public void removeBullets()
        {
            bullets.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void subtractLife()
        {
            lives -= 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        public void AddLife(int number)
        {
            lives += number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int IsWinner()
        {
            return winner;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int getLives()
        {
            return lives;
        }
    }
}

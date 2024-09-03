namespace EGGS.EnemyComponents
{

    using System;
    using System.Collections.Generic;

    using EGGS.Factory;
    using EGGS.OnScreenUnits.BulletType;
    using EGGS.OnScreenUnits;
    using EGGS.MovementDesign;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    

    /// <summary>
    /// 
    /// </summary>
    class EnemyA : Enemy
    {

        private Movement currentMove;

        private double movementStartTime;

        Random random = new Random();

        private double timeToNextShot;

        int randomX;
        int randomY;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        public EnemyA(Vector2 newPosition, ContentManager gameContent)
        {
            texture = gameContent.Load<Texture2D>("Textures/EnemyA");
            position = newPosition;

            SetRandomTimeToNextShot();

            randomY = random.Next(0, 4);
            randomX = random.Next(0, 4);

            movementTime = 0f;
            velocity = new Vector2(randomX, randomY);

            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);

            lives = 1;
            width = 90;
            height = 90;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="newVelocity"></param>
        /// <param name="gameContent"></param>
        /// <param name="newMoves"></param>
        public EnemyA(Vector2 newPosition, Vector2 newVelocity, ContentManager gameContent, EnemyMovement newMoves)
        {

            texture = gameContent.Load<Texture2D>("Textures/EnemyA");
            position = newPosition;


            movementTime = 0f;
            this.velocity = newVelocity;
            this.moves = newMoves;

            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);

            lives = 2;
            width = 90;
            height = 90;

        }

        /// <summary>
        /// Fire Rate for Enemy A
        /// </summary>
        private void SetRandomTimeToNextShot()
        {
            timeToNextShot = random.NextDouble() * 0.9 + 0.3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initSpeed"></param>
        /// <param name="initPosition"></param>
        public override void Initialize(float initSpeed, Vector2 initPosition)
        {
            speed = initSpeed;
            position = initPosition;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="gameTime"></param>
        public override void Update(GraphicsDeviceManager graphics, GameTime gameTime)
        {
            movementTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rightward = (movementTime < 1f) ? true : false;
            movementTime = (((int)movementTime) == 4) ? 0 : movementTime;
            timeToNextShot -= gameTime.ElapsedGameTime.TotalSeconds;
            if (timeToNextShot <= 0)
            {
                shoot();
                SetRandomTimeToNextShot();
            }

            if (moves == null)
            {
                position += velocity;
            }

            else if (currentMove == null)
            {
                currentMove = moves.GetMovement();
                movementStartTime = gameTime.TotalGameTime.TotalSeconds;
            }

            else if (currentMove.seconds <= (gameTime.TotalGameTime.TotalSeconds - movementStartTime))
            {
                moves.popMovement();
                currentMove = null;
            }

            else
            {
                position = currentMove.getNewPosition(position, velocity);
            }

            if (position.X < 0 - texture.Width)
            {
                isVisible = false;
            }

            bulletsUpdateAndCleanup(gameTime);
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
            spriteBatch.Draw(texture, destinationRectangle, Color.White);
            foreach (Bullet bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void shoot()
        {
            Vector2 bulletVelocity = new Vector2(random.Next(-2, 3), 10); // Randomize X velocity slightly
            Vector2 bulletPosition = new Vector2(position.X + width / 2, position.Y + height);
            Bullet bullet = factory.bulletFactory("bullet1", bulletPosition, bulletVelocity, true, 1);

            if (bullets.Count < 80)
            {
                bullets.Add(bullet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void bulletsUpdateAndCleanup(GameTime gameTime)
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
        public override void removeBullets()
        {
            bullets.Clear();
        }

    }

}
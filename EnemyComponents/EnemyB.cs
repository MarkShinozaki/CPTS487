// EnemyB.cs



namespace EGGS.EnemyComponents
{
    using System;
    using EGGS.Factory;
    using EGGS.OnScreenUnits.BulletType;
    using EGGS.OnScreenUnits;

    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using EGGS.MovementDesign;

    class EnemyB : Enemy
    {
        private Movement currentMove;
        private Double movementStartTime;

        Random random = new Random();
        int randX, randY;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        public EnemyB(Vector2 newPosition, ContentManager gameContent)
        {
            texture = gameContent.Load<Texture2D>("Textures/EnemyB");
            position = newPosition;

            randY = random.Next(-4, 4);
            randX = random.Next(-4, 1);

            movementTime = 0f; 
            velocity = new Vector2(randX, randY);

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
        public EnemyB(Vector2 newPosition, Vector2 newVelocity, ContentManager gameContent, EnemyMovement newMoves)
        {
            texture = gameContent.Load<Texture2D>("Textures/EnemyB");
            position = newPosition;

            movementTime = 0f;
            this.velocity = newVelocity;
            this.moves = newMoves;

            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            lives = 4;
            width = 90;
            height = 90;
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
            // logic for shooting
            movementTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            rightward = (movementTime < 3f) ? true : false;
            movementTime = (((int)movementTime) == 4) ? 0 : movementTime;
            if ((int)movementTime % 4 == 0)
            {
                shoot();
            }

            // logic for enemy to move
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
            Vector2 bulletPosition = new Vector2(position.X + width / 2, position.Y + height / 2);
            Bullet bullet = factory.bulletFactory("bullet2", bulletPosition, new Vector2(0, 10), true, 1);

            if (bullets.Count < 70)
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
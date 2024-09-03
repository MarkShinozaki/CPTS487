
namespace EGGS.EnemyComponents
{

    using EGGS.OnScreenUnits.BulletType;
    using EGGS.OnScreenUnits;
    using EGGS.Factory;
   

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    class FinalBoss : Enemy
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        public FinalBoss(Vector2 newPosition, ContentManager gameContent)
        {
            texture = gameContent.Load<Texture2D>("Textures/FinalBoss");
            position = newPosition;

            movementTime = 0f;
            velocity = new Vector2(1, 0);

            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            lives = 30;
            width = 200;
            height = 200;
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
            if (lives > 1)
            {
                rightward = (movementTime < 2f) ? true : false;
                position = (rightward == true) ? position + velocity : position - velocity;
            }
            movementTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            movementTime = (((int)movementTime) == 4) ? 0 : movementTime;

            if (lives >= 3)
            {
                shoot();
            }
            else if (bullets.Count <= 0 && lives == 2)
            {
                shoot();
            }
            else if ((int)movementTime % 4 == 0 && lives == 1)
            {
                shoot();
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
            // Calculate the center position for bullet spawn
            Vector2 spawnPosition = new Vector2(position.X + width / 2, position.Y + height / 2);

            if (lives > 3)
            {
                TopBottom spread = (TopBottom)factory.bulletFactory("topBottom", spawnPosition, Vector2.Zero, true, 9);
                foreach (Bullet bullet in spread.bullets)
                {
                    if (bullets.Count < 300) 
                    {
                        bullets.Add(bullet);
                    }
                }
            }

            if (lives == 3)
            {
                RandomBullets spread = (RandomBullets)factory.bulletFactory("randomBullets", spawnPosition, Vector2.Zero, true, 8);
                foreach (Bullet bullet in spread.bullets)
                {
                    if (bullets.Count < 300) 
                    {
                        bullets.Add(bullet);
                    }
                }
            }
            else if (lives == 2)
            {
                TopBottom spread = (TopBottom)factory.bulletFactory("topBottom", spawnPosition, Vector2.Zero, true, 9);
                foreach (Bullet bullet in spread.bullets)
                {
                    if (bullets.Count < 200) // Consistent limit with other conditions
                    {
                        bullets.Add(bullet);
                    }
                }
            }
            else if (lives == 1)
            {
                Spiral spread = (Spiral)factory.bulletFactory("spiral", spawnPosition, Vector2.Zero, true, 10);
                foreach (Bullet bullet in spread.bullets)
                {
                    if (bullets.Count < 300)
                    {
                        bullets.Add(bullet);
                    }
                }
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

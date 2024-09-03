namespace EGGS.EnemyComponents
{
    using EGGS.Factory;
    using EGGS.OnScreenUnits.BulletType;
    using EGGS.OnScreenUnits;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;

    class MidBoss : Enemy
    {

        public MidBoss(Vector2 newPosition, ContentManager gameContent)
        {
            texture = gameContent.Load<Texture2D>("Textures/MidBoss");
            position = newPosition;

            movementTime = 0f;
            velocity = new Vector2(1, 0);

            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            lives = 10;
            width = 150;
            height = 150;

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
            rightward = (movementTime < 2f) ? true : false;
            position = (rightward == true) ? position + velocity : position - velocity;
            movementTime = (((int)movementTime) == 4) ? 0 : movementTime;
            if ((int)movementTime % 4 == 0)
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
            
            Vector2 bulletPosition = new Vector2(position.X + width / 2, position.Y + height / 2);
            
            MBSpread spread = (MBSpread)factory.bulletFactory("mbSpread", bulletPosition, Vector2.Zero, true, 7);
            foreach (Bullet bullet in spread.bullets)
            {
                if (bullets.Count < 300) // Check to avoid adding too many bullets
                {
                    bullets.Add(bullet);
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

namespace EGGS.OnScreenUnits
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.OnScreenUnits.BulletType;
    using EGGS.Factory;
    using EGGS.MovementDesign;

    /// <summary>
    /// 
    /// </summary>
    abstract class Enemy
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 velocity;

        public bool isVisible = true;
        public List<Bullet> bullets;
        public BulletFactory factory;

        protected EnemyMovement moves;

        public float speed;
        public float movementTime;
        public bool rightward;
        public int lives;
        public int width;
        public int height;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initSpeed"></param>
        /// <param name="initPosition"></param>
        public abstract void Initialize(float initSpeed, Vector2 initPosition);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="gameTime"></param>
        public abstract void Update(GraphicsDeviceManager graphics, GameTime gameTime);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(SpriteBatch spriteBatch);

        /// <summary>
        /// 
        /// </summary>
        public abstract void shoot();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void bulletsUpdateAndCleanup(GameTime gameTime);

        /// <summary>
        /// 
        /// </summary>
        public abstract void removeBullets();

    }
}

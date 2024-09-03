// EnemyBase.cs 

using EGGS.Movements;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EGGS.EnemyComponents
{
    public abstract class EnemyBase
    {
        public int EnemyID { get; set; } // Added EnemyID property
        public int Health { get; set; }
        public float Speed { get; set; }
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }

        public IMovementBehavior MovementBehavior { get; set; }

        
        public EnemyBase(int enemyID, int health, float speed)
        {
            EnemyID = enemyID;
            Health = health;
            Speed = speed;
        }

        public void SetMovementBehavior(IMovementBehavior movementBehavior)
        {
            MovementBehavior = movementBehavior;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}


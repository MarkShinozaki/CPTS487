// LinearMovements.cs 
using Microsoft.Xna.Framework;
using EGGS.EnemyComponents;

namespace EGGS.Movements
{
    public class LinearMovement : IMovementBehavior
    {
        public void Move(GameTime gameTime, EnemyBase enemy)
        {
            var velocity = new Vector2(enemy.Speed, 0); // Assuming speed is horizontal movement
            enemy.Position += velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}

using Microsoft.Xna.Framework;
using EGGS.EnemyComponents;

namespace EGGS.Movements
{
    public class ZigzagMovement : IMovementBehavior
    {
        private float direction = 1f; // 1 for right, -1 for left
        private float zigzagTimer = 0f;
        private readonly float zigzagChangeTime = 1f; // Time in seconds to change direction

        public void Move(GameTime gameTime, EnemyBase enemy)
        {
            zigzagTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (zigzagTimer >= zigzagChangeTime)
            {
                direction *= -1; // Change direction
                zigzagTimer = 0; // Reset timer
            }

            var horizontalVelocity = new Vector2(enemy.Speed * direction, 0);
            var verticalVelocity = new Vector2(0, enemy.Speed / 2); // Slower vertical movement

            enemy.Position += (horizontalVelocity + verticalVelocity) * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}

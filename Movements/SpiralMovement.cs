// SpiralMovement.cs

using Microsoft.Xna.Framework;
using EGGS.EnemyComponents;
using System;

namespace EGGS.Movements
{
    public class SpiralMovement : IMovementBehavior
    {
        private float angle = 0.0f;
        private float speed;
        private float radius;
        private float angleIncrement;
        private Vector2 center;

        public SpiralMovement( float radius, float angleIncrement, Vector2 startCenter)
        {
            
            this.radius = radius; // Starting radius of the spiral
            this.angleIncrement = angleIncrement; // How quickly the spiral tightens or loosens
            this.center = startCenter; // The center around which the enemy will spiral
        }

        public void Move(GameTime gameTime, EnemyBase enemy)
        {
            // Update the angle based on the speed
            angle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            // Calculate the new position based on the spiral logic
            Vector2 offset = new Vector2((float)Math.Cos(angle), (float)Math.Sin(angle)) * radius;
            enemy.Position = center + offset;

            // Optionally, you can update the radius over time to make the spiral tighten or loosen
            radius += angleIncrement * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}

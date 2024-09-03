// EnemyB.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace EGGS.EnemyComponents.Enemies
{
    internal class EnemyB : EnemyBase
    {
        public EnemyB(int enemyID, int health, float speed) : base(enemyID, health, speed)
        {
            // Initialization specific to EnemyB, if any
        }

        public override void Update(GameTime gameTime)
        {
            // Use the assigned movement behavior, if any
            MovementBehavior?.Move(gameTime, this);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Texture == null) return; // Skip drawing if texture is not loaded

            Vector2 scale = new Vector2(0.1f, 0.1f); // Example scale, adjust as necessary

            // Draw the texture with the specified scale.
            // Note: You might need to adjust the position and scale values to fit your game's needs.
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }
    }
}

// EnemyA.cs 

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EGGS.EnemyComponents.Enemies
{
    internal class EnemyA : EnemyBase
    {
        public EnemyA(int enemyID, int health, float speed) : base(enemyID, health, speed)
        {
            // You can set default properties specific to EnemyA here
        }

        public override void Update(GameTime gameTime)
        {
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

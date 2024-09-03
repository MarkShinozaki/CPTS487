namespace EGGS.OnScreenUnits
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    class Reward : Entity
    {
        ContentManager Content;
        Random random = new Random();
        int screenWidth;
        int screenHeight;

        public Reward(ContentManager gameContent, int screenWidth, int screenHeight)
        {
            Content = gameContent;
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            texture = gameContent.Load<Texture2D>("Textures/reward");
            Respawn();
        }

        public void Respawn()
        {
            position.X = random.Next(0, screenWidth - texture.Width);
            // Ensure the reward spawns in the bottom half of the screen
            position.Y = random.Next(screenHeight / 2, screenHeight - texture.Height);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y), null, Color.White, 0, new Vector2(texture.Width / 2, texture.Height / 2), 1, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            // Update logic here if necessary, e.g., for effects or movement
        }
    }

}
namespace EGGS
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    abstract class Units
    {
        public Texture2D texture;
        public Vector2 position;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime);

    }
}

namespace EGGS.OnScreenUnits
{
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    abstract class Entity
    {
        public Texture2D texture;
        public Vector2 position;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

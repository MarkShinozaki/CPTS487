using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using System.Threading.Tasks;

namespace EGGS.OnScreenUnits
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class Component
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gametime"></param>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(GameTime gametime, SpriteBatch spriteBatch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);
    }
}

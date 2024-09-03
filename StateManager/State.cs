using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGGS.StateManager
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _content;

        protected GraphicsDeviceManager _graphicsDevice;

        protected PlayGame _game;

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="game"></param>
        /// <param name="graphicsDevice"></param>
        /// <param name="content"></param>
        public State(PlayGame game, GraphicsDeviceManager graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        #endregion



    }
}

﻿namespace EGGS.StateManager
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework;

    using EGGS.Controls;
    using EGGS.OnScreenUnits;

    /// <summary>
    /// 
    /// </summary>
    public class LoseState : State
    {
        private List<Component> _components;
        GraphicsDeviceManager _graphics;
        public LoseState(PlayGame game, GraphicsDeviceManager graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexturePlay = _content.Load<Texture2D>("ButtonTextures/PlayGame");
            var buttonTextureQuit = _content.Load<Texture2D>("ButtonTextures/ExitGame");
            var buttonTextureLose = _content.Load<Texture2D>("ButtonTextures/LostGame");

           
            var newGameButton = new Button(buttonTexturePlay)
            {
                Position = new Vector2(450 - buttonTexturePlay.Width / 2, 400),  // Centered horizontally, adjusted vertically
            };

            newGameButton.Click += NewGameButton_Click;

            var quitGameButton = new Button(buttonTextureQuit)
            {
                Position = new Vector2(450 - buttonTextureQuit.Width / 2, 750),  // Centered horizontally, further down
            };

            quitGameButton.Click += QuitGameButton_Click;

            var youLostButton = new Button(buttonTextureLose)
            {
                Position = new Vector2(450 - buttonTextureLose.Width / 2, 50),
            };

            _components = new List<Component>()
            {
                youLostButton,
                newGameButton,
                quitGameButton,
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // load new game state
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var backgroundTexture = _content.Load<Texture2D>("Textures/Background");
            spriteBatch.Begin();
            spriteBatch.Draw(
                backgroundTexture,
                new Rectangle(0, 0, 900, 1000),
                Color.White);
            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
            spriteBatch.End();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
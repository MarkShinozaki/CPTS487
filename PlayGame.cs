namespace EGGS
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.StateManager;
   
    /// <summary>
    /// 
    /// </summary>
    public class PlayGame : Game
    {
        GraphicsDeviceManager _graphics;
        SpriteBatch spriteBatch;

        private State _currentState;
        private State _nextState;

        //private ScoreboardStats scoreboardStats;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        /// <summary>
        /// 
        /// </summary>
        public PlayGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 900; // set the width of the window
            _graphics.PreferredBackBufferHeight = 1000;
            Content.RootDirectory = "Content";
            //scoreboardStats = new ScoreboardStats();
        }

        protected override void Initialize()
        {
            IsMouseVisible = true;
            //scoreboardStats.LoadScores();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            _currentState = new MenuState(this, _graphics, Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _currentState.Update(gameTime);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _currentState.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
    }
}

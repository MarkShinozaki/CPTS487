using EGGS.ProjectileComponents;
using EGGS.ScriptInterpreterComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;




namespace EGGS.PlayerComponents
{
    public class ReadyPlayerOne
    {
        public int CurrentLives{ get; set; } // Lives updates in live game
        public float CurrentSpeed{ get; set; }  // speed updates in live game
        private int Lives;  // Max Lives that was set
        private float Speed; // Max speed that was set

        public Vector2 Position { get; set; }
        public string TextureName { get;}
        public Texture2D Texture;
        private PlayerDecisions input;
        public Weapon gun;

        public ReadyPlayerOne()
        {
            this.CurrentLives = 0;
            this.CurrentSpeed = 0f;
            this.Lives = 0;
            this.Speed = 0f;
            this.TextureName = "Textures//Player";
            this.input = new PlayerDecisions();
            this.gun = new Weapon();
            LoadPlayerScript();
        }


        // Inside ReadyPlayerOne.cs, modify the InputScript or a similar method where you update the position

        public void InputScript(GameTime gameTime, int screenWidth, int screenHeight, ProjectileFactory projectileFactory)
        {
            input.PlayerInputHandler(this, gameTime, projectileFactory);

            // Clamp player's position to the current screen bounds after processing input
            ClampPositionToScreenBounds(screenWidth, screenHeight);
        }




        public void ResetSpeed()
        {
            this.CurrentSpeed = Speed;
        }


        public void CenterPlayer(int screenWidth, int screenHeight)
        {
            float playerWidth = this.Texture.Width;
            float playerHeight = this.Texture.Height;

            // Calculate the starting X position to horizontally center the player
            float startingXPosition = (screenWidth / 2f) - (playerWidth / 2f);

            // Adjust this value to increase the padding/margin from the bottom of the screen.
            // For example, changing from a 10% margin to a 20% margin of the player's height
            // or simply subtracting a fixed value (e.g., 50 pixels).
            // Example with increased percentage margin:
            float startingYPosition = screenHeight - playerHeight - (playerHeight * 0.5f);
            // Example with fixed padding:
            // float startingYPosition = screenHeight - playerHeight - 50;

            this.Position = new Vector2(startingXPosition, startingYPosition);
        }




        public void ClampPositionToScreenBounds(int screenWidth, int screenHeight)
        {
            // Clamp player's X and Y to keep within the screen bounds, considering the player texture's dimensions
            Position = new Vector2(
                MathHelper.Clamp(Position.X, 0, screenWidth - Texture.Width),
                MathHelper.Clamp(Position.Y, 0, screenHeight - Texture.Height));
        }





        private void LoadPlayerScript()
        {
            PlayerInterpreter playerScriptInterpreter = new PlayerInterpreter("PScript.json");
            string valsConcated = playerScriptInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.CurrentLives = int.Parse(vals[0]);
            this.Lives = int.Parse(vals[0]);
            
            this.CurrentSpeed = float.Parse(vals[1]);
            this.Speed = float.Parse(vals[1]);
        }

        
        public void LoadTexture(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.TextureName);
        }
    }
}

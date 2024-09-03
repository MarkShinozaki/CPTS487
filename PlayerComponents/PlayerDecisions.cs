using EGGS.ScriptInterpreterComponents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using EGGS.ProjectileComponents;


namespace EGGS.PlayerComponents
{
    
    internal class PlayerDecisions
    {

        private float slowMultiplier;
        private float sprintMultiplier;
        private bool isSlowMode = true;

        // Add a field to track whether the F key was already pressed
        private bool fKeyPressedLastFrame = false;

        

        internal PlayerDecisions()
        {
            this.slowMultiplier = 0;
            this.sprintMultiplier = 0;
            LoadPlayerInputScript();
        }


        private void LoadPlayerInputScript()
        {
            PInputInterpreter playerInputInterpreter = new PInputInterpreter("PlayerMultiplier.json");
            string valsConcated = playerInputInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            if (vals.Length < 2)
            {
                System.Diagnostics.Debug.WriteLine($"Expected at least 2 values, but got {vals.Length}. valsConcated was: '{valsConcated}'");
                this.slowMultiplier = 1.0f; // Default value or handle appropriately
                this.sprintMultiplier = 1.0f; // Default value or handle appropriately
                return;
            }

            // Attempt to parse the slowMultiplier
            if (!float.TryParse(vals[0], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out this.slowMultiplier))
            {
                System.Diagnostics.Debug.WriteLine("Failed to parse slowMultiplier.");
                this.slowMultiplier = 1.0f; // Default value or handle appropriately
            }

            // Attempt to parse the sprintMultiplier
            if (!float.TryParse(vals[1], System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out this.sprintMultiplier))
            {
                System.Diagnostics.Debug.WriteLine("Failed to parse sprintMultiplier.");
                this.sprintMultiplier = 1.0f; // Default value or handle appropriately
            }
        }




        public void PlayerInputHandler(ReadyPlayerOne player, GameTime gameTime, ProjectileFactory projectileFactory)
        {
            player.ResetSpeed(); // reset the users speed every frame
            var userButton = Keyboard.GetState(); // grab what button is currently being pressed down

            // Check for Slowdown
            if (userButton.IsKeyDown(Keys.LeftShift))
            {
                player.CurrentSpeed /= this.slowMultiplier;
            }else if (userButton.IsKeyDown(Keys.LeftControl))
            {
                player.CurrentSpeed *= this.sprintMultiplier;
            }

            // directional movement
            if (userButton.IsKeyDown(Keys.A))
            {
                Vector2 pos = player.Position; // copy the player val
                pos.X -= player.CurrentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds; // update based on game time
                player.Position = pos; // update player position with new value
            }
            if (userButton.IsKeyDown(Keys.D))
            {
                Vector2 pos = player.Position;
                pos.X += player.CurrentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                player.Position = pos;
            }
            if (userButton.IsKeyDown(Keys.W))
            {
                Vector2 pos = player.Position;
                pos.Y -= player.CurrentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                player.Position = pos;
            }
            if (userButton.IsKeyDown(Keys.S))
            {
                Vector2 pos = player.Position;
                pos.Y += player.CurrentSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                player.Position = pos;
            }

            //Shoot gun
            if (userButton.IsKeyDown(Keys.Space))
            {
                player.gun.shoot(projectileFactory, player, gameTime);
            }
        }
    }
}

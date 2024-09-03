
namespace EGGS.OnScreenUnits.Figures.PlayerComponents
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using EGGS.OnScreenUnits.Figures;
    using EGGS.OnScreenUnits.MovementDesign;
    using EGGS.OnScreenUnits.MovementDesign.MovementInstances;
    
    using EGGS.OnScreenUnits;

    internal class ReadyPlayerOne : FigureBase
    {

        public bool SlowMode;
        public bool Invincible;
        private double initialSpawnTime;
        private bool spawning;
        private bool resetGameTime = true;

        private KeyboardState currentKey;
        private KeyboardState previousKey;

        public ReadyPlayerOne(Texture2D texture, MovementPattern movement)
            : base(texture, movement)
        { 
            this.spawning = true;
            this.Invincible = false;
        }

        

        public override void Update(GameTime gameTime, List<Sprite> enemies)
        {
            if (this.resetGameTime)
            {
                this.initialSpawnTime = gameTime.TotalGameTime.TotalSeconds;
                this.resetGameTime = !this.resetGameTime;
            }

            this.previousKey = this.currentKey;
            this.currentKey = Keyboard.GetState();

           

            int previousSpeed = this.Movement.CurrentSpeed;

            // check if slow speed
            this.SlowMode = this.IsSlowPressed();

            this.Move();
            this.Movement.CurrentSpeed = previousSpeed;
        }

        

        public bool IsSlowPressed()
        {
            if (this.currentKey.IsKeyDown(Keys.LeftShift))
            {
                this.Movement.CurrentSpeed = this.Movement.Speed / 2;
                return true;
            }

            return false;
        }
       

        private void Move()
        {
            this.Movement.Move();
        }
    }
}


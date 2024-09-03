

namespace EGGS.OnScreenUnits.MovementDesign.MovementInstances
{
    using System.Collections.Generic;
    using System.Numerics;
    using Microsoft.Xna.Framework.Input;
    using EGGS.OnScreenUnits.Figures.PlayerComponents;

    internal class PlayerInput : MovementPattern
    {
        private Vector2 spawnPosition;
        private Vector2 startPosition;
        private bool respawning;


        public PlayerInput(Vector2 spawnPosition, Vector2 startPosition, int speed)
            : base()
        {
            this.spawnPosition = spawnPosition;
            this.startPosition = startPosition;
            this.Speed = speed;
            this.Respawn();
        }

        public void Respawn()
        {
            this.respawning = true;
            this.position = this.spawnPosition;
            this.CurrentSpeed = this.Speed * 2;
            this.velocity = this.CalculateVelocity(this.spawnPosition, this.startPosition, this.CurrentSpeed);
        }

        public override void Move()
        {
            float temporarySpeed = this.Speed;
            if (this.respawning)
            {
                // if start position reached
                if (this.ExceededPosition(this.spawnPosition, this.startPosition, this.Velocity))
                {
                    this.respawning = false; // change bool so entity will move in the pattern
                    this.CurrentSpeed = this.Speed;
                    this.ZeroXVelocity();
                    this.ZeroYVelocity();
                }

                base.Move();
            }
            else
            {
                // Slowing player 

                // Adjust speed based on keyboard state
                var keyboardState = Keyboard.GetState();

                // Movement logic...
                // Note: Use 'temporarySpeed' for calculating movement velocity

                if (keyboardState.IsKeyDown(Keys.A))
                {
                    this.velocity.X = -temporarySpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.D))
                {
                    this.velocity.X = temporarySpeed;
                }

                if (keyboardState.IsKeyDown(Keys.W))
                {
                    this.velocity.Y = -temporarySpeed;
                }
                else if (keyboardState.IsKeyDown(Keys.S))
                {
                    this.velocity.Y = temporarySpeed;
                }

                if (this.IsTouchingLeftOfScreen() || this.IsTouchingRightOfScreen())
                {
                    this.velocity.X = 0;
                }

                if (this.IsTouchingBottomOfScreen() || this.IsTouchingTopOfScreen())
                {
                    this.velocity.Y = 0;
                }

                base.Move();
                this.velocity = Vector2.Zero;
            }
        }
    }
}

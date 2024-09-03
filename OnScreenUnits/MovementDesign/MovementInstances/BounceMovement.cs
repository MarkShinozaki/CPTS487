

using System.Numerics;

namespace EGGS.OnScreenUnits.MovementDesign.MovementInstances
{
    internal class BounceMovement : MovementPattern
    {
        public BounceMovement(Vector2 startPosition, Vector2 velocity, int speed)
            : base()
        {
            this.position = startPosition;
            this.velocity = velocity;
            this.Speed = speed;
        }

        public override void Move()
        {
            if (this.IsTouchingTopOfScreen() || this.IsTouchingBottomOfScreen())
            {
                this.InvertYVelocity();
            }

            if (this.IsTouchingLeftOfScreen() || this.IsTouchingRightOfScreen())
            {
                this.InvertXVelocity();
            }

            base.Move();
        }
    }
}

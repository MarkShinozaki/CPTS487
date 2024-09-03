

namespace EGGS.OnScreenUnits.MovementDesign.MovementInstances
{
    using Microsoft.Xna.Framework;

    internal class linearMovement : MovementPattern
    {
        public linearMovement(Vector2 velocity, int speed)
            : base()
        {
            this.Velocity = velocity;
            this.Speed = speed;
        }

        public override void Move()
        {
            base.Move();
        }



    }
}

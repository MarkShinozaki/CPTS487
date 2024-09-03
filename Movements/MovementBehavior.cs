// MovementBehavior.cs

using EGGS.EnemyComponents;
using Microsoft.Xna.Framework;


namespace EGGS.Movements
{
    public interface IMovementBehavior
    {
        void Move(GameTime gameTime, EnemyBase enemy);
    }
}

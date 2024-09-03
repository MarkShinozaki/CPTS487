// NotSimpleEnemy.cs



namespace EGGS.OnScreenUnits.Figures.EnemyComponents.Enemies
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using EGGS.OnScreenUnits.MovementDesign;
   
    using EGGS.OnScreenUnits;

    internal class NotSimpleEnemy : EnemyBase
    {
        private float timer1;
        private float timer2;
        private float timer3;

        public NotSimpleEnemy(Texture2D texture, MovementPattern movement, int lifeSpan)
            : base(texture, movement, lifeSpan)
        {
            // Initialization specific to EnemyB, if any
        }

    }
}

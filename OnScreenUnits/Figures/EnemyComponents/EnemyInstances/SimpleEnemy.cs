// SimpleEnemy.cs 



namespace EGGS.OnScreenUnits.Figures.EnemyComponents.Enemies
{
    using Microsoft.Xna.Framework.Graphics;
    using EGGS.OnScreenUnits.MovementDesign;
    
    

    internal class SimpleEnemy : EnemyBase
    {
        private float timer2;

        public SimpleEnemy(Texture2D texture, MovementPattern movement, int lifeSpan)
            : base(texture, movement, lifeSpan)
        {
            
        }


    }
}

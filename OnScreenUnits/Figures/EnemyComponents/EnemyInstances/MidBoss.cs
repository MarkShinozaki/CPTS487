// MidBoss.cs 


namespace EGGS.OnScreenUnits.Figures.EnemyComponents.Enemies
{

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Collections.Generic;
    using EGGS.OnScreenUnits.MovementDesign;
    
    using EGGS.OnScreenUnits;

    internal class MidBoss : EnemyBase
    {
        public MidBoss(Texture2D texture, MovementPattern movement, int lifeSpan)
            : base(texture, movement, lifeSpan)
        {
            // Initialization specific to EnemyB, if any
        }
        

    }
}

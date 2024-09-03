// FinalBoss.cs

namespace EGGS.OnScreenUnits.Figures.EnemyComponents.Enemies
{
    using System.Collections.Generic;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using EGGS.OnScreenUnits.MovementDesign;
   
    using EGGS.OnScreenUnits;

    internal class FinalBoss : EnemyBase
    {
        private int previousTime = 0;

        public FinalBoss(Texture2D texture, MovementPattern movement, int lifeSpan)
            : base(texture, movement, lifeSpan)
        {
        }

    }
}

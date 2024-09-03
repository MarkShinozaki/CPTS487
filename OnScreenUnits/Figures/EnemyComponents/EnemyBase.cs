
namespace EGGS.OnScreenUnits.Figures.EnemyComponents
{
    using System.Collections.Generic;
    using EGGS.OnScreenUnits.MovementDesign;
    using EGGS.OnScreenUnits.Figures.PlayerComponents;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System.Numerics;
    
    using EGGS.OnScreenUnits.MovementDesign.MovementInstances;

    internal abstract class EnemyBase : FigureBase
    {
        private double timer;

        public EnemyBase(Texture2D texture, MovementPattern movement, int lifeSpan, int hp = 10)
            : base(texture, movement)
        {
            this.LifeSpan = lifeSpan;
            this.HealthPoints = hp;
            this.timer = 0;
        }

        protected double LifeSpan { get; set; }
        protected int HealthPoints { get; set; }


        

        









    }









}

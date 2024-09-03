// FigureBase.cs 

using EGGS.OnScreenUnits.MovementDesign;


namespace EGGS.OnScreenUnits.Figures
{
    using System;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.OnScreenUnits.MovementDesign;
    


    internal abstract class FigureBase : Sprite, ICloneable
    {
        //public Projectile Projectile;
        //public ushort AttackSpeed = 1;

        //public ushort AttackSpeed = 1;

        protected FigureBase(Texture2D texture, MovementPattern movement)
            : base(texture, movement)
        {
            
        }

        public object Clone() => this.MemberwiseClone();

        
    }
}


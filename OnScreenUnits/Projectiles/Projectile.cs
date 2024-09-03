

namespace EGGS.OnScreenUnits.ProjectileComponents
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using EGGS.OnScreenUnits.Figures.EnemyComponents;
    using EGGS.OnScreenUnits.MovementDesign;
    using EGGS.OnScreenUnits.Figures.PlayerComponents;
    using System.Numerics;
    using EGGS.OnScreenUnits;

    internal abstract class Projectile : FigureSprite, ICloneable
    {
        public Projectile(Texture2D texture, Color color, MovementPattern movement, int damage)
            : base(texture, color, movement)
        {
            this.Damage = damage;
        }

        public FigureSprite Parent { get; set; }

        public int Damage { get; set; }

        // Serves as hitbox (extended lengthwise to account for bullet speed vs framerate)
        public override Rectangle Rectangle
        {
            get => new Rectangle(
                    new Point((int)this.Movement.Position.X - this.Texture.Width, (int)this.Movement.Position.Y - (int)Math.Round(this.Texture.Height * 2.5)),
                    new Point((int)Math.Round(this.Texture.Width * 2.5), (int)Math.Round(this.Texture.Height * 3.5)));
        }

        public override void Update(GameTime gameTime, List<FigureSprite> sprites)
        {
            this.Move();
        }

        public override void OnCollision(FigureSprite sprite)
        {
            // Ignore collision if sprite is one who fired or if sprite is another projectile (for now)
            if (sprite != this.Parent && !(sprite is Projectile))
            {
                // Hit case 1: sprite is Player, and this projectile is from an Enemy
                // Hit case 2: sprite is an Enemy, and this projectile is from Player
                if ((sprite is Player && this.Parent is Enemy) ||
                    (sprite is Enemy && this.Parent is Player))
                {
                    this.IsRemoved = true;
                }
            }
        }

        public virtual void Move()
        {
            if (this.OutOfBounds())
            {
                this.IsRemoved = true;
            }

            this.Movement.Move();
        }

        public object Clone() => this.MemberwiseClone();

        public bool OutOfBounds()
        {
            if (this.Movement.IsTouchingLeftOfScreen() ||
                this.Movement.IsTouchingRightOfScreen() ||
                this.Movement.IsTouchingBottomOfScreen() ||
                this.Movement.IsTouchingTopOfScreen())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

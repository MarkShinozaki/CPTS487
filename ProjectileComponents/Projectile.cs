using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGGS.ProjectileComponents
{
    
    public class Projectile
    {
        public Vector2 Position;
        public float projectileSize;
        private float projectileSpeed;
        public float damage;
        bool FiredUp;
        //private string TextureName;
        public Texture2D Texture;
        private float Spread;
        private int randomnessDirection;
        private float randomness;

       
        public Projectile(Vector2 pos, float size, float speed, float dmg, Texture2D texture, bool FireUp, float spread)
        {
            this.Position = pos;
            this.projectileSize = size;
            this.projectileSpeed = speed;
            this.damage = dmg;
            this.Texture = texture;
            this.FiredUp = FireUp;
            this.Spread = spread;
            Random rand = new Random();
            this.randomnessDirection = (int)rand.Next() % 2;
            this.randomness = (float)rand.NextDouble();
        }

        
        public void ProjectilePath(GameTime gameTime)
        {
            if (FiredUp)
            {
                Vector2 pos = this.Position;
                pos.Y -= this.projectileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.Position = pos;
            }
            else
            {
                Vector2 pos = this.Position;
                pos.Y += this.projectileSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.Position = pos;
            }

            if(this.Spread != 0f)
            {
                Vector2 pos = this.Position;
                if(this.randomnessDirection == 1)
                {
                    pos.X += (randomness * this.Spread) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    this.Position = pos;
                }
                else
                {
                    pos.X -= (randomness * this.Spread) * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    this.Position = pos;
                }
            }
        }
    }
}

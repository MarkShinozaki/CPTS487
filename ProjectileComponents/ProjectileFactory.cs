using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using EGGS.ScriptInterpreterComponents;


namespace EGGS.ProjectileComponents
{
    
    public class ProjectileFactory
    {
        public List<Projectile> ProjectileList;
        public Texture2D Texture;
        private string TextureName;
        private int ProjectileLimit;

        public ProjectileFactory()
        {
            this.ProjectileList = new List<Projectile>();
            this.TextureName = "Textures//DefaultProjectile";
            LoadScript();
        }

        
        public void SpawnProjectile(Vector2 pos, float size, float speed, float dmg, bool FireUp, float spread)
        {
            Projectile projectile = new Projectile(pos, size, speed, dmg, this.Texture, FireUp, spread);
            this.ProjectileList.Add(projectile);
            if(this.ProjectileList.Count > this.ProjectileLimit)
            {
                this.ProjectileList.RemoveAt(1000);//delete projectile when limit is exceeded
            }
        }

        
        public void HandleProjectiles(GameTime gameTime)
        {
            foreach(Projectile projectile in this.ProjectileList)
            {
                projectile.ProjectilePath(gameTime);
            }
        }

        
        public void LoadTexture(ContentManager content)
        {
            this.Texture = content.Load<Texture2D>(this.TextureName);
        }

        
        public void LoadScript()
        {
            ProjectileInterpreter projectileFactoryInterpreter = new ProjectileInterpreter("ProjectileScript.json");
            string valsConcated = projectileFactoryInterpreter.JsonInterpreter();
            string[] vals = valsConcated.Split(',');

            this.ProjectileLimit = int.Parse(vals[0]);
        }
    }
    
}

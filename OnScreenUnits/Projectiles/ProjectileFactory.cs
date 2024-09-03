﻿

namespace EGGS.OnScreenUnits.ProjectileComponents
{
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;
    using EGGS.OnScreenUnits.ProjectileComponents.ProjectileInstances;
    using EGGS.OnScreenUnits.MovementDesign;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;



    internal class ProjectileFactory
    {
        public static Projectile CreateProjectile(Dictionary<string, object> projectileProperties)
        {
            Projectile projectile = null;

            string textureName = (string)projectileProperties["textureName"];
            Texture2D texture = TextureFactory.GetTexture(textureName);

            string colorName = (string)projectileProperties["color"];
            Color color = System.Drawing.Color.FromName(colorName).ToXNA();

            MovementPattern movement = SpatialMovementPatternFactory.CreateMovementPattern((Dictionary<string, object>)projectileProperties["movementPattern"]);
            movement.Origin = new Vector2(texture.Width / 2, texture.Height / 2); // Orgin is based on texture

            int damage = (int)projectileProperties["damage"];

            switch (projectileProperties["projectileType"])
            {
                case "bullet":
                    projectile = new Bullet(texture, color, movement, damage);
                    break;
                case "bouncingBullet":
                    projectile = new BouncingBullet(texture, color, movement, damage);
                    break;
                case "bounceBullet":
                    int numberOfTimesToBounce = (int)projectileProperties["bounceTimes"];
                    projectile = new BounceBullet(texture, color, movement, numberOfTimesToBounce, damage);
                    break;
                default:
                    throw new Exception("Invalid Projectile Type");
            }

            return projectile;
        }
    }
}

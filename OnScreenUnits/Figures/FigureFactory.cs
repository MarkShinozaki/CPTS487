// FigureFactory.cs



namespace EGGS.OnScreenUnits.Figures
{
    using EGGS.OnScreenUnits.Figures.EnemyComponents.Enemies;
    using EGGS.OnScreenUnits.Figures.PlayerComponents;
    using EGGS.OnScreenUnits.MovementDesign;
    
    using EGGS.Utility;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using System;
    using System.Collections.Generic;


    internal class FigureFactory
    {
        public static FigureBase CreateEntity(Dictionary<string, object> WaveProperties)
        {
            FigureBase entity = null;
            string textureName = (string)WaveProperties["textureName"];
            Texture2D texture = LoadTextures.GetTexture(textureName);

            //string colorName = (string)WaveProperties["color"];
            

            MovementPattern movement;

            if (WaveProperties.ContainsKey("movementPattern"))
            {
                movement = MovementFactory.CreateMovementPattern((Dictionary<string, object>)WaveProperties["movementPattern"]);
                movement.Origin = new Vector2(texture.Width / 2, texture.Height / 2); // Orgin is based on texture
            }
            else
            {
                movement = null;
            }



            
            string enemyType = (string)WaveProperties["entityType"];
            string entityClassification = (string)WaveProperties["entityType"] != "player" ? "enemy" : "player";

            switch (entityClassification)
            {
                case "enemy":
                    int lifeSpan = (int)WaveProperties["lifeSpan"];

                    switch (enemyType)
                    {
                        case "simpleGrunt":
                            entity = new SimpleEnemy(texture, movement, lifeSpan);
                            break;
                        case "complexGrunt":
                            entity = new NotSimpleEnemy(texture, movement, lifeSpan);
                            break;
                        case "midBoss":
                            entity = new MidBoss(texture, movement, lifeSpan);
                            break;
                        case "finalBoss":
                            entity = new FinalBoss(texture, movement, lifeSpan);
                            break;
                    }

                    break;
                default:
                    throw new Exception("Invalid Entity");
            }

            if (entity.Movement != null)
            {
                entity.Movement.Parent = entity;
            }

            

            return entity;
        }
    }
}

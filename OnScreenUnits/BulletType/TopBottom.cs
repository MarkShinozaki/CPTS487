namespace EGGS.OnScreenUnits.BulletType
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;


    using EGGS.Factory;
    using EGGS.MovementDesign;
   
    /// <summary>
    /// 
    /// </summary>
    class TopBottom : Bullet
    {
        public List<Bullet> bullets;
        private ContentManager Content;
        private BulletFactory factory;
        Random random = new Random();

        public TopBottom(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility)
            : base(newTexture, newPosition, newVelocity, visibility, null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        /// <param name="directionModifier"></param>
        public TopBottom(Vector2 newPosition, ContentManager gameContent, int directionModifier) : base(null, newPosition, Vector2.Zero, true, null)
        {
            Vector2 randomPos = new Vector2(position.X + 94, position.Y + 63);

            Content = gameContent;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            int randDir = 0;
            for (int i = 0; i < 30; i++)
            {
                BulletMovement moves = new BulletMovement();
                for (int j = 0; j < 15; j++)
                {
                    randDir = random.Next(0, 3);
                    if (randDir == 0)
                        moves.addMovement(new MD(0.5));
                    else if (randDir == 1)
                        moves.addMovement(new MDL(0.5));
                    else if (randDir == 2)
                        moves.addMovement(new MDR(0.5));
                }
                bullets.Add(factory.bulletFactory("bullet2", new Vector2(-50 + i * 35, -i * 10), new Vector2(1, (3 * directionModifier)), true, 1, moves));
            }
            for (int i = 0; i < 30; i++)
            {
                BulletMovement moves = new BulletMovement();
                for (int j = 0; j < 20; j++)
                {
                    randDir = random.Next(0, 3);
                    if (randDir == 0)
                        moves.addMovement(new MU(0.5));
                    else if (randDir == 1)
                        moves.addMovement(new MUL(0.5));
                    else if (randDir == 2)
                        moves.addMovement(new MUR(0.5));
                }
                bullets.Add(factory.bulletFactory("bullet2", new Vector2(-50 + i * 35, 450 + i * 10), new Vector2(1, (3 * directionModifier)), true, 1, moves));
            }
        }
    }
}

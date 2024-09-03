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
    class RandomBullets : Bullet
    {
        public List<Bullet> bullets; //may depend on design
        private ContentManager Content;
        private BulletFactory factory;
        public RandomBullets(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility)
            : base(newTexture, newPosition, newVelocity, visibility, null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        /// <param name="directionModifier"></param>
        public RandomBullets(Vector2 newPosition, ContentManager gameContent, int directionModifier) : base(null, newPosition, Vector2.Zero, true, null)
        {
            Random random = new Random();
            Content = gameContent;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);

            Vector2 pos = new Vector2(random.Next(0, 1000), random.Next(0, 40));
            int randDir = random.Next(0, 3);
            BulletMovement moves = new BulletMovement();

            Movement mov = new MDL(7.0);
            if (randDir == 0)
                moves.addMovement(new MD(7.0));
            else if (randDir == 1)
                moves.addMovement(new MDL(7.0));
            else if (randDir == 2)
                moves.addMovement(new MDR(7.0));

            bullets.Add(factory.bulletFactory("bullet2", pos, new Vector2(1, (2 * directionModifier)), true, 1, moves));
        }
    }
}

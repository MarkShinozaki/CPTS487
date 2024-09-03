namespace EGGS.OnScreenUnits.BulletType
{

    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.Factory;
    using EGGS.MovementDesign;
   
    /// <summary>
    /// 
    /// </summary>
    class FinalBossBullet : Bullet
    {
        public List<Bullet> bullets; 
        private ContentManager Content;
        private BulletFactory factory;
        public FinalBossBullet(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility)
            : base(newTexture, newPosition, newVelocity, visibility, null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        /// <param name="directionModifier"></param>
        public FinalBossBullet(Vector2 newPosition, ContentManager gameContent, int directionModifier) : base(null, newPosition, Vector2.Zero, true, null)
        {
            Vector2 midShotPos = new Vector2(position.X + 94, position.Y + 100);
            Vector2 leftShotPot = new Vector2(position.X + 40, position.Y + 100);
            Vector2 rightShotPos = new Vector2(position.X + 148, position.Y + 100);

            Content = gameContent;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            BulletMovement down = new BulletMovement();
            BulletMovement downLeft = new BulletMovement();
            BulletMovement downRight = new BulletMovement();
            down.addMovement(new MD(7.0));
            downLeft.addMovement(new MDL(7.0));
            downRight.addMovement(new MDR(7.0));
            bullets.Add(factory.bulletFactory("bullet2", midShotPos, new Vector2(0, (10 * directionModifier)), true, 1, down));
            bullets.Add(factory.bulletFactory("bullet2", midShotPos, new Vector2(-5, (10 * directionModifier)), true, 1, downLeft));
            bullets.Add(factory.bulletFactory("bullet2", midShotPos, new Vector2(-10, (10 * directionModifier)), true, 1, downLeft));
            bullets.Add(factory.bulletFactory("bullet2", midShotPos, new Vector2(-5, (10 * directionModifier)), true, 1, downRight));
            bullets.Add(factory.bulletFactory("bullet2", midShotPos, new Vector2(-10, (10 * directionModifier)), true, 1, downRight));

            bullets.Add(factory.bulletFactory("bullet2", leftShotPot, new Vector2(-1, (10 * directionModifier)), true, 1, down));
            bullets.Add(factory.bulletFactory("bullet2", rightShotPos, new Vector2(-1, (10 * directionModifier)), true, 1, down));

        }
    }
}

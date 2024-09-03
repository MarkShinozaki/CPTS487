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
    class Spiral : Bullet
    {
        public List<Bullet> bullets; //may depend on design
        private ContentManager Content;
        private BulletFactory factory;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newTexture"></param>
        /// <param name="newPosition"></param>
        /// <param name="newVelocity"></param>
        /// <param name="visibility"></param>
        public Spiral(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility)
            : base(newTexture, newPosition, newVelocity, visibility, null)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPosition"></param>
        /// <param name="gameContent"></param>
        /// <param name="directionModifier"></param>
        public Spiral(Vector2 newPosition, ContentManager gameContent, int directionModifier) : base(null, newPosition, Vector2.Zero, true, null)
        {
            Content = gameContent;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            BulletMovement down = new BulletMovement();
            down.addMovement(new MD(.65));
            down.addMovement(new MDR(.65));
            down.addMovement(new MR(10.5));

            BulletMovement downLeft = new BulletMovement();
            downLeft.addMovement(new MDR(.65));
            downLeft.addMovement(new MR(.65));
            downLeft.addMovement(new MUR(10.5));

            BulletMovement downRight = new BulletMovement();
            downRight.addMovement(new MDL(.65));
            downRight.addMovement(new MD(.65));
            downRight.addMovement(new MDR(10.5));

            BulletMovement right = new BulletMovement();
            right.addMovement(new ML(.65));
            right.addMovement(new MDL(.65));
            right.addMovement(new MD(10.5));

            BulletMovement left = new BulletMovement();
            left.addMovement(new MR(.65));
            left.addMovement(new MUR(.65));
            left.addMovement(new MU(10.5));

            BulletMovement upLeft = new BulletMovement();
            upLeft.addMovement(new MUR(.65));
            upLeft.addMovement(new MU(.65));
            upLeft.addMovement(new MUL(10.5));

            BulletMovement up = new BulletMovement();
            up.addMovement(new MU(.65));
            up.addMovement(new MUL(.65));
            up.addMovement(new ML(10.5));

            BulletMovement upRight = new BulletMovement();
            upRight.addMovement(new MUL(.65));
            upRight.addMovement(new ML(.65));
            upRight.addMovement(new MDL(10.5));

            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, down));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, downLeft));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, downRight));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, right));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, left));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, upLeft));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, up));
            bullets.Add(factory.bulletFactory("bullet2", new Vector2(position.X + 94, position.Y + 40), new Vector2(4, (3 * directionModifier)), true, 1, upRight));
        }
    }
}

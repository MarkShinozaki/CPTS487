

namespace EGGS.OnScreenUnits.BulletType
{
    using System.Collections.Generic;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.Factory;
    using EGGS.MovementDesign;

    


    class BulletSpread : Bullet
    {
        public List<Bullet> bullets; //may depend on design
        private ContentManager Content;
        private BulletFactory factory;
        public BulletSpread(Texture2D newTexture, Vector2 newPosition, Vector2 newVelocity, bool visibility)
            : base(newTexture, newPosition, newVelocity, visibility, null)
        { }
        public BulletSpread(Vector2 newPosition, ContentManager gameContent, int directionModifier) : base(null, newPosition, Vector2.Zero, true, null)
        {
            position = newPosition;
            Content = gameContent;
            bullets = new List<Bullet>();
            factory = new BulletFactory(gameContent);
            BulletMovement up = new BulletMovement();
            BulletMovement upLeft = new BulletMovement();
            BulletMovement upRight = new BulletMovement();
            up.addMovement(new MU(7.0));
            upLeft.addMovement(new MUL(7.0));
            upRight.addMovement(new MUR(7.0));
            bullets.Add(factory.bulletFactory("bullet4", position, new Vector2(0, (10 * directionModifier)), true, 1, up));
            bullets.Add(factory.bulletFactory("bullet4", position, new Vector2(5, (10 * directionModifier)), true, 1, upLeft));
            bullets.Add(factory.bulletFactory("bullet4", position, new Vector2(10, (10 * directionModifier)), true, 1, upLeft));
            bullets.Add(factory.bulletFactory("bullet4", position, new Vector2(5, (10 * directionModifier)), true, 1, upRight));
            bullets.Add(factory.bulletFactory("bullet4", position, new Vector2(10, (10 * directionModifier)), true, 1, upRight));
        }
    }
}

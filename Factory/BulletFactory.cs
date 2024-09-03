

namespace EGGS.Factory
{
    using System;

    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.Graphics;

    using EGGS.OnScreenUnits.BulletType;
    using EGGS.MovementDesign;



    class BulletFactory
    {
        private ContentManager Content;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gameContent"></param>
        public BulletFactory(ContentManager gameContent)
        {
            Content = gameContent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulletName"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <param name="visibility"></param>
        /// <param name="bulletType"></param>
        /// <returns></returns>
        public Bullet bulletFactory(String bulletName, Vector2 position, Vector2 velocity, bool visibility, int bulletType)
        {
            BulletMovement newMove = new BulletMovement();

            newMove.addMovement(new MD(7.0)); 

            bulletName = "Textures/" + bulletName;

            switch (bulletType)
            {
                case 1: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, newMove);
                case 5: return new BulletSpread(position, Content, 1);
                case 6: return new FinalBossBullet(position, Content, 1);
                case 7: return new MBSpread(position, Content, 1);
                case 8: return new RandomBullets(position, Content, 1);
                case 9: return new TopBottom(position, Content, 1);
                case 10: return new Spiral(position, Content, 1);
                default: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, newMove);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulletName"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <param name="visibility"></param>
        /// <param name="bulletType"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Bullet bulletFactory(String bulletName, Vector2 position, Vector2 velocity, bool visibility, int bulletType, int direction)
        {
            BulletMovement newMove = new BulletMovement();

            newMove.addMovement(new MD(7.0)); // addMovement -> newMovement 

            bulletName = "Textures/" + bulletName;

            switch (bulletType)
            {
                case 1: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, newMove);
                case 5: return new BulletSpread(position, Content, 1);
                case 6: return new FinalBossBullet(position, Content, 1);
                case 7: return new MBSpread(position, Content, 1);
                case 8: return new RandomBullets(position, Content, 1);
                case 9: return new TopBottom(position, Content, 1);
                case 10: return new Spiral(position, Content, 1);
                default: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, newMove);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bulletName"></param>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <param name="visibility"></param>
        /// <param name="bulletType"></param>
        /// <param name="move"></param>
        /// <returns></returns>
        public Bullet bulletFactory(String bulletName, Vector2 position, Vector2 velocity, bool visibility, int bulletType, BulletMovement move)
        {
            bulletName = "Textures/" + bulletName;
            switch (bulletType)
            {
                case 1: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, move); 
                case 5: return new BulletSpread(position, Content, 1);
                case 6: return new FinalBossBullet(position, Content, 1);
                case 7: return new MBSpread(position, Content, 1);
                case 8: return new RandomBullets(position, Content, 1);
                case 9: return new TopBottom(position, Content, 1);
                case 10: return new Spiral(position, Content, 1);
                default: return new Bullet(Content.Load<Texture2D>(bulletName), position, velocity, visibility, move); 
            }
        }

    }
}

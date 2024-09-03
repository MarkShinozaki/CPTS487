namespace EGGS.EnemyComponents
{
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;

    using EGGS.MovementDesign;
    using EGGS.OnScreenUnits;

    abstract class EnemyFactory
    {
       /// <summary>
       /// 
       /// </summary>
       /// <param name="content"></param>
       /// <param name="randY"></param>
       /// <returns></returns>
        public abstract Enemy CreateEnemy(ContentManager content, int randY);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="vel"></param>
        /// <param name="_content"></param>
        /// <param name="move"></param>
        /// <returns></returns>
        public abstract Enemy CreateEnemy(Vector2 pos, Vector2 vel, ContentManager _content, EnemyMovement move);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content"></param>
        /// <param name="randY"></param>
        /// <returns></returns>
        public Enemy AddEnemy(ContentManager content, int randY)
        {
            return CreateEnemy(content, randY);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class EnemyACreator : EnemyFactory
    {
        public override Enemy CreateEnemy(ContentManager content, int randY)
        {
            return new EnemyA(new Vector2(1100, randY), content);
        }

        public override Enemy CreateEnemy(Vector2 pos, Vector2 vel, ContentManager _content, EnemyMovement moves)
        {
            return new EnemyA(pos, vel, _content, moves);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class EnemyBCreator : EnemyFactory
    {
        public override Enemy CreateEnemy(ContentManager content, int randY)
        {
            return new EnemyB(new Vector2(1100, randY), content);
        }

        public override Enemy CreateEnemy(Vector2 pos, Vector2 vel, ContentManager _content, EnemyMovement moves)
        {
            return new EnemyB(pos, vel, _content, moves);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class MidBossCreator : EnemyFactory
    {
        public override Enemy CreateEnemy(ContentManager content, int randY)
        {
            return new MidBoss(new Vector2(300, 50), content);
        }
        public Enemy CreateEnemy(Vector2 pos, ContentManager _content)
        {
            return new MidBoss(pos, _content);
        }
        public override Enemy CreateEnemy(Vector2 pos, Vector2 vel, ContentManager _content, EnemyMovement moves)
        {
            return new MidBoss(pos, _content);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    class FinalBossCreator : EnemyFactory
    {
        public override Enemy CreateEnemy(ContentManager content, int randY)
        {
            return new FinalBoss(new Vector2(100, 50), content);
        }
        public Enemy CreateEnemy(Vector2 pos, ContentManager _content)
        {
            return new FinalBoss(pos, _content);
        }
        public override Enemy CreateEnemy(Vector2 pos, Vector2 vel, ContentManager _content, EnemyMovement moves)
        {
            return new FinalBoss(pos, _content);
        }
    }
}
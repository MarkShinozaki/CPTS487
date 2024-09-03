namespace EGGS.MovementDesign
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MD : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MD(double newSeconds) : base(newSeconds)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public override Vector2 getNewPosition(Vector2 position, Vector2 velocity)
        {
            Vector2 ret = position;
            ret.Y += velocity.Y;

            return ret;
        }
    }
}

namespace EGGS.MovementDesign
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MR : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MR(double newSeconds) : base(newSeconds)
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
            ret.X -= velocity.X;

            return ret;
        }
    }
}

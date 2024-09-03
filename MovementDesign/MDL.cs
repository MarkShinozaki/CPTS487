namespace EGGS.MovementDesign
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MDL : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MDL(double newSeconds) : base(newSeconds)
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
            Movement down = new MD(seconds);
            Movement left = new ML(seconds);
            Vector2 temp = down.getNewPosition(position, velocity);
            return left.getNewPosition(temp, velocity);
        }
    }
}

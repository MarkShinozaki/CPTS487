namespace EGGS.MovementDesign
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MDR : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MDR(double newSeconds) : base(newSeconds)
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
            Movement right = new MR(seconds);
            Vector2 temp = right.getNewPosition(position, velocity);
            return down.getNewPosition(temp, velocity);
        }
    }
}

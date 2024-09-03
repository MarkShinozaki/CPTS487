namespace EGGS.MovementDesign
{
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MUR : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MUR(double newSeconds) : base(newSeconds)
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
            Movement up = new MU(seconds);
            Movement right = new MR(seconds);
            Vector2 temp = right.getNewPosition(position, velocity);
            return up.getNewPosition(temp, velocity);
        }
    }
}

namespace EGGS.MovementDesign
{

    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    class MUL : Movement
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public MUL(double newSeconds) : base(newSeconds)
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
            Movement left = new ML(seconds);
            Vector2 temp = left.getNewPosition(position, velocity);
            return up.getNewPosition(temp, velocity);
        }
    }
}

namespace EGGS.MovementDesign
{
    using System;
    using Microsoft.Xna.Framework;

    /// <summary>
    /// 
    /// </summary>
    public abstract class Movement
    {
        /// <summary>
        /// 
        /// </summary>
        public Double seconds;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newSeconds"></param>
        public Movement(Double newSeconds)
        {
            seconds = newSeconds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="velocity"></param>
        /// <returns></returns>
        public abstract Vector2 getNewPosition(Vector2 position, Vector2 velocity);
    }
}

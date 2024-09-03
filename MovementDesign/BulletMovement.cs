namespace EGGS.MovementDesign
{
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    class BulletMovement
    {
        private List<Movement> moves;

        public BulletMovement()
        {
            moves = new List<Movement>();
        }

        public void addMovement(Movement newmove)
        {
            moves.Add(newmove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool popMovement()
        {
            if (moves.Count > 0)
            {
                moves.RemoveAt(0);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Movement GetMovement()
        {
            if (moves.Count > 0)
                return moves[0];
            return new MD(5.0);
        }

        /// <summary>
        /// 
        /// </summary>
        public void clearMovements()
        {
            moves.RemoveRange(0, moves.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            if (moves.Count > 0)
            {
                return false;
            }
            
            return true;
        }
    }
}

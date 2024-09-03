namespace EGGS.MovementDesign
{
    using System.Collections.Generic;
    
    /// <summary>
    /// 
    /// </summary>
    class EnemyMovement
    {
        private List<Movement> moves;

        /// <summary>
        /// 
        /// </summary>
        public EnemyMovement()
        {
            moves = new List<Movement>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newmove"></param>
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

using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EGGS.OnScreenUnits.MovementDesign
{
    public static class MovementUtil
    {
        public static List<Vector2> CalculatePathPositions(Vector2 start, Vector2 end, int entityCount)
        {
            List<Vector2> positions = new List<Vector2>();

            if (entityCount <= 1)
            {
                positions.Add(start);
                return positions;
            }

            for (int i = 0; i < entityCount; i++)
            {
                float t = (float)i / (entityCount - 1);
                Vector2 interpolatedPosition = Vector2.Lerp(start, end, t);
                positions.Add(interpolatedPosition);
            }

            return positions;
        }
    }
}

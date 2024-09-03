// WaveBuilder.cs 

namespace EGGS.GameWaves
{
    using System.Collections.Generic;
    using EGGS.OnScreenUnits;
    using EGGS.OnScreenUnits.Figures;
    using EGGS.OnScreenUnits.MovementDesign;

    internal class WaveBuilder
    {
        public static WaveEntities CreateEntityGroup(Dictionary<string, object> waveProperties)
        {
            FigureBase entityType = FigureFactory.CreateEntity((Dictionary<string, object>)waveProperties["WaveProperties"]);
            
            int entityAmount = (int)waveProperties["entityAmount"];
           
            List<MovementPattern> movementPatterns;

            if (waveProperties.ContainsKey("movementPattern"))
            {
                movementPatterns = MovementFactory.CreateListOfMovementPatterns((Dictionary<string, object>)waveProperties["movementPattern"], entityAmount);
            }
            else
            {
                movementPatterns = new List<MovementPattern>();
            }

            return new WaveEntities(entityType, entityAmount, movementPatterns);
        }
    }
}



namespace EGGS.GameWaves
{
    using System.Collections.Generic;
    using EGGS.OnScreenUnits;
    using EGGS.OnScreenUnits.Figures;
    using EGGS.OnScreenUnits.MovementDesign;

    internal class WaveEntities
    {
        public FigureBase WaveEnemy;
        public int EntityAmount;
        public List<MovementPattern> MovementPatterns; // Use public field or property for access

        // Constructor accepting a list of MovementPattern
        public WaveEntities(FigureBase waveEnemy, int entityAmount, List<MovementPattern> movementPatterns)
        {
            WaveEnemy = waveEnemy;
            EntityAmount = entityAmount;
            MovementPatterns = movementPatterns;
        }

        public void CreateEntities(List<Sprite> sprites)
        {
            for (int i = 0; i < EntityAmount; i++)
            {
                var enemy = (FigureBase)WaveEnemy.Clone();
                // Check if there are enough movement patterns for each entity; otherwise, cycle through them
                var pattern = MovementPatterns.Count > i ? MovementPatterns[i] : MovementPatterns[i % MovementPatterns.Count];
                enemy.Movement = pattern;
                sprites.Add(enemy);
            }
        }
    }
}

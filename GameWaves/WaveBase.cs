// WaveBase.cs 

namespace EGGS.GameWaves
{
    using System.Collections.Generic;
    using EGGS.OnScreenUnits;

    internal class WaveBase
    {
        public int WaveNumber;
        public int WaveDuration;
        public WaveEntities WaveEntities; // Changed from List to a single object

        public WaveBase(Dictionary<string, object> waveProperties)
        {
            WaveNumber = (int)waveProperties["waveID"];
            WaveDuration = (int)waveProperties["waveDuration"];
            WaveEntities = WaveBuilder.CreateEntityGroup((Dictionary<string, object>)waveProperties["waveEntities"]);
        }

        public void CreateWave(List<Sprite> sprites)
        {
            WaveEntities.CreateEntities(sprites);
        }
    }

}


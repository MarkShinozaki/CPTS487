namespace EGGS.ScriptInterpreter
{
    
    using System.Collections.Generic;

    using EGGS.OnScreenUnits;
    
    /// <summary>
    /// 
    /// </summary>
    class Wave
    {
        private List<Enemy> enemies;
        public int waveNum;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newWaveNumber"></param>
        public Wave(int newWaveNumber)
        {
            enemies = new List<Enemy>();
            this.waveNum = newWaveNumber;
        }

        public Wave(int newWaveNumber, List<Enemy> newEnemyList)
        {
            enemies = newEnemyList;
            this.waveNum = newWaveNumber;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newEnemy"></param>
        public void addEnemy(Enemy newEnemy)
        {
            enemies.Add(newEnemy);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Enemy> getAllEnemies()
        {
            return enemies;
        }
    }
}

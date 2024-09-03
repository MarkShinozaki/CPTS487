/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File:  GameEventManager.cs
 - 4/8/24
 */

namespace PlantsVSzombies
{
    public static class GameEventManager
    {
        public static void doDamage(int d, IZombie e)
        {
            e.takeDamage(d);
        }
        public static void doDamageFromAbove(IZombie e)
        {
            doDamage(40, e);
        }
        //Called when "collision" is detected between 
        //a magnet-shroom and an Enemy e 
        //i.e, when the user select the magnet-shroom attack. 
        public static void applyMagnetForce(IZombie e)
        {
            if (GameObjectManager.enemies[0].getType() == 'B')
                GameObjectManager.enemies[0] = new ZombieBase();
        }

        //To separate the responsibilities, the above methods should not  
        //be called directly from your code handling user-interaction.  
        //Instead, it should be done in this “hub” operation in the control  
        //class. Since we are simulating, pass an “int” to represent the plant.  
        public static void simulateCollisionDetection(int plant)
        {
            //The method gets access to the “enemies” list in GameObjectManager 
            //and finds the first Enemy to be the one to collide with.   
            //Then, it passes e to one of the functions above. 
            switch (plant)
            {
                case (1):
                    doDamage(25, GameObjectManager.enemies[0]);
                    break;
                case (2):
                    doDamageFromAbove(GameObjectManager.enemies[0]);
                    break;
                case (3):
                    applyMagnetForce(GameObjectManager.enemies[0]);
                    break;
                default:
                    doDamage(plant, GameObjectManager.enemies[0]);
                    break;
            }
        }
    }
}

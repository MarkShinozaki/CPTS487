/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File: ZombieStyle.cs
 - 4/8/24
 */


namespace PlantsVSzombies
{
    public abstract class ZombieStyle : IZombie
    {
        protected IZombie zombie;

        public ZombieStyle(IZombie _zombie)
        {
            this.zombie = _zombie;
        }

        public virtual bool Die()
        {
            return zombie.die();
        }

        public virtual int GetHealth()
        {
            return zombie.getHealth();
        }

        public virtual char GetType()
        {
            return zombie.getType();
        }

        public virtual int TakeDamage(int d)
        {
            return zombie.takeDamage(d);
        }
    }
}

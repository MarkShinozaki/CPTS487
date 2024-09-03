/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File:  IZombie.cs
 - 4/8/24
 */

namespace PlantsVSzombies
{
    public abstract class IZombie
    {
        private int health;

        public abstract int getHealth();

        private char type;

        public abstract char getType();

        public abstract void add(IZombie z);

        public abstract void remove(int index);

        public abstract int takeDamage(int d);

        public abstract bool die();
    }
}

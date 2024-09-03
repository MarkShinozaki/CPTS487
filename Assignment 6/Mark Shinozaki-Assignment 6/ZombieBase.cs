/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File: ZombieBase.cs
 - 4/8/24
 */


namespace PlantsVSzombies
{
    public class ZombieBase : IZombie
    {

        private int health = 50;
        private char type = 'R';

        public override void add(IZombie z)
        {
        }

        public override void remove(int index)
        {
        }

        public override int takeDamage(int d)
        {
            int leftOver = d - this.health;
            this.health -= d;
            return leftOver;
        }

        public override bool die()
        {
            return this.health <= 0;
        }

        public override int getHealth()
        {
            return this.health;
        }

        public override char getType()
        {
            return this.type;
        }
    }

    class Cone : ZombieStyle
    {
        private int health = 25;
        private char type = 'C';

        public Cone(IZombie zombie)
            : base(zombie)
        {
            this.zombie = zombie;
        }

        public override int getHealth()
        {
            return this.health;
        }

        public override char getType()
        {
            return this.type;
        }

        public override int takeDamage(int d)
        {
            int leftOver = d - this.health;
            this.health -= d;
            return leftOver;
        }

        public override bool die()
        {
            return this.health <= 0;
        }

        public override void add(IZombie z)
        {
        }

        public override void remove(int index)
        {
        }
    }

    class Bucket : ZombieStyle
    {
        private int health = 100;
        private char type = 'B';

        public Bucket(IZombie zombie) : base(zombie)
        {
            this.zombie = zombie;
        }

        public override int getHealth()
        {
            return this.health;
        }

        public override char getType()
        {
            return this.type;
        }

        public override int takeDamage(int d)
        {
            int leftOver = d - this.health;
            this.health -= d;
            return leftOver;
        }

        public override bool die()
        {
            return this.health <= 0;
        }

        public override void add(IZombie z)
        {
        }

        public override void remove(int index)
        {
        }
    }

    class ScreenDoor : ZombieStyle
    {
        private int health = 25;
        private char type = 'S';

        public ScreenDoor(IZombie zombie) : base(zombie)
        {
            this.zombie = zombie;
        }

        public override int getHealth()
        {
            return this.health;
        }


        public override char getType()
        {
            return this.type;
        }

        public override int takeDamage(int d)
        {
            int leftOver = d - this.health;
            this.health -= d;
            return leftOver;
        }

        public override bool die()
        {
            return this.health <= 0;
        }

        public override void add(IZombie z)
        {
        }

        public override void remove(int index)
        {
        }
    }
}

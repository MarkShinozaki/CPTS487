/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File: ZombieAssembly.cs 
 - 4/8/24
 */

namespace PlantsVSzombies
{
    internal abstract class ZombieAssembly
    {
        public abstract IZombie CreateZombie();
    }

    internal class RegularZombieFactory : ZombieAssembly
    {
        public override IZombie CreateZombie()
        {
            return new ZombieBase();
        }
    }

    internal class ConeZombieFactory : ZombieAssembly
    {
        public override IZombie CreateZombie()
        {
            return new Cone(new ZombieBase());
        }
    }

    internal class BucketZombieFactory : ZombieAssembly
    {
        public override IZombie CreateZombie()
        {
            return new Bucket(new ZombieBase());
        }
    }

    internal class DoorZombieFactory : ZombieAssembly
    {
        public override IZombie CreateZombie()
        {
            return new ScreenDoor(new ZombieBase());
        }
    }
}

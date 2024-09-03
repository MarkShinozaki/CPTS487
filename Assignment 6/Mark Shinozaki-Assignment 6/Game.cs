/*
 - Mark Shinozaki
 - 11672355
 - Cpts 487 - Assignment 6
 - File: Game.cs
 - 4/8/24
 */

namespace PlantsVSzombies
{
    internal class Game
    {
        static void Main(string[] args)
        {

            RegularZombieFactory rf = new RegularZombieFactory();
            ConeZombieFactory cf = new ConeZombieFactory();
            BucketZombieFactory bf = new BucketZombieFactory();
            DoorZombieFactory df = new DoorZombieFactory();

            string input;
            int damage = 25;

            while (true)
            {
                Console.WriteLine("1. Create Zombies?");
                Console.WriteLine("2. Demo game play.");
                Console.WriteLine("Enter q to exit, or r to reset the game.");
                try
                {
                    input = Console.ReadLine();
                    if (input == "q")
                    {return;}
                    if (input == "1")
                    {
                        Console.WriteLine("- * - * - * - * - * - * - * - * - * -");
                        Console.WriteLine("Enter creation (q to exit):");
                        while (true)
                        {
                            Console.WriteLine("Which kind?");
                            Console.WriteLine("1. Regular\n; 2. Cone\n; 3. Bucket\n; 4. ScreenDoor\n");
                            input = Console.ReadLine();
                            if (input == "q") break;

                            IZombie z = DirectBuilder(rf, cf, bf, df, input);

                            if (z != null)
                            {
                                GameObjectManager.enemies.Add(z);
                            }
                            PrintArray(GameObjectManager.enemies);

                        }
                    }

                    else if (input == "2")
                    {
                        if (GameObjectManager.enemies.Count == 0)
                        {
                            Console.WriteLine("No zombies created yet. Start over.");
                            continue;
                        }

                        int count = 0;
                        while (GameObjectManager.enemies.Count != 0)
                        {
                            Console.WriteLine("Round " + count + ": ");
                            count++;
                            PrintArray(GameObjectManager.enemies);
                            Console.WriteLine("\n1 -- Peashooter Z\n");
                            Console.WriteLine("2 -- Watermelon Z\n");
                            Console.WriteLine("3 -- Magent Z\n");
                            int result = int.Parse(Console.ReadLine());
                            GameEventManager.simulateCollisionDetection(result);
                            if (GameObjectManager.enemies[0].die())
                                GameObjectManager.enemies.RemoveAt(0);
                        }
                        PrintArray(GameObjectManager.enemies);
                    }

                    else if (input == "p")
                    {
                        PrintArray(GameObjectManager.enemies);
                    }

                    else if (input == "r")
                    {
                        GameObjectManager.enemies.Clear();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static IZombie DirectBuilder(RegularZombieFactory z, ConeZombieFactory c, BucketZombieFactory b, DoorZombieFactory d, string t)
        {
            switch (t)
            {
                // Zombie 1
                case "1":
                case "r":
                case "R":
                    return z.CreateZombie();
                    break;

                // Zombie 2
                case "2":
                case "c":
                case "C":
                    return c.CreateZombie();
                    break;

                // Zombie 3
                case "3":
                case "b":
                case "B":
                    return b.CreateZombie();
                    break;

                // Zombie 4
                case "4":
                case "s":
                case "S":
                    return d.CreateZombie();
                    break;
                default:
                    return z.CreateZombie();
                    break;
            }
        }

        static void PrintArray(List<IZombie> l)
        {
            Console.Write("[");
            for (int i = 0; i < l.Count; i++)
            {
                IZombie z = l[i];
                Console.Write(z.getType() + "/" + z.getHealth() + ", ");
            }
            Console.WriteLine("]");
        }
    }
}

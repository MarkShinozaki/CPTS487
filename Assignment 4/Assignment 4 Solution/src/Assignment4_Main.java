import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;

public class Assignment4_Main {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		List<AdversaryObject> _zombies = new ArrayList<>();
		int damage = 25;
		
		ZombieBuilder builder = new ZombieBuilder();
		
		
		
		Scanner sc = new Scanner(System.in);
		String input;
		 
		while(true)
		{
			System.out.println("1. Create Zombies?");
			System.out.println("2. Demo game play.");

			System.out.println("Enter q to exit, or r to restart.");
			
			//q to quit
			try 
			{
				input = sc.next();
				//exit
				if (input.equals("q")) 
				{
					sc.close();
					return;				
				}

				//loop the creation 
				if (input.equals("1"))
				{
					System.out.println("-----------------------------");
					System.out.println("Enter creation (q to exit):");
					
					//create new zombies
					//in this solution, the "Client" and "Director" are merged in this Main class
					while (true)
					{
						System.out.println("Which kind?");
						System.out.println("1. (R)egular; 2. (C)one; 3. (B)ucket; 4. (S)creenDoor");
						
						input = sc.next();
						
						if(input.equals("q")) break;
						//pass in the builder (concrete builder); assume input correct. Default will create a regular zombie.
						//typically, if there's more than one builder, a type check should happen here
						directBuilder(builder, input);
						AdversaryObject z = builder.getResult();
						if(z != null)
						{
							_zombies.add(z);
						}
						printArray(_zombies);
						
					}
				}
				
				//demo loop
				else if (input.equals("2"))
				{
					if(_zombies.isEmpty()) 
					{
						System.out.println("No zombies created yet. Start over.");
						continue;
					}
					System.out.println("Please enter damage value. Default is 25.");
					input = sc.next();
					if (!input.equals(""))
						damage = Integer.parseInt(input);
					
					//loop through attacks of the zombies
					//you may automate it, or simulate it with clicks, or delay with timer
					//for simplicity purpose, I'm automating the process here
					int count = 0;
					while(!_zombies.isEmpty())
					{
						System.out.print("Round " + count + ": ");
						count ++;
						printArray(_zombies);

						_zombies.get(0).takeDamage(damage);
						//check if the zombie has died
						if(_zombies.get(0).die())
							_zombies.remove(0);						
					}
					printArray(_zombies);
				}
				
				else if (input.equals("p"))
				{
					//print the _zombies array
					printArray(_zombies);
				}
				
				else if (input.equals("r"))
				{
					//restart
					_zombies.clear();
				}				
			} 
			catch (Exception e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}		
	}
	
	public static void directBuilder(ZombieBuilder b, String t)
	{
		//since we use only one builder, the type check can be done here instead.
		switch (t)
		{
			//regular zombie
			case "1": 
			case "r":
			case "R":				
				break;
			//cone zombie
			case "2":
			case "c":
			case "C":
				b.makeCone();				
				break;
			//bucket zombie
			case "3":
			case "b":
			case "B":
				b.makeBucket();
				break;
			//Screen door zombie
			case "4":
			case "s":
			case "S":
				b.makeScreenDoor();
				break;
		}
		//always make the zombie part
		b.makeZombie();		
	}
	
	public static void printArray(List<AdversaryObject> l)
	{
		System.out.print("[");
		for(int i = 0; i < l.size(); i ++)
		{
			AdversaryObject z = l.get(i);
			System.out.print(z.getType() + "/" + z.getHealth() + ", ");
		}
		System.out.println("]");
	}

}

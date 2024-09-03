import java.util.List;
import java.util.ArrayList;
import java.util.Scanner;

public class Midterm2_Main {	

	List<AdversaryObject> _zombies = new ArrayList<>();
	
	//All three following objects may be instantiated through Singleton Pattern to guarantee their uniqueness, which I didn't.
	ZombieBuilder builder = new ZombieBuilder();	
	GameObjectManager object_manager = new GameObjectManager();	
	GameEventManager event_manager = new GameEventManager(object_manager);
	
	Scanner sc = new Scanner(System.in);
	String input;

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		
		Midterm2_Main game = new Midterm2_Main();
		game.run();
	}
	
	public void run()
	{
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
				if (input.equals("q")) return;				

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
					
					//creation is done, give the list to GameObjectManager
					object_manager.setEnemies(_zombies);
				}
				
				//demo loop
				else if (input.equals("2"))
				{
					if(object_manager.zombiesCleared()) 
					{
						System.out.println("No zombies created yet. Start over.");
						continue;
					}
					
					//loop through attacks of the zombies
					int count = 0;
					while(!object_manager.zombiesCleared())
					{
						System.out.print("Round " + count + ": ");
						count ++;
						printArray(_zombies);
						
						System.out.println("Select an attack: 1. Peashooter; 2. Watermelon; 3. Magnet-shroom");
						input = sc.next();
						
						//Use the GameEventManager as the control class to avoid putting everything in the main class
						event_manager.simulateCollisionDetection(input);				
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
	
	public void directBuilder(ZombieBuilder b, String t)
	{
		//since we use only one builder, the type check can be done here instead.
		
		//With Decorator, the "creation" part is a lot simpler. The flexibility is defined by you.
		//For instance, how many buckets you want a zombie to have. 		
		//Therefore, each type's creation defined here by creating the entire "zombie with accessory" one step at a time.		
		//for our purpose, a Regular Zombie will always be created, and then wrap with a Decorator as needed.
		
		//Finally, everything we are creating needs to keep a reference to their Observer:
		//the object_manager. Therefore, we need to pass this to the builder.
		b.makeZombie(object_manager);
		switch (t)
		{
			//regular zombie
			case "1": 
			case "r":
			case "R":	
				break;
			//cone zombie: 1 cone + 1 zombie -- if you want more, you should define it in another type "5"/"CC" or something similar.
			//in the builder, the Cone will be wrapped outside of what has been made earlier. 
			case "2":
			case "c":
			case "C":
				b.makeCone(object_manager);				
				break;
			//bucket zombie: same as above
			case "3":
			case "b":
			case "B":
				b.makeBucket(object_manager);
				break;
			//Screen door zombie: same as above
			case "4":
			case "s":
			case "S":
				b.makeScreenDoor(object_manager);
				break;
		}
	}
	
	public void printArray(List<AdversaryObject> l)
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

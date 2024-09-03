
public class GameEventManager {
	
	GameObjectManager object_manager;
	
	public GameEventManager(GameObjectManager o)
	{
		object_manager = o;
	}

	public void simulateCollisionDetection(String input) 
	{
		AdversaryObject nextEnemy = object_manager.getFirstEnemy();
		if(input.equals("1"))
		{
			//Peashooter
			System.out.println("Attack by Peashooter, damage 25.");
			doDamage(25, nextEnemy);
		}
		else if(input.equals("2"))
		{
			//Watermelon
			System.out.println("Attack by Watermelon, damage 50 from above.");
			doDamageFromAbove(50, nextEnemy);
		}
		else if(input.equals("3"))
		{
			//Magnet-shroom
			System.out.println("Attack by Magnet-shroom, metal object dies immediately.");
			applyMagnetForce(nextEnemy);
		}
		else
		{
			System.out.println("Wrong input. Please try again.");
		}
		
	}

	private void applyMagnetForce(AdversaryObject nextEnemy) {
		// TODO Auto-generated method stub

		//do the type check here, and call the die function immediately because it's metal
		//If implemented this way, the "removeMetalAccessory()" is not necessary. 
		//If you follow the template it should also work too, but the method would need to be defined in multiple classes.
		if(nextEnemy.getMetalStatus())
		{
			nextEnemy.die();
		}
	}

	private void doDamageFromAbove(int d, AdversaryObject e) {
		// TODO Auto-generated method stub
		e.takeDamageFromAbove(d);
		
	}

	private void doDamage(int d, AdversaryObject e) {
		// TODO Auto-generated method stub
		e.takeDamage(d);
	}

}

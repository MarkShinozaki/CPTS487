import java.lang.reflect.Constructor;

//The builder that creates the "Zombies" we need.
//Note here since all the Zombies are essentially instances of "ZombieWithAccessory"
//We can merge the abstract "Builder" and the "ConcreteBuilder" in the pattern together into one class
class ZombieBuilder {
	private AdversaryObject result = null; 
	
	public void makeCone(GameObjectManager o)
	{		
		result = new Cone(result);
		result.setObserver(o);
	}
	public void makeBucket(GameObjectManager o)
	{
		result = new Bucket(result);
		result.setObserver(o);
	}
	public void makeScreenDoor(GameObjectManager o)
	{
		result = new ScreenDoor(result);
		result.setObserver(o);
	}
	
	public void makeZombie(GameObjectManager o)
	{
		result = new Zombie();
		result.setObserver(o);
	}
	
	public AdversaryObject getResult()
	{
		return result;
	}
}

import java.lang.reflect.Constructor;

//The builder that creates the "Zombies" we need.
//Note here since all the Zombies are essentially instances of "ZombieWithAccessory"
//We can merge the abstract "Builder" and the "ConcreteBuilder" in the pattern together into one class
class ZombieBuilder {
	private AdversaryObject _accessory = null; 
	private AdversaryObject _zombie = null;
	
	public void makeCone()
	{
		_accessory = new Cone();		
	}
	public void makeBucket()
	{
		_accessory = new Bucket();		
	}
	public void makeScreenDoor()
	{
		_accessory = new ScreenDoor();		
	}
	
	public void makeZombie()
	{
		_zombie = new Zombie();		
	}
	
	public ZombieWithAccessory getResult()
	{
		ZombieWithAccessory result = new ZombieWithAccessory();
		
		if(_accessory != null)
			result.add(_accessory);
		result.add(_zombie);
		
		return result;
	}
}

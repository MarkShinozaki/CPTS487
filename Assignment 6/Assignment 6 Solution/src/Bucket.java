
public class Bucket extends Decorator {

	private int health = 100;
	private char type = 'B';
	private boolean isMetal = true;
	private GameObjectManager observer;
	
	public Bucket(AdversaryObject base)
	{
		super(base);
	}
	
	public int getHealth()
	{
		return health;
	}
	
	public char getType()
	{
		return type;
	}
	
	public boolean getMetalStatus()
	{
		return isMetal;
	}

	@Override
	public void setObserver(GameObjectManager o) {
		// TODO Auto-generated method stub
		observer = o;
	}
	
	@Override
	public void takeDamage(int d) {
		// TODO Auto-generated method stub
		int leftOver = d - health;
		health -= d;
		
		//if there's left over, that means the decorator is now dead
		if (leftOver > 0)
		{
			baseZombie.takeDamage(leftOver);
			this.die();
		}
	}
	
	@Override
	public void die()
	{
		observer.update();
	}
	
	@Override
	public void takeDamageFromAbove(int d)
	{
		takeDamage(d);
	}
	
	@Override
	public AdversaryObject getState()
	{
		return baseZombie;
	}
}


public class Zombie extends AdversaryObject {
	
	private int health = 50;
	private char type = 'Z';
	private boolean isMetal = false;
	private GameObjectManager observer;
	
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
		health -= d;
		
		if (health <= 0)
			die();
	}

	@Override
	public void takeDamageFromAbove(int d) {
		// TODO Auto-generated method stub
		takeDamage(d);
	}
	
	@Override
	public void die()
	{
		observer.update();
	}

	@Override
	public AdversaryObject getState() {
		// TODO Auto-generated method stub
		return null;
	}
}

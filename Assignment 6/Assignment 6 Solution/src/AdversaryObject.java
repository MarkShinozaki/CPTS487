// Component in the Decorator Pattern
// It is ALSO the Subject in the Observer Pattern
public abstract class AdversaryObject 
{
	private int health;
	private char type;
	private boolean isMetal;
	
	private GameObjectManager observer;
	public abstract void setObserver(GameObjectManager o);
	
	public abstract int getHealth();	
	public abstract char getType();
	public abstract boolean getMetalStatus();
	
	//left over damage is handled inside the function, not by return value any more
	public abstract void takeDamage(int d);
	public abstract void takeDamageFromAbove(int d);
	
	//this operation will serve as the "notify()" operation in the Observer Pattern,
	//calling the Observer's update() function, telling the Observer that it's time to get the new state of its subject(s)
	//Also, because we are only updating the first AdversaryObject in the list, we don't need to specify which subject is being updated. 
	//Otherwise, the notify() function should pass itself to the observer.
	public abstract void die();	
	public abstract AdversaryObject getState();
}

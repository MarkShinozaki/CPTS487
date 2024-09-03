import java.util.ArrayList;
import java.util.List;

//This is our Observer class in the Observer Pattern - both Abstract and Concrete
public class GameObjectManager {
	
	public List<AdversaryObject> enemies;
	
	public GameObjectManager()
	{
		enemies = new ArrayList<>();
	}
	
	public void setEnemies(List<AdversaryObject> l)
	{
		enemies = l;
	}
	
	public AdversaryObject getFirstEnemy()
	{
		return enemies.get(0);
	}
	
	public boolean zombiesCleared()
	{
		return enemies.isEmpty();
	}

	public void update() {
		// TODO Auto-generated method stub
		
		//this function is called when an AdversaryObject (the first one) in the List enemies dies.
		//Based on the pattern, the Observer should call "subject->getState()" to get the new state.
		//In this case, if it's a Decorator that dies, we are replacing it with its baseZombie;
		//If it's a zombie, then it dies 
		AdversaryObject newEnemy = getFirstEnemy().getState();
		
		if(newEnemy == null)
			enemies.remove(0);
		else
		{
			enemies.set(0, newEnemy);
		}
	}

}

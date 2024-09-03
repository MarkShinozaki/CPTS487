import java.util.ArrayList;
import java.util.List;

// Composite element
public class ZombieWithAccessory extends AdversaryObject 
{	
	//store the leaves that made up the Composite
	private List<AdversaryObject> _children = new ArrayList<>();
	
	//the health of the composite is all the others combined
	//at least in THIS case. Note that this class does not even have to define its own Health attribute.
	@Override
	public int getHealth() {		
		int h = 0;
		for (int i = 0; i < _children.size(); i ++)
			h += _children.get(i).getHealth();
		return h;
	}
	
	//the type of the composite is determined by the first child's type
	//so no need to check if it still has an accessory or not
	@Override
	public char getType() {
		return _children.get(0).getType();
	}

	@Override
	//takeDamage here carries an int return value for the leftover damages in a composite
	public int takeDamage(int d) {
		// TODO Auto-generated method stub
		int leftOver = d;
		
		//in the _children ArrayList, the accessory is placed in front of the Zombie, so it takes the damage first.
		//we then go over all the children 
		for(int i = 0; i < _children.size() && leftOver > 0; i ++)
		{
			leftOver = _children.get(i).takeDamage(leftOver);
			if (_children.get(i).die())
			{
				this.remove(i);
				i--; //adjust the index after removal
			}
		}			
		
		//return the leftOver damage to keep it consistent
		return leftOver;
	}

	@Override
	public boolean die() {
		// TODO Auto-generated method stub
		// In this case, the whole ZombieWithAccessory dies when the _children is empty
		// we return a boolean value to the main function to signal whether the zombie should be removed 
		return _children.isEmpty();
	}

	@Override
	public void add(AdversaryObject z) {
		// TODO Auto-generated method stub
		_children.add(z);
	}

	@Override
	public void remove(int index) {
		// TODO Auto-generated method stub
		_children.remove(index);
	}
}

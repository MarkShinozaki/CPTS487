//leaves elements
//leaf zombie
class Zombie extends AdversaryObject {
	
	private int health = 50;
	private char type = 'R';
	
	@Override
	//add and remove are place holders Zombie inherits from the AdversaryObject
	public void add(AdversaryObject z) {
		// TODO Auto-generated method stub

	}

	@Override
	public void remove(int index) {
		// TODO Auto-generated method stub

	}

	@Override
	public int takeDamage(int d) {
		// TODO Auto-generated method stub
		//return left over damage if needs to
		int leftOver = d - health;
		health -= d;
		return leftOver;
	}

	@Override
	public boolean die() {
		// TODO Auto-generated method stub
		return health <= 0;
	}

	@Override
	public int getHealth() {
		// TODO Auto-generated method stub
		return this.health;
	}

	@Override
	public char getType() {
		// TODO Auto-generated method stub
		return this.type;
	}
}

//The rest of the accessories: identical with Zombie as a leaf.
class Cone extends AdversaryObject {	
	private int health = 25;
	private char type = 'C';
	
	@Override
	public int getHealth() {
		// TODO Auto-generated method stub
		return this.health;
	}

	@Override
	public char getType() {
		// TODO Auto-generated method stub
		return this.type;
	}
	
	@Override
	public int takeDamage(int d) {
		// TODO Auto-generated method stub
		//return left over damage if needs to
		int leftOver = d - health;
		health -= d;
		return leftOver;
	}

	@Override
	public boolean die() {
		// TODO Auto-generated method stub
		return health <= 0;
	}

	@Override
	public void add(AdversaryObject z) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void remove(int index) {
		// TODO Auto-generated method stub
		
	}
}

//same with bucket and screendoor
class Bucket extends AdversaryObject {
	private int health = 100;
	private char type = 'B';
	
	@Override
	public int getHealth() {
		// TODO Auto-generated method stub
		return this.health;
	}

	@Override
	public char getType() {
		// TODO Auto-generated method stub
		return this.type;
	}
	
	@Override
	public int takeDamage(int d) {
		// TODO Auto-generated method stub
		//return left over damage if needs to
		int leftOver = d - health;
		health -= d;
		return leftOver;
	}

	@Override
	public boolean die() {
		// TODO Auto-generated method stub
		return health <= 0;
	}

	@Override
	public void add(AdversaryObject z) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void remove(int index) {
		// TODO Auto-generated method stub
		
	}
}

class ScreenDoor extends AdversaryObject {
	private int health = 25;
	private char type = 'S';
	
	@Override
	public int getHealth() {
		// TODO Auto-generated method stub
		return this.health;
	}

	@Override
	public char getType() {
		// TODO Auto-generated method stub
		return this.type;
	}
	
	@Override
	public int takeDamage(int d) {
		// TODO Auto-generated method stub
		//return left over damage if needs to
		int leftOver = d - health;
		health -= d;
		return leftOver;
	}

	@Override
	public boolean die() {
		// TODO Auto-generated method stub
		return health <= 0;
	}

	@Override
	public void add(AdversaryObject z) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void remove(int index) {
		// TODO Auto-generated method stub
		
	}
}
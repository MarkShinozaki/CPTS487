
public abstract class Decorator extends AdversaryObject {

	AdversaryObject baseZombie;
	
	public Decorator(AdversaryObject base)
	{
		this.baseZombie = base;
	}
}

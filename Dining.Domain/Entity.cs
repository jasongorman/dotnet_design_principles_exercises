namespace Dining.Domain;

public abstract class Entity
{

    private int id;

    public int Id
    {
        set { this.id = value; }
        get { return id; }
    }

}
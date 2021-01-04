public class DancerSpawner
{
    private readonly DancersFactory dancerFactory;

    public DancerSpawner(DancersFactory dancerFactory)
    {
        this.dancerFactory = dancerFactory;
    }

    // Logic

    public MovimientoDeDancer SpawnDancer()
    {
        return dancerFactory.Create();
    }
}
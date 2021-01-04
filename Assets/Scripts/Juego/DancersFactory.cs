using UnityEngine;

public class DancersFactory
{
    private readonly DancersSO dancerConfiguration;

    public DancersFactory(DancersSO dancerConfiguration)
    {
        this.dancerConfiguration = dancerConfiguration;
    }

    public MovimientoDeDancer Create()
    {
        var prefab = dancerConfiguration.GetPowerUpPrefabById();

        return Object.Instantiate(prefab);
    }
}

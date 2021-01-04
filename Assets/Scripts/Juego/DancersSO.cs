using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Custom/DancerConfig")]
public class DancersSO : ScriptableObject
{
    [SerializeField] private MovimientoDeDancer[] dancers;
    private Dictionary<string, MovimientoDeDancer> idToDancer;

    private void Awake()
    {
        idToDancer = new Dictionary<string, MovimientoDeDancer>(dancers.Length);
        foreach (var powerUp in dancers)
        {
            idToDancer.Add(powerUp.Id, powerUp);
        }
    }

    public MovimientoDeDancer GetPowerUpPrefabById()
    {
        var id = dancers[RandomLocal(0, dancers.Length)].Id;
        if (!idToDancer.TryGetValue(id, out var powerUp))
        {
            throw new Exception($"PowerUp with id {id} does not exit");
        }
        return powerUp;
    }

    private int RandomLocal(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }
}

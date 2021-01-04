using System.Collections.Generic;
using UnityEngine;

public abstract class MovimientoDeDancer : MonoBehaviour, IMovimientoDeDancerMono
{
    private LogicaDeDancer logica;
    [SerializeField] private string id;
    [SerializeField] private List<Sprite> left, right, actual;
    [SerializeField] private Sprite center;
    [SerializeField] private SpriteRenderer render;
    [SerializeField] private int delayEnMilisegundos;

    public string Id { get => id; set => id = value; }

    private void Awake()
    {
        logica = new LogicaDeDancer(this, delayEnMilisegundos, left, right, center, actual, render);
    }

    public void CambioDeLado() => logica.CambioDeLado();
}
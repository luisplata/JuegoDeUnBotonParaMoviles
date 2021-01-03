using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class LogicaDeDancer
{
    private IMovimientoDeDancerMono movimientoDeDancerMono;
    private List<Sprite> left;
    private List<Sprite> right;
    private Sprite center;
    private List<Sprite> actual;
    private SpriteRenderer render;
    private int index;
    private bool izquierda;
    private int delayEnMilisegundos;

    public LogicaDeDancer(IMovimientoDeDancerMono movimientoDeDancerMono, int delayEnMilisegundos, List<Sprite> left, List<Sprite> right, Sprite center, List<Sprite> actual, SpriteRenderer render)
    {
        this.movimientoDeDancerMono = movimientoDeDancerMono;
        this.left = left;
        this.right = right;
        this.center = center;
        this.actual = actual;
        this.render = render;
        this.delayEnMilisegundos = delayEnMilisegundos;

        render.sprite = center;
    }

    public async Task PonerAnimaciones()
    {
        for(var index = 0; index < actual.Count; index++)
        {
            render.sprite = actual[index];
            await Task.Delay(TimeSpan.FromMilliseconds(delayEnMilisegundos));
        }
        render.sprite = center;
    }

    public void CambioDeLado()
    {
        if (izquierda)
        {
            actual = left;
        }
        else
        {
            actual = right;
        }
        index = 0;
        izquierda = !izquierda;
        PonerAnimaciones().WrapErrors();
    }
}
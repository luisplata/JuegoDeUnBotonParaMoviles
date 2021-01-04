using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculoDeArea : MonoBehaviour, ICalculoDeArea
{
    [SerializeField] private GameObject a, b, c, d;

    public Vector2 CalcularPosicionDentroDelCuadrado()
    {
        var x = CalcularX();
        var y = CalcularY();
        return new Vector2(x, y);
    }

    private float CalcularY()
    {
        var y = UnityEngine.Random.Range(c.transform.position.y, a.transform.position.y);
        return y;
    }

    private float CalcularX()
    {
        var x = UnityEngine.Random.Range(a.transform.position.x, b.transform.position.x);
        return x;
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawLine()
        Gizmos.DrawLine(a.transform.position, b.transform.position);
        Gizmos.DrawLine(a.transform.position, c.transform.position);
        Gizmos.DrawLine(c.transform.position, d.transform.position);
        Gizmos.DrawLine(d.transform.position, b.transform.position);
    }
}

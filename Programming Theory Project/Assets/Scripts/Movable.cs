using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movable : MonoBehaviour
{

    protected float xBoundary = 40f;
    protected float zBoundary = 18f;
    
    protected virtual void CheckBoundaries()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -xBoundary, xBoundary);
        pos.z = Mathf.Clamp(pos.z, -zBoundary, zBoundary);
        transform.position = pos;
    }
}

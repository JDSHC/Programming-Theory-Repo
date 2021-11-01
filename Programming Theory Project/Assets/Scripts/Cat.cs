using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Cat : MonoBehaviour
{
    protected float BaseSpeed;
    protected float CurrentSpeed;
    public int Weight { get; protected set; }

    // Update is called once per frame
    private void Update()
    {
        
    }

    protected abstract void Run();
}

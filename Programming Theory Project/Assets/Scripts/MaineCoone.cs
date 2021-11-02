using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class MaineCoone : Cat
{

    
    private void Start()
    {
        BaseSpeed = 1.5f;
        CurrentSpeed = BaseSpeed;
        Weight = 30;
        RunSpeedFactor = 1.1f;
    }
}

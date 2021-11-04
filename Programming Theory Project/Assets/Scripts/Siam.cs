using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Inheritance
public class Siam : Cat
{

    private void Start()
    {
        BaseSpeed = 10.0f;
        CurrentSpeed = BaseSpeed;
        Weight = 10;
        RunSpeedFactor = 2f;
    }
    
}

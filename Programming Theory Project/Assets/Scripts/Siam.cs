using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Siam : Cat
{

    private void Start()
    {
        BaseSpeed = 4.0f;
        Weight = 10;
    }

    protected override void Run()
    {
        CurrentSpeed = BaseSpeed * 2f;
    }
}

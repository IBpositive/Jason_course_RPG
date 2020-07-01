// 6a example

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resettable : MonoBehaviour
{
    protected bool _canWork;

    // Abstracts can't have any implimentations in the method.
    public abstract void DoWork();

    public void Reset()
    {
        _canWork = true;
    }

    public class MyThing : Resettable
    {
        public override void DoWork()
        {
            bool didWork = true; // calculated by something else maybe

            if (didWork)
            {
                _canWork = false;
            }
        }
    }
}
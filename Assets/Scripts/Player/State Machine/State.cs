using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public void Enter()
    {
        enabled = true;
        Setup();
    }

    public void Exit()
    {
        enabled = false;
    }

    protected abstract void Setup();
}

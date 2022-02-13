using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    private bool _locked = false;
    public bool Locked => _locked;
    public void Lock()
    {
        _locked = true;
    }

    public void Unlock()
    {
        _locked = false;
    }

    public abstract TurnInfo GetTurn();

    public virtual void Reset()
    {
        
    }
}

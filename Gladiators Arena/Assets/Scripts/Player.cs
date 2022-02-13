using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private Character _character;
    public Character Character => _character;

    [SerializeField] 
    private TurnInfo _turnInfo;
    public TurnInfo TurnInfo => _turnInfo;
    
    [SerializeField] 
    private PlayerController _controller;
    public PlayerController Controller => _controller;

    public void ApplyTurn()
    {
        _turnInfo = Controller.GetTurn();
    }
}

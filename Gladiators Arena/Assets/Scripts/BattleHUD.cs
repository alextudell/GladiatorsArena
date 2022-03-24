using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private ButtonAttackWrapper _attackHead;
    [SerializeField] private ButtonAttackWrapper _attackBody;
    [SerializeField] private ButtonAttackWrapper _attackLegs;
    [SerializeField] private ButtonDefenceWrapper _defendHead;
    [SerializeField] private ButtonDefenceWrapper _defendBody;
    [SerializeField] private ButtonDefenceWrapper _defendLegs;

    [SerializeField] private HumanPlayerController _humanPlayerController;
    
    [SerializeField] private Text _player01CharacterHealth;
    [SerializeField] private Text _player02CharacterHealth;

    [SerializeField] private bool _selectedAttackButton = true;
    [SerializeField] private bool _forceAttackButton = true;

    [SerializeField] private bool _selectedDefenceButton = true;
    [SerializeField] private bool _forceDefenceButton = true;

    [SerializeField] private bool _bodyPartNone = false;


    private void Start()
    {
        _attackHead.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Head));
        _attackBody.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Body));
        _attackLegs.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Leg));
        
        _defendHead.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Head));
        _defendBody.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Body));
        _defendLegs.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Leg));
        
        _humanPlayerController.OnAttackBodyPartChanged += UpdateAttackButtonsState;
        _humanPlayerController.OnDefenceBodyPartChanged += UpdateDefenceButtonsState;
    }

    private void Update()
    {
        _player01CharacterHealth.text = GameLogic.Instance.player01.Murmillon.Health.ToString();
        _player02CharacterHealth.text = GameLogic.Instance.player02.Murmillon.Health.ToString();
    }

    private void UpdateAttackButtonsState()
    {
        _attackHead.interactable = (_humanPlayerController.Attack == BodyPart.Head || _humanPlayerController.Attack == BodyPart.None) && !_humanPlayerController.ForceDefence;
        _attackBody.interactable = (_humanPlayerController.Attack == BodyPart.Body || _humanPlayerController.Attack == BodyPart.None) && !_humanPlayerController.ForceDefence;
        _attackLegs.interactable = (_humanPlayerController.Attack == BodyPart.Leg || _humanPlayerController.Attack == BodyPart.None) && !_humanPlayerController.ForceDefence;

        if (_humanPlayerController.Attack == BodyPart.Head && !_humanPlayerController.ForceAttack)
        {
            _attackHead.SetAttackButtonState(_selectedAttackButton, !_forceAttackButton, _attackHead.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Head && _humanPlayerController.ForceAttack)
        {
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Body && !_humanPlayerController.ForceAttack)
        {
            _attackBody.SetAttackButtonState(_selectedAttackButton, !_forceAttackButton, _attackBody.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Body && _humanPlayerController.ForceAttack)
        {
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Leg && !_humanPlayerController.ForceAttack)
        {
            _attackLegs.SetAttackButtonState(_selectedAttackButton, !_forceAttackButton, _attackLegs.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            _attackBody.SetAttackButtonState( _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Leg && _humanPlayerController.ForceAttack)
        {
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, !_defendLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.None)
        {
            _attackHead.SetAttackButtonState(_bodyPartNone, _forceAttackButton, _attackHead.interactable);
            _attackBody.SetAttackButtonState(_bodyPartNone, _forceAttackButton, _attackBody.interactable);
            _attackLegs.SetAttackButtonState(_bodyPartNone, _forceAttackButton, _attackLegs.interactable);
        }
    }

    private void UpdateDefenceButtonsState()
    {
        _defendHead.interactable = (_humanPlayerController.Defence == BodyPart.Head || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendBody.interactable = (_humanPlayerController.Defence == BodyPart.Body || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendLegs.interactable = (_humanPlayerController.Defence == BodyPart.Leg || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;

        if (_humanPlayerController.Defence == BodyPart.Head && !_humanPlayerController.ForceDefence)
        {
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, !_forceDefenceButton, _defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Head && _humanPlayerController.ForceDefence)
        {
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackBody.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackHead.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Body && !_humanPlayerController.ForceDefence)
        {
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, !_forceDefenceButton, _defendBody.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Body && _humanPlayerController.ForceDefence)
        {
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackBody.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackHead.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Leg && !_humanPlayerController.ForceDefence)
        {
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, !_forceDefenceButton, _defendLegs.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Leg && _humanPlayerController.ForceDefence)
        {
            _defendLegs.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
            _defendHead.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            _defendBody.SetDefenceButtonState(_selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            _attackBody.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackBody.interactable);
            _attackHead.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackHead.interactable);
            _attackLegs.SetAttackButtonState(_selectedAttackButton, _forceAttackButton, !_attackLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.None)
        {
            _defendHead.SetDefenceButtonState(_bodyPartNone, _forceDefenceButton, _defendHead.interactable);
            _defendBody.SetDefenceButtonState(_bodyPartNone, _forceDefenceButton, _defendBody.interactable);
            _defendLegs.SetDefenceButtonState(_bodyPartNone, _forceDefenceButton, _defendLegs.interactable);
        }
    }
}

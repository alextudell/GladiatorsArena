using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    [SerializeField] private Button _attackHead;
    [SerializeField] private Button _attackBody;
    [SerializeField] private Button _attackLegs;
    [SerializeField] private Button _defendHead;
    [SerializeField] private Button _defendBody;
    [SerializeField] private Button _defendLegs;

    [SerializeField] private HumanPlayerController _humanPlayerController;
    
    [SerializeField] private Text _player01CharacterHealth;
    [SerializeField] private Text _player02CharacterHealth;

    public Sprite interactableAttack;
    public Sprite selectedAttack;
    public Sprite forceAttack;
    public Sprite uninteractableAttack;

    public Sprite interactableDefence;
    public Sprite selectedDefence;
    public Sprite forceDefence;
    public Sprite uninteractableDefence;



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
            SetAttackButtonState(_attackHead, _selectedAttackButton, !_forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackBody, _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            SetAttackButtonState(_attackLegs, _selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Head && _humanPlayerController.ForceAttack)
        {
            SetAttackButtonState(_attackHead, _selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackBody, _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            SetAttackButtonState(_attackLegs, _selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Body && !_humanPlayerController.ForceAttack)
        {
            SetAttackButtonState(_attackBody, _selectedAttackButton, !_forceAttackButton, _attackBody.interactable);
            SetAttackButtonState(_attackHead, _selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackLegs, _selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Body && _humanPlayerController.ForceAttack)
        {
            SetAttackButtonState(_attackBody, _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
            SetAttackButtonState(_attackHead, _selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackLegs, _selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Leg && !_humanPlayerController.ForceAttack)
        {
            SetAttackButtonState(_attackLegs, _selectedAttackButton, !_forceAttackButton, _attackLegs.interactable);
            SetAttackButtonState(_attackHead, _selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackBody, _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.Leg && _humanPlayerController.ForceAttack)
        {
            SetAttackButtonState(_attackLegs, _selectedAttackButton, _forceAttackButton, _attackLegs.interactable);
            SetAttackButtonState(_attackHead, _selectedAttackButton, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackBody, _selectedAttackButton, _forceAttackButton, _attackBody.interactable);
        }
        else if (_humanPlayerController.Attack == BodyPart.None)
        {
            SetAttackButtonState(_attackHead, _bodyPartNone, _forceAttackButton, _attackHead.interactable);
            SetAttackButtonState(_attackBody, _bodyPartNone, _forceAttackButton, _attackBody.interactable);
            SetAttackButtonState(_attackLegs, _bodyPartNone, _forceAttackButton, _attackLegs.interactable);
        }
    }

    private void UpdateDefenceButtonsState()
    {
        _defendHead.interactable = (_humanPlayerController.Defence == BodyPart.Head || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendBody.interactable = (_humanPlayerController.Defence == BodyPart.Body || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendLegs.interactable = (_humanPlayerController.Defence == BodyPart.Leg || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;

        if (_humanPlayerController.Defence == BodyPart.Head && !_humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, !_forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Head && _humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Body && !_humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, !_forceDefenceButton, _defendBody.interactable);
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Body && _humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Leg && !_humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, !_forceDefenceButton, _defendLegs.interactable);
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.Leg && _humanPlayerController.ForceDefence)
        {
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _defendLegs.interactable);
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _defendBody.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.None)
        {
            SetDefenceButtonState(_defendHead, _bodyPartNone, _forceDefenceButton, _defendHead.interactable);
            SetDefenceButtonState(_defendBody, _bodyPartNone, _forceDefenceButton, _defendBody.interactable);
            SetDefenceButtonState(_defendLegs, _bodyPartNone, _forceDefenceButton, _defendLegs.interactable);
        }
        else if (_humanPlayerController.Defence == BodyPart.None && _humanPlayerController.ForceAttack)
        {
            SetDefenceButtonState(_defendHead, _selectedDefenceButton, _forceDefenceButton, _bodyPartNone);
            SetDefenceButtonState(_defendBody, _selectedDefenceButton, _forceDefenceButton, _bodyPartNone);
            SetDefenceButtonState(_defendLegs, _selectedDefenceButton, _forceDefenceButton, _bodyPartNone);
        }

    }

    private void SetAttackButtonState(Button button, bool selected, bool force, bool interactable)
    {
        if(!interactable)
        {
            button.image.sprite = uninteractableAttack;
            button.interactable = false;
        }
        else if(!selected)
        {
            button.image.sprite = interactableAttack;
            button.interactable = true;
        }
        else if(selected && !force)
        {
            button.image.sprite = selectedAttack;
            button.interactable = true;
        }
        else if(selected && force)
        {
            button.image.sprite = forceAttack;
            button.interactable = true;
        }
    }

    private void SetDefenceButtonState(Button button, bool selected, bool force, bool interactable)
    {
        if (!interactable)
        {
            button.image.sprite = uninteractableDefence;
            button.interactable = false;
        }
        else if (!selected)
        {
            button.image.sprite = interactableDefence;
            button.interactable = true;
        }
        else if (selected && !force)
        {
            button.image.sprite = selectedDefence;
            button.interactable = true;
        }
        else if (selected && force)
        {
            button.image.sprite = forceDefence;
            button.interactable = true;
        }
    }
}

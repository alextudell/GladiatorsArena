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

    [SerializeField] private bool _selectedButton = true;
    [SerializeField] private bool _forceButton = true;
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

        if(_humanPlayerController.Attack == BodyPart.Head && !_humanPlayerController.ForceAttack)
        {
            SetButtonState(_attackHead, _selectedButton, !_forceButton, _attackHead.interactable);
            SetButtonState(_attackBody, _selectedButton, _forceButton, _attackBody.interactable);
            SetButtonState(_attackLegs, _selectedButton, _forceButton, _attackLegs.interactable);
        }
        else if(_humanPlayerController.Attack == BodyPart.Head && _humanPlayerController.ForceAttack)
        {
            SetButtonState(_attackHead, _selectedButton, _forceButton, _attackHead.interactable);
            SetButtonState(_attackBody, _selectedButton, _forceButton, _attackBody.interactable);
            SetButtonState(_attackLegs, _selectedButton, _forceButton, _attackLegs.interactable);
        }
        else if(_humanPlayerController.Attack == BodyPart.None)
        {
            SetButtonState(_attackHead, _bodyPartNone, _forceButton, _attackHead.interactable);
            SetButtonState(_attackBody, _bodyPartNone, _forceButton, _attackBody.interactable);
            SetButtonState(_attackLegs, _bodyPartNone, _forceButton, _attackLegs.interactable);
        }
    }

    private void UpdateDefenceButtonsState()
    {
        _defendHead.interactable = (_humanPlayerController.Defence == BodyPart.Head || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendBody.interactable = (_humanPlayerController.Defence == BodyPart.Body || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
        _defendLegs.interactable = (_humanPlayerController.Defence == BodyPart.Leg || _humanPlayerController.Defence == BodyPart.None) && !_humanPlayerController.ForceAttack;
    }

    private void SetButtonState(Button button, bool selected, bool force, bool interactable)
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
}

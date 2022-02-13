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

    private void Start()
    {
        _attackHead.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Head));
        _attackBody.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Body));
        _attackLegs.onClick.AddListener(() => _humanPlayerController.SetAttackBodyPart(BodyPart.Leg));
        
        _defendHead.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Head));
        _defendBody.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Body));
        _defendLegs.onClick.AddListener(() => _humanPlayerController.SetDefenceBodyPart(BodyPart.Leg));
        
        _humanPlayerController.OnBodyPartChanged += UpdateButtonsState;
    }

    private void Update()
    {
        _player01CharacterHealth.text = GameLogic.Instance.player01.Character.Health.ToString();
        _player02CharacterHealth.text = GameLogic.Instance.player02.Character.Health.ToString();
    }

    private void UpdateButtonsState()
    {
        _attackHead.interactable = _humanPlayerController.Attack != BodyPart.Head;
        _attackBody.interactable = _humanPlayerController.Attack != BodyPart.Body;
        _attackLegs.interactable = _humanPlayerController.Attack != BodyPart.Leg;
        
        _defendHead.interactable = _humanPlayerController.Defence != BodyPart.Head;
        _defendBody.interactable = _humanPlayerController.Defence != BodyPart.Body;
        _defendLegs.interactable = _humanPlayerController.Defence != BodyPart.Leg;
    }
}

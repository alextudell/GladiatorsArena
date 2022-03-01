using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ButtonAttackWrapper))]

public class ButtonAttackWrapperEditor : ButtonEditor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var buttonAttack = target as ButtonAttackWrapper;
        buttonAttack.forceAttack = (Sprite)EditorGUILayout.ObjectField("ForcedAttack", buttonAttack.forceAttack, typeof(Sprite));
        buttonAttack.interactableAttack = (Sprite)EditorGUILayout.ObjectField("InterectableAttack", buttonAttack.interactableAttack, typeof(Sprite));
        buttonAttack.selectedAttack = (Sprite)EditorGUILayout.ObjectField("SelectAttack", buttonAttack.selectedAttack, typeof(Sprite));
        buttonAttack.uninteractableAttack = (Sprite)EditorGUILayout.ObjectField("UninterectableAttack", buttonAttack.uninteractableAttack, typeof(Sprite));
    }

}

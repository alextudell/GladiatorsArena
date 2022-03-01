using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UI;

[CustomEditor(typeof(ButtonDefenceWrapper))]

public class ButtonDefenceWrapperEditor : ButtonEditor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var buttonDefend = target as ButtonDefenceWrapper;
        buttonDefend.forceDefence = (Sprite)EditorGUILayout.ObjectField("ForcedDefend", buttonDefend.forceDefence, typeof(Sprite));
        buttonDefend.interactableDefence = (Sprite)EditorGUILayout.ObjectField("InterectableDefend", buttonDefend.interactableDefence, typeof(Sprite));
        buttonDefend.selectedDefence = (Sprite)EditorGUILayout.ObjectField("SelectDefend", buttonDefend.selectedDefence, typeof(Sprite));
        buttonDefend.uninteractableDefence = (Sprite)EditorGUILayout.ObjectField("UninterectableDefend", buttonDefend.uninteractableDefence, typeof(Sprite));
    }

}

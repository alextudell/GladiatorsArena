using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAttackWrapper : Button

{
    public Sprite interactableAttack;
    public Sprite selectedAttack;
    public Sprite forceAttack;
    public Sprite uninteractableAttack;


    public void SetAttackButtonState(bool selected, bool force, bool interactable)
    {
        if (!interactable)
        {
            this.image.sprite = uninteractableAttack;
            this.interactable = false;
        }
        else if (!selected)
        {
            this.image.sprite = interactableAttack;
            this.interactable = true;
        }
        else if (selected && !force)
        {
            this.image.sprite = selectedAttack;
            this.interactable = true;
        }
        else if (selected && force)
        {
            this.image.sprite = forceAttack;
            this.interactable = true;
        }
    }


}

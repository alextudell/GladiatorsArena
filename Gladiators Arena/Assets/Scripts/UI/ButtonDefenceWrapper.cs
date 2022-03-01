using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDefenceWrapper : Button
{
    public Sprite interactableDefence;
    public Sprite selectedDefence;
    public Sprite forceDefence;
    public Sprite uninteractableDefence;

    public void SetDefenceButtonState(bool selected, bool force, bool interactable)
    {
        if (!interactable)
        {
            this.image.sprite = uninteractableDefence;
            this.interactable = false;
        }
        else if (!selected)
        {
            this.image.sprite = interactableDefence;
            this.interactable = true;
        }
        else if (selected && !force)
        {
            this.image.sprite = selectedDefence;
            this.interactable = true;
        }
        else if (selected && force)
        {
            this.image.sprite = forceDefence;
            this.interactable = true;
        }
    }
}

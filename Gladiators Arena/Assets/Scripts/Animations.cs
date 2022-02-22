using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    public Animator animator;

    public void GotInHead()
    {   
            animator.SetBool("GotInHead", true);
    }
}

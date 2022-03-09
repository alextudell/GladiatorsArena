using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    public void GotInBodyPart (BodyPart bodypart)
    {
        switch (bodypart)
        {
            case BodyPart.Head:
                _animator.SetTrigger("GotInHead");
                break;

            case BodyPart.Body:
                _animator.SetTrigger("GotInBody");
                break;

            case BodyPart.Leg:
                _animator.SetTrigger("GotInLegs");
                break;
        }
    }

    public void HitInBodyPart(BodyPart bodypart)
    {
        switch (bodypart)
        {
            case BodyPart.Head:
                _animator.SetTrigger("HitInHead");
                break;

            case BodyPart.Body:
                _animator.SetTrigger("HitInBody");
                break;

            case BodyPart.Leg:
                _animator.SetTrigger("HitInLegs");
                break;
        }
    }
}

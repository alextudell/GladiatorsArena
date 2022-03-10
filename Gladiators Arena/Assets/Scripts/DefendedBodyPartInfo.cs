using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendedBodyPartInfo : MonoBehaviour
{
    private BodyPart _bodyPart;
    public BodyPart BodyPart => _bodyPart;

    public DefendedBodyPartInfo(int damageValue, BodyPart bodyPart)
    {
        _bodyPart = bodyPart;
    }
}

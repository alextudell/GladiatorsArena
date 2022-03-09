using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageInfo
{

    private int _damageValue;
    public int DamageValue => _damageValue;

    private BodyPart _bodyPart;
    public BodyPart BodyPart => _bodyPart;

    public DamageInfo (int damageValue, BodyPart bodyPart)
    {
        _damageValue = damageValue;
        _bodyPart = bodyPart;
    }

}

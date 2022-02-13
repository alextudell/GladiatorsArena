using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnInfo
{
    public BodyPart attackBodyPart = BodyPart.None;
    public BodyPart defenceBodyPart = BodyPart.None;
}

public enum BodyPart
{
    Head = 1,
    Body = 2,
    Leg = 3,
    None = 99
}


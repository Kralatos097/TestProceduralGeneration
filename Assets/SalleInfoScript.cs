using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalleInfoScript : MonoBehaviour
{
    public SalleType SalleType;
    public Quaternion Rotation;

    public SalleInfoScript()
    {
        Rotation = Quaternion.Euler(0,0, transform.rotation.z);
    }
}

public enum SalleType
{
    Salle22,
    Salle11,
    Salle44,
    Couloir14,
    Couloir24,
    Default,
}
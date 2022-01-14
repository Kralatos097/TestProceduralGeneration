using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalleInfoScript : MonoBehaviour
{
    public SalleType SalleType;
    [Range(0,4)]
    public int nbPortes;
    [HideInInspector]
    public List<Transform> PortesPos = new List<Transform>();

    public bool Corner = false;

    /*[Header("Orientation porte")]
    public bool PorteOuest;
    public bool PorteEst;
    public bool PorteNord;
    public bool PorteSud;*/

    private void Start()
    {
        nbPortes = 0;
        foreach (Transform child in transform)
        {
            if(child.CompareTag("Porte"))
            {
                nbPortes++;
                PortesPos.Add(child);
            }
        }
    }
}

public enum SalleType
{
    Salle22,
    Salle11,
    Salle44,
    Couloir14,
    Couloir18,
    Default,
}
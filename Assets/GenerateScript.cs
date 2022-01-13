using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GenerateScript : MonoBehaviour
{
    public Transform SallePos;
    public List<GameObject> Salle22Prefabs;
    
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform pos in SallePos)
        {
            SalleInfoScript sInfo = pos.GetComponent<SalleInfoScript>();
            int rand = 0;
            GameObject gOPrefab = null;
            switch (sInfo.SalleType)
            {
                case SalleType.Salle22:
                    rand = Random.Range(0, Salle22Prefabs.Count);
                    gOPrefab = Salle22Prefabs[rand];
                    break;
                case SalleType.Salle11:
                    break;
                case SalleType.Salle44:
                    break;
                case SalleType.Couloir14:
                    break;
                case SalleType.Couloir24:
                    break;
                case SalleType.Default:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            Instantiate(gOPrefab, pos.position, sInfo.Rotation,SallePos);
            Destroy(pos.gameObject);
        }
    }
}

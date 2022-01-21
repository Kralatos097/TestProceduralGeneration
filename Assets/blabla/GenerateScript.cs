using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class GenerateScript : MonoBehaviour
{
    public Transform SallePos;

    public List<GameObject> SallesPrefabs;
    public List<GameObject> InterieursPrefab;
    //public GameObject PortePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform pos in SallePos)
        {
            SalleInfoScript sInfo = pos.GetComponent<SalleInfoScript>();
            int rand = 0;
            GameObject gOPrefab = null;
            List<GameObject> PrefabList = new List<GameObject>();

            foreach (GameObject prefab in SallesPrefabs)
            {
                SalleInfoScript pInfo = prefab.GetComponent<SalleInfoScript>();

                if (pInfo.SalleType == sInfo.SalleType
                    && sInfo.nbPortes == pInfo.nbPortes
                    && sInfo.Corner == pInfo.Corner)
                {
                    PrefabList.Add(prefab);
                }
            }
            
            if(PrefabList.Count != 0)
            {
                rand = Random.Range(0, PrefabList.Count);
                gOPrefab = PrefabList[rand];
            }

            if (gOPrefab != null)
            {
                GameObject salleInstantiate = Instantiate(gOPrefab, pos.position, pos.rotation);

                List<GameObject> intPrefab = new List<GameObject>();
                foreach (GameObject prefab in InterieursPrefab)
                {
                    SalleType pType = prefab.GetComponent<SalleInfoScript>().SalleType;
                    if (pType == sInfo.SalleType)
                    {
                        intPrefab.Add(prefab);
                    }
                }
                
                if(intPrefab.Count != 0)
                {
                    rand = Random.Range(0, intPrefab.Count);

                    int randRot = Random.Range(0, 5);
                    Vector3 intRot = Vector3.zero;
                    bool pass = true;
                    switch (randRot)
                    {
                        case 0 :
                            break;
                        case 1 :
                            intRot = new Vector3(0, 90, 0);
                            break;
                        case 2 :
                            intRot = new Vector3(0, 180, 0);
                            break;
                        case 3 :
                            intRot = new Vector3(0, -90, 0);
                            break;
                        case 4 :
                            pass = false;
                            break;
                    }
                    
                    if(pass)
                        Instantiate(intPrefab[rand], pos.position,
                            Quaternion.Euler(intRot), salleInstantiate.transform);
                }
            }
            Destroy(pos.gameObject);
        }
    }
}

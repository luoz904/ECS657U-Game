using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager instance;

    private GameObject mageToBuild;


    public GameObject standardMagePrefab;
    public GameObject anotherMagePrefab;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public GameObject GetMageToBuild()
    {
        return mageToBuild;
    }

    public void SetMageToBuild(MageBlueprint mage) {
        mageToBuild = mage.prefab;
    }

}

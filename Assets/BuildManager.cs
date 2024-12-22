using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    private GameObject mageToBuild;

    public GameObject standardMagePrefab;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }


    public GameObject GetMageToBuild()
    {
        return mageToBuild;
    }

    // Start is called before the first frame update
    void Start()
    {
        mageToBuild = standardMagePrefab;
    }
}

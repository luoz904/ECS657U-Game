using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public MageBlueprint standardMage;

    public MageBlueprint anotherMage;

    private BuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;    
    }

    public void BuyStandardMage() {
        Debug.Log("Buy mage!");
        buildManager.SetMageToBuild(standardMage);
    }

    public void BuyAnotherMage() {
        Debug.Log("Buy another mage!");
        buildManager.SetMageToBuild(anotherMage);
    }
}

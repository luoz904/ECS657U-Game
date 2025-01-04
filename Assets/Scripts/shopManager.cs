using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public MageBlueprint standardMage;

    public MageBlueprint anotherMage;

    public MageBlueprint superMage;

    private NodeBuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = NodeBuildManager.instance;    
    }

    public void BuyStandardMage() {
        Debug.Log("Buy mage!");
        buildManager.SetMageToBuild(standardMage);
    }

    public void BuyAnotherMage() {
        Debug.Log("Buy another mage!");
        buildManager.SetMageToBuild(anotherMage);
    }

    public void BuySuperMage() {
        Debug.Log("Buy super mage!");
        buildManager.SetMageToBuild(superMage);
    }
}

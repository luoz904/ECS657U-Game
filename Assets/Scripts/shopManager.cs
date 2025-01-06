using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shopManager : MonoBehaviour
{
    public MageBlueprint defaultMage;
    public MageBlueprint greenMage;

    public MageBlueprint redMage;

    public MageBlueprint blueMage;

    public MageBlueprint purpleMage;

    private NodeBuildManager buildManager;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = NodeBuildManager.instance;
    }

    public void BuyBaseMage()
    {
        Debug.Log("Buy mage!");
        buildManager.SetMageToBuild(defaultMage);
    }

    public void BuyRedMage()
    {
        Debug.Log("Buy super mage!");
        buildManager.SetMageToBuild(redMage);
    }

    public void BuyBlueMage()
    {
        Debug.Log("Buy another mage!");
        buildManager.SetMageToBuild(blueMage);
    }

    public void BuyGreenMage()
    {
        Debug.Log("Buy super mage!");
        buildManager.SetMageToBuild(greenMage);
    }

    public void BuyPurpleMage()
    {
        Debug.Log("Buy super mage!");
        buildManager.SetMageToBuild(purpleMage);
    }

    public void BuyLastMage() {
        
    }

}

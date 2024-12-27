using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    
    public static BuildManager instance;

    private MageBlueprint mageToBuild;

    public bool hasMageToBuild { get { return mageToBuild != null; }}

    public bool hasMoneyToBuild { get { return PlayerStats.Money >= mageToBuild.cost; }}

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetMageToBuild(MageBlueprint mage) {
        mageToBuild = mage;
    }

    public bool buildMageOn(NodeControl node) {

        if (!hasMoneyToBuild) {
            Debug.Log("Not enough money!");
            return false;
        }

        PlayerStats.Money -= mageToBuild.cost;

        GameObject mage = Instantiate(mageToBuild.prefab, node.transform.position, node.transform.rotation);
        if (mage != null) {
            Debug.Log("Money build, money left " + PlayerStats.Money);
        }
        return mage != null;
    }

}

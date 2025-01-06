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

    public MageBlueprint lastMage;

    private NodeBuildManager buildManager;

    public static MageBlueprint selectedMage;

    // Start is called before the first frame update
    void Start()
    {
        buildManager = NodeBuildManager.instance;
        selectedMage = defaultMage;
    }

    public void BuyBaseMage()
    {
        if (PlayerStats.SkillPoints >= defaultMage.cost)
        {
            Debug.Log("Buy mage!");
            buildManager.SetMageToBuild(defaultMage);
        }
        selectedMage = defaultMage;

    }

    public void BuyRedMage()
    {
        if (PlayerStats.SkillPoints >= redMage.cost)
        {
            Debug.Log("Buy super mage!");
            buildManager.SetMageToBuild(redMage);
        }
        selectedMage = redMage;

    }

    public void BuyBlueMage()
    {
        if (PlayerStats.SkillPoints >= blueMage.cost)
        {
            Debug.Log("Buy another mage!");
            buildManager.SetMageToBuild(blueMage);
        }
        selectedMage = blueMage;

    }

    public void BuyGreenMage()
    {
        if (PlayerStats.SkillPoints >= greenMage.cost)
        {
            Debug.Log("Buy super mage!");
            buildManager.SetMageToBuild(greenMage);
        }
        selectedMage = greenMage;
    }

    public void BuyPurpleMage()
    {
        if (PlayerStats.SkillPoints >= purpleMage.cost)
        {
            Debug.Log("Buy super mage!");
            buildManager.SetMageToBuild(purpleMage);

        }
        selectedMage = purpleMage;
    }

    public void BuyLastMage()
    {
        if (PlayerStats.SkillPoints >= lastMage.cost)
        {
            PlayerStats.hasUltimateSkill = true;
        }
        selectedMage = lastMage;
    }

}

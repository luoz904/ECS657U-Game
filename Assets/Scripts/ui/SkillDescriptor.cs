using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillDescriptor : MonoBehaviour
{

    public Text costText;

    public Text descriptionText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shopManager.selectedMage != null) {
            SetSelectedSkill(shopManager.selectedMage);
        }
    }

    public void SetSelectedSkill(MageBlueprint mage) {
        descriptionText.text = "Description: " + mage.description;
        costText.text = "Cost: " + mage.cost.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillEnabler : MonoBehaviour
{
    public Image thisRenderer;

    public int SkillTrigger;

    public Color enableColor;

    public Color disableColor;

    void Start()
    {
        thisRenderer.color = enableColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerStats.SkillPoints < SkillTrigger)
        {
            thisRenderer.color = disableColor;
        } else {
            thisRenderer.color = enableColor;
        }
    }
}

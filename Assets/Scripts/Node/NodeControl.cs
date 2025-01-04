using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeControl : MonoBehaviour
{
    public Color hoverColor;
    public Color noMoneyColor;

    private bool hasBuild;
    private Renderer thisRenderer;
    private Color defaultColor;
    private NodeBuildManager buildManager;

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.hasMageToBuild)
            return;

        if (buildManager.hasMoneyToBuild)
            thisRenderer.material.color = hoverColor;
        else
            thisRenderer.material.color = noMoneyColor;
    }

    void OnMouseExit()
    {
        thisRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (hasBuild)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.hasMageToBuild)
            return;

        hasBuild = buildManager.buildMageOn(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        buildManager = NodeBuildManager.instance;
        thisRenderer = GetComponent<Renderer>();
        defaultColor = thisRenderer.material.color;
    }
}

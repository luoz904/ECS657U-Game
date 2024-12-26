using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeControl : MonoBehaviour
{
    public Color hoverColor;

    private bool hasBuild;

    private Renderer thisRenderer;
    private Color defaultColor;

    private BuildManager buildManager;

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;
        thisRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        thisRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.canBuild)
            return;

        if (hasBuild)
        {
            Debug.Log("Can't build there!");
            return;
        }
        hasBuild = buildManager.buildMageOn(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        thisRenderer = GetComponent<Renderer>();
        defaultColor = thisRenderer.material.color;
    }
}

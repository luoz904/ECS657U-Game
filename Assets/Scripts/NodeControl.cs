using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NodeControl : MonoBehaviour
{
    public Color hoverColor;

    private GameObject currentBuild;

    private Renderer thisRenderer;
    private Color defaultColor;

    private BuildManager buildManager;

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetMageToBuild() == null)
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

        if (buildManager.GetMageToBuild() == null)
            return;

        if (currentBuild != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject mageToBuild = buildManager.GetMageToBuild();
        currentBuild = Instantiate(mageToBuild, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;
        thisRenderer = GetComponent<Renderer>();
        defaultColor = thisRenderer.material.color;
    }
}

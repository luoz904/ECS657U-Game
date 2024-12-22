using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeControl : MonoBehaviour
{
    public Color hoverColor;

    private GameObject currentBuild;

    private Renderer thisRenderer;
    private Color defaultColor;

    void OnMouseEnter()
    {
        thisRenderer.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        thisRenderer.material.color = defaultColor;
    }

    void OnMouseDown()
    {
        if (currentBuild != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject mageToBuild = BuildManager.instance.GetMageToBuild();
        currentBuild = Instantiate(mageToBuild, transform.position, transform.rotation);
    }

    // Start is called before the first frame update
    void Start()
    {
        thisRenderer = GetComponent<Renderer>();
        defaultColor = thisRenderer.material.color;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{

    public GameObject ui;

    private NodeControl selectedNode;

    void Start() {
        ui.SetActive(false);
    }

    public void SelectedNode(NodeControl node) {
        selectedNode = node;
        transform.position = selectedNode.transform.position;
        ui.SetActive(true);
    }

    public void Hide() {
        ui.SetActive(false);
    }

}

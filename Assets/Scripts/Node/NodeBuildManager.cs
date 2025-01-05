using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NodeBuildManager : MonoBehaviour
{
    
    public static NodeBuildManager instance;

    public GameObject buildEffet;

    private MageBlueprint mageToBuild;
    
    private NodeControl selectedNode;

    public NodeUI nodeUI;

    public bool hasMageToBuild { get { return mageToBuild != null; }}

    public bool hasMoneyToBuild { get { return PlayerStats.SkillPoints >= mageToBuild.cost; }}

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void SetMageToBuild(MageBlueprint mage) {
        mageToBuild = mage;
        DeselectNode();
    }

    public bool buildMageOn(NodeControl node) {

        if (!hasMoneyToBuild) {
            Debug.Log("Not enough money!");
            return false;
        }

        PlayerStats.SkillPoints -= mageToBuild.cost;

        GameObject mage = Instantiate(mageToBuild.prefab, node.transform.position, node.transform.rotation);
        if (mage != null) {
            Debug.Log("Money build, money left " + PlayerStats.SkillPoints);

            GameObject effect = Instantiate(buildEffet, node.transform.position, node.transform.rotation);

            Destroy(effect, 5f);

        }

        return mage != null;
    }

    public void SelectNode(NodeControl node) {
        if (selectedNode == node) {
            DeselectNode();
            return;
        }
        selectedNode = node;
        mageToBuild = null;
        nodeUI.SelectedNode(selectedNode);
    }

    public void DeselectNode() {
        selectedNode = null;
        nodeUI.Hide();
    }

}

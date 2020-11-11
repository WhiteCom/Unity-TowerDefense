using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }

    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint TowerToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;

    public SelectedTowerUI TowerSelected;

    //property, only allow ourselves to get something from this variable
    public bool CanBuild { get { return TowerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= TowerToBuild.cost; } }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }

        selectedNode = node;
        TowerToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
        TowerSelected.ResetImage();
    }

    public void SelectTowerToBuild(TurretBlueprint tower)
    {
        TowerToBuild = tower;
        DeselectNode();
    }
   
    public TurretBlueprint GetTowerToBuild()
    {
        return TowerToBuild;
    }
}

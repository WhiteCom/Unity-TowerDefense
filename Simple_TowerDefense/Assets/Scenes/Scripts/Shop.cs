using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    [Header ("Tower BluePrint")]
    public TurretBlueprint Pawn_Tower;
    public TurretBlueprint Bishop_Tower;
    public TurretBlueprint Knight_Tower;
    public TurretBlueprint Rook_Tower;
    public TurretBlueprint Queen_Tower;
    public TurretBlueprint King_Tower;

    [Header("Tower Buttons")]
    //2Tier Tower
    public Button Bishop_btn;
    public Button Knight_btn;
    public Button Rook_btn;

    //3Tier Tower
    public Button Queen_btn;
    public Button King_btn;

    [Header("Tier Upgrade Cost")]
    public int two_tier_cost = 100;
    public int three_tier_cost = 150;

    [Header("Tier Upgrade Button")]
   
    public Button two_Tier_btn;
    public Button three_Tier_btn;

    [Space(10f)]
    public Text two_tier_txt;
    public Text three_tier_txt;

    [Space (10f)]
    [SerializeField]
    private bool two_Upgrade = false;
    [SerializeField]
    private bool three_Upgrade = false;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;

        Bishop_btn.interactable = false;
        Knight_btn.interactable = false;
        Rook_btn.interactable = false;

        Queen_btn.interactable = false;
        King_btn.interactable = false;
    }
    public void SelectPawnTower()
    {
        Debug.Log("Pawn Tower Selected");
        buildManager.SelectTowerToBuild(Pawn_Tower);
    }
    public void SelectBishopTower()
    {
        if (two_Upgrade == true)
        {
            Debug.Log("Bishop Tower Selected");
            buildManager.SelectTowerToBuild(Bishop_Tower);
        }
        else
            Debug.Log("You Must Byt 2Tier!");
    }
    public void SelectKnightTower()
    {
        if (two_Upgrade == true)
        {
            Debug.Log("Knight Tower Selected");
            buildManager.SelectTowerToBuild(Knight_Tower);
        }
        else
            Debug.Log("You Must Buy 2Tier!");
    }
    public void SelectRookTower()
    {
        if (two_Upgrade == true)
        {
            Debug.Log("Rook Tower Selected");
            buildManager.SelectTowerToBuild(Rook_Tower);
        }
        else
            Debug.Log("You Must Buy 2Tier!");
    }
    public void SelectQueenTower()
    {
        if (two_Upgrade == true && three_Upgrade == true)
        {
            Debug.Log("Queen Tower Selected");
            buildManager.SelectTowerToBuild(Queen_Tower);
        }
        else
            Debug.Log("You Must Buy 3Tier!");    
    }
    public void SelectKingTower()
    {
        if(two_Upgrade==true && three_Upgrade == true)
        {
            Debug.Log("King Tower Selected");
            buildManager.SelectTowerToBuild(King_Tower);
        }
        else
            Debug.Log("You Must Buy 3Tier!");

    }

    public void twoTier_upgrade()
    {
        if(PlayerStats.Money < two_tier_cost)
        {
            Debug.Log("Require More Money!");
            return;
        }

        Bishop_btn.interactable = true;
        Knight_btn.interactable = true;
        Rook_btn.interactable = true;
        two_Upgrade = true;

        PlayerStats.Money -= two_tier_cost;
        two_tier_txt.text = "DONE";
        two_Tier_btn.interactable = false;
    }

    public void threeTier_upgrade()
    {
        if (two_Upgrade)
        {
            if (PlayerStats.Money < three_tier_cost)
            {
                Debug.Log("Require More Money!");
                return;
            }
            Queen_btn.interactable = true;
            King_btn.interactable = true;
            three_Upgrade = true;

            PlayerStats.Money -= three_tier_cost;
            three_tier_txt.text = "DONE";
            three_Tier_btn.interactable = false;
        }
        else
            Debug.Log("You Must Buy 2Tier!");
    }

}

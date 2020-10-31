using UnityEngine;

public class Shop : MonoBehaviour
{
    //public TurretBlueprint standardTurret;
    //public TurretBlueprint missileLauncher;
    //public TurretBlueprint laserBeamer;

    public TurretBlueprint Pawn_Tower;
    public TurretBlueprint Bishop_Tower;
    public TurretBlueprint Knight_Tower;
    public TurretBlueprint Rook_Tower;
    public TurretBlueprint Queen_Tower;
    public TurretBlueprint King_Tower;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectPawnTower()
    {
        Debug.Log("Pawn Tower Selected");
        buildManager.SelectTowerToBuild(Pawn_Tower);
    }
    public void SelectBishopTower()
    {
        Debug.Log("Bishop Tower Selected");
        buildManager.SelectTowerToBuild(Bishop_Tower);
    }
    public void SelectKnightTower()
    {
        Debug.Log("Knight Tower Selected");
        buildManager.SelectTowerToBuild(Knight_Tower);
    }
    public void SelectRookTower()
    {
        Debug.Log("Rook Tower Selected");
        buildManager.SelectTowerToBuild(Rook_Tower);
    }
    public void SelectQueenTower()
    {
        Debug.Log("Queen Tower Selected");
        buildManager.SelectTowerToBuild(Queen_Tower);
    }
    public void SelectKingTower()
    {
        Debug.Log("King Tower Selected");
        buildManager.SelectTowerToBuild(King_Tower);
    }
}

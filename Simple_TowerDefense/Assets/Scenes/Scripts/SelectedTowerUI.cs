using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SelectedTowerUI : MonoBehaviour
{
    public static SelectedTowerUI instance;

    Image Original;
    public Sprite Pawn;
    public Sprite Bishop;
    public Sprite Knight;
    public Sprite Rook;
    public Sprite Queen;
    public Sprite King;
    public Sprite Unknown;

    BuildManager BuildTower;

    private void Start()
    {
        Original = GetComponent<Image>();
        BuildTower = BuildManager.instance;
        //ChangeImage();
    }

    public void ChangeImage()
    {
        //Pawn
        if (BuildTower.GetTowerToBuild().prefab.name == "Chess_Pawn" && BuildTower.CanBuild)
            Original.sprite = Pawn;

        //Bishop
        else if (BuildTower.GetTowerToBuild().prefab.name == "Chess_Bishop" && BuildTower.CanBuild)
            Original.sprite = Bishop;
        
        //Knight
        else if (BuildTower.GetTowerToBuild().prefab.name == "Chess_Knight" && BuildTower.CanBuild)
            Original.sprite = Knight;

        //Rook
        else if (BuildTower.GetTowerToBuild().prefab.name == "Chess_Rook" && BuildTower.CanBuild)
            Original.sprite = Rook;

        //Queen
        else if (BuildTower.GetTowerToBuild().prefab.name == "Chess_Queen" && BuildTower.CanBuild)
            Original.sprite = Queen;

        //King
        else if (BuildTower.GetTowerToBuild().prefab.name == "Chess_King" && BuildTower.CanBuild)
            Original.sprite = King;

        else
            Original.sprite = Unknown;
    }

    public void ResetImage()
    {
        Original.sprite = Unknown;
    }
}

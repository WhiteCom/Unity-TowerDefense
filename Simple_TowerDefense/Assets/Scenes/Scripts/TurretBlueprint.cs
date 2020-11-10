using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
    unity 내의 오브젝트에 쓰는 클래스가 아니므로 mono behavior를 지워줌 (shop 관련 cost 클래스)
    하지만 Inspector는 확인 및 편집해줄 필요가 있다. 따라서 System.Serializable을 쓴다.

    만약 해당 부분 없이 작업을 하게 되면, Shop에서 prefab이나, cost를 결정할때 해당 요소를 저장하지 못한다.
    (값을 입력하는 부분이 어딘지 알수 없으므로)
    따라서 이러한 요소를 inspector에 보여줘서 저장하기 위해 serializable을 사용한다.
*/
[System.Serializable]
public class TurretBlueprint
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellAmount()
    {
        return (int)(cost * 0.75);
    }

    public int Get_UpgradeSellAmount()
    {
        return (int)((cost+upgradeCost) * 0.75);
    }

    
}

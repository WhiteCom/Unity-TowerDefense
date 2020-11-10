using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;

    public Text sellAmount;

    private Node target;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();

        if (!target.isUpgraded) //업그레이드 안된경우, 업그레이드 비용 텍스트 문구
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
            sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        }
        else //업그레이드 된 경우 업그레이드 완료 문구 및 버튼 비활성화
        { 
            upgradeCost.text = "DONE";
            upgradeButton.interactable = false;
            sellAmount.text = "$" + target.turretBlueprint.Get_UpgradeSellAmount();
        }

        //sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();

        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false); //NodeUI의 Canvas 감추기용
    }

    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

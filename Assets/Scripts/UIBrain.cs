using TMPro;
using UnityEngine;

public class UIBrain : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI coinText;
    [SerializeField]
    private PickupSave pickupSave;

    private int coinCountAtSceneStart;

    private void Start()
    {
        coinCountAtSceneStart = pickupSave.Coins;
        coinText.text = pickupSave.Coins.ToString();
    }

    public void CoinPickedUp()
    {
        pickupSave.Coins++;
        coinText.text = pickupSave.Coins.ToString();
    }

    public void ResetCoinCountToSceneStart()
    {
        pickupSave.Coins = coinCountAtSceneStart;
    }
}

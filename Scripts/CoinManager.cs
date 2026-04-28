using UnityEngine;
using TMPro;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [Header("UI")]
    [SerializeField] TextMeshProUGUI coinText;

    private int coinCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        coinCount += amount;
        UpdateCoinUI();
    }

    public void RemoveCoins(int amount)
    {
        coinCount -= amount;
        if (coinCount < 0) coinCount = 0;
        UpdateCoinUI();
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateCoinUI();
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount.ToString();
        }
    }
}
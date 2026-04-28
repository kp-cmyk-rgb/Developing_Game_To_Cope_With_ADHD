using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance { get; private set; }

    [Header("UI")]
    public GameObject winUI;

    [Header("Rewards")]
    [SerializeField] int winRewardCoins = 10;
    [SerializeField] int bonusCoinsPerSecond = 1;
    [SerializeField] float bonusTimeThreshold = 60f;

    private bool hasWon = false;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        winUI?.SetActive(false);
    }

    public void CheckWin(ClickableSquare[] squares)
    {
        if (hasWon) return;

        foreach (ClickableSquare sq in squares)
        {
            Debug.Log("Square: " + sq.name + " | Current Z: " + Mathf.RoundToInt(sq.transform.eulerAngles.z) % 360 + " | IsCorrect: " + sq.IsCorrect());
            if (!sq.IsCorrect()) return;
        }

        hasWon = true;
        Timer.Instance?.StopTimer();
        
        // Calculate time bonus
        int totalCoins = winRewardCoins;
        if (Timer.Instance != null)
        {
            float timeTaken = Timer.Instance.GetElapsedTime();
            if (timeTaken < bonusTimeThreshold)
            {
                int timeBonus = Mathf.FloorToInt((bonusTimeThreshold - timeTaken) * bonusCoinsPerSecond);
                totalCoins += timeBonus;
            }
        }
        
        CoinManager.Instance?.AddCoins(totalCoins);
        winUI?.SetActive(true);
    }

    public void Reset()
    {
        hasWon = false;
        winUI?.SetActive(false);
    }
}
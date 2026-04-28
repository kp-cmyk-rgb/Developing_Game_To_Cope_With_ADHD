using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Labels")]
    public TMP_Text clickCountLabel;
    public TMP_Text totalClicksLabel;
    public TMP_Text runCountLabel;

    [Header("Buttons")]
    public Button runButton;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void RefreshClickDisplay(ClickableSquare square)
    {
        if (clickCountLabel != null)
            clickCountLabel.text = "Clicks: " + square.PendingClicks;

        RefreshTotalClicks();
    }

    public void RefreshRunCount(int count)
    {
        if (runCountLabel != null)
            runCountLabel.text = "Runs: " + count;
    }

    public void RefreshRunButton()
    {
        if (runButton != null)
            runButton.interactable = true;
    }

    private void RefreshTotalClicks()
    {
        if (totalClicksLabel == null) return;

        int total = 0;
        foreach (var sq in FindObjectsOfType<ClickableSquare>())
            total += sq.PendingClicks;

        totalClicksLabel.text = "Total pending: " + total;
    }
}
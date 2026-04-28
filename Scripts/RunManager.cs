using System.Collections.Generic;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    public static RunManager Instance { get; private set; }

    [Header("References")]
    public GameObject squaresHolder;

    [Header("Stats")]
    [SerializeField] private int runCount = 0;
    public int RunCount => runCount;

    private ClickableSquare[] squares;
    private int spinningCount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        GatherSquares();
    }

    public void OnRunButtonPressed()
    {
        if (spinningCount > 0) return;

        runCount++;
        spinningCount = 0;

        UIManager.Instance?.RefreshRunCount(runCount);

        foreach (ClickableSquare sq in squares)
        {
            if (sq.PendingClicks > 0)
            {
                spinningCount++;
                sq.ExecuteRun();
            }
        }

        if (spinningCount == 0)
            WinManager.Instance?.CheckWin(squares);
    }

    public void OnSquareFinishedSpinning()
    {
        spinningCount = Mathf.Max(0, spinningCount - 1);

        if (spinningCount == 0)
            WinManager.Instance?.CheckWin(squares);
    }

    public void ResetAll()
    {
        runCount = 0;
        UIManager.Instance?.RefreshRunCount(runCount);
        foreach (ClickableSquare sq in squares)
            sq.ResetClicks();
    }

    private void GatherSquares()
    {
        if (squaresHolder == null)
        {
            squares = FindObjectsOfType<ClickableSquare>();
        }
        else
        {
            var list = new List<ClickableSquare>();
            foreach (Transform child in squaresHolder.transform)
            {
                var sq = child.GetComponent<ClickableSquare>();
                if (sq != null) list.Add(sq);
            }
            squares = list.ToArray();
        }
    }
}
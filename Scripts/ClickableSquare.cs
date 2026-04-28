using UnityEngine;

public class ClickableSquare : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("Degrees rotated per click when RUN is pressed.")]
    public float degreesPerClick = 90f;

    [Header("State (Read Only)")]
    [SerializeField] private int pendingClicks = 0;

    public int PendingClicks => pendingClicks;

    private void OnMouseDown()
    {
        pendingClicks++;
        UIManager.Instance?.RefreshClickDisplay(this);
    }

    public void ExecuteRun()
    {
        if (pendingClicks == 0) return;

        transform.Rotate(0f, 0f, pendingClicks * degreesPerClick);
        pendingClicks = 0;

        UIManager.Instance?.RefreshClickDisplay(this);
        RunManager.Instance?.OnSquareFinishedSpinning();
    }

    public void ResetClicks()
    {
        pendingClicks = 0;
        UIManager.Instance?.RefreshClickDisplay(this);
    }

    public virtual bool IsCorrect() => true;
}
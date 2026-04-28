using UnityEngine;

/// <summary>
/// Extends ClickableSquare with win-condition logic from the original TurnSquare.
/// Attach THIS instead of ClickableSquare when you need angle-based correctness.
/// </summary>
public class RotationSquare : ClickableSquare
{
    [Header("Win Condition")]
    [Tooltip("Any of these Z-angles (0-359) count as 'correct'.")]
    public int[] correctRotations = { 0 };

    private readonly int[] rotations = { 0, 90, 180, 270 };

    private void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
    }

    // ── Public API ────────────────────────────────────────────────────────────

    /// <summary>Returns true when the square's current Z rotation matches any correctRotation.</summary>
    public override bool IsCorrect()
    {
        int current = Mathf.RoundToInt(transform.eulerAngles.z) % 360;
        foreach (int angle in correctRotations)
        {
            if (current == angle) return true;
        }
        return false;
    }
}
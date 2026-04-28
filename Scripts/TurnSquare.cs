using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnSquare : MonoBehaviour
{
    int[] rotations = { 0, 90, 180, 270 };
    public int[] correctRotation;

    [SerializeField]
private bool isPlaced = false;

public bool IsPlaced
{
    get { return isPlaced; }
}


    void Start()
    {
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        CheckPlacement();
    }

    void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);
        CheckPlacement();
    }

    void CheckPlacement()
    {
        int currentRotation = Mathf.RoundToInt(transform.eulerAngles.z) % 360;
        isPlaced = false;

        for (int i = 0; i < correctRotation.Length; i++)
        {
            if (currentRotation == correctRotation[i])
            {
                isPlaced = true;
                break;
            }
        }
    }
}

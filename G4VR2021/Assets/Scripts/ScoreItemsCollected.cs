using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItemsCollected : MonoBehaviour
{
    private static int score = 0;

    public static void IncreaseScore(int pointsFromItem)
    {
        score += pointsFromItem;
        Debug.Log(score);
    }
}

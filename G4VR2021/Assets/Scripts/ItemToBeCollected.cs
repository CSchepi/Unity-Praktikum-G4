using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToBeCollected : MonoBehaviour
{
    public int itemValue = 1;

    public void Collect()
    {
        ScoreItemsCollected.IncreaseScore(itemValue);
        Destroy(gameObject, 1);
    }
}

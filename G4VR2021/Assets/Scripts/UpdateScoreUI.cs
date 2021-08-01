using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpdateScoreUI : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        int score = ScoreItemsCollected.getscore();
        if (score > 0)
        {
            scoreText.text = "Your score: " +score+".000 $";
        }
        else
        {
            scoreText.text = "Your score: 0 $";
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{

    public int points = 0;
    public Text pointsText;

    public void AddScore()
    {
        points += 1;
    }

    public void update()
    {
        pointsText.text = "MASKS COLLECTED: " + points.ToString();
    }
}


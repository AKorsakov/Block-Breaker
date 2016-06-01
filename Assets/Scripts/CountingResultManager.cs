using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountingResultManager : MonoBehaviour
{
    public Text scoreText;
    public int totalScore;
    void Start()
    {
        print("Bricks destroyed: " + Brick.destroyedBricks);
        totalScore += Brick.destroyedBricks;
        scoreText.text = totalScore.ToString();
    }
}

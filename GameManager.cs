using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public int score = 0;
    public int highScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void increaseScore(int amount)
    {
        score += amount;
        print("New score: " + score.ToString());

        if (score > highScore)
        {
            highScore = score;
            print("New high score: " + highScore);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private int requiredCoins;
    private Game game;

    // Start is called before the first frame update
    void Start()
    {
        requiredCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        game = GameObject.FindObjectOfType<Game>();
    }

    public void checkForCompletion(int coinCount)
    {
        if (coinCount >= requiredCoins)
        {
            game.loadNextLevel();
        }
        else
        {
            Debug.Log("You don't have enough coins idiot...");
        }
    }
}

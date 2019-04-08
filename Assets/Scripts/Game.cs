using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private int level;

    [SerializeField]
    private bool lastLevel;

    public int nextLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        nextLevel = level + 1;
    }

    public void loadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void loadNextLevel()
    {
        if (!lastLevel)
        {
            loadLevel("Level-" + nextLevel);
        }
        else
        {
            //Goto Main-Menu
            loadLevel("Level-1");
        }
    }

    public void ReloadCurrentLevel()
    {
        loadLevel("Level-" + level);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

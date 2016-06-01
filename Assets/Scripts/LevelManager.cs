using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class LevelManager : MonoBehaviour
{
    public Text score;
    public Text numberOfLevel;
    public void Level(string name)
    {
        // HideLevelNumber();
        if (name == "Start")
        {
            Brick.destroyedBricks = 0;
        }
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {        
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BricksIsDestroyed()
    {
        score.text = Brick.destroyedBricks.ToString();
        if (Brick.breakableCount <= 0)
        {
            Invoke("LoadNextLevel", 0.3f);
        }
    }

    public void HideLevelNumber()
    {
        GameObject.Destroy(numberOfLevel);
    }
}

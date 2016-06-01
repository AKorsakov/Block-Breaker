using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    static bool isPlaying = false;
    void Start()
    {
        if (!isPlaying)
        {
            GameObject.DontDestroyOnLoad(gameObject);
            isPlaying = true;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }    
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Brick : MonoBehaviour
{
    public AudioClip clip = new AudioClip();
    public static int destroyedBricks = 0;
    public static int breakableCount = 0;
    public Sprite[] hitSprites;
    private LevelManager levelManager;
    private int timesHits;
    private bool isBreakable;
    private bool isDestroyed = false;

    void Start()
    {
    

        isBreakable = (this.tag == "Breakable");
        timesHits = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        if (isBreakable)
        {
            breakableCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D obj)
    {
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHits++;
        int maxHits = hitSprites.Length + 1;
        if (timesHits >= maxHits)
        {
            isDestroyed = true;
            breakableCount--;
            destroyedBricks++;
            if (isDestroyed)
            {              
                AudioSource.PlayClipAtPoint(clip, new Vector3(this.transform.position.x, this.transform.position.y, 0F));
                Destroy(gameObject);
            }
            levelManager.BricksIsDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

    void LoadSprites()
    {
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

  

    
}

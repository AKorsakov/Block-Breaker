using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    private Paddle paddle;
    private Vector3 paddleToBallVector;
    private bool hasStarted = false;
   
    void Start()
    {
        paddle = GameObject.FindObjectOfType<Paddle>();
        paddleToBallVector = this.transform.position - paddle.transform.position;
    }
   
    void Update()
    {
        if (!hasStarted)
        {
            this.transform.position = (paddle.transform.position + paddleToBallVector);
            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.rigidbody2D.velocity = new Vector2(2F, 10F);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0F, 0.2F), Random.Range(0F, 0.2F));
        if (hasStarted)
        {
            audio.Play();
            rigidbody2D.velocity += tweak;
        }
    }
}

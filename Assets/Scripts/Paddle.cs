using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour
{
    public bool autoPlay = false;
    private Ball ball;

    void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutpPlay();
        }
    }

    void AutpPlay()
    {
        Vector3 paddlePos = new Vector3(0F, this.transform.position.y, 0F);
        Vector3 ballPosition = ball.transform.position;
        paddlePos.x = Mathf.Clamp(ballPosition.x, 0.5F, 7.5F);
        this.transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 paddlePos = new Vector3(0F, this.transform.position.y, 0F);
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 8;
        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.65F, 7.3F);
        this.transform.position = paddlePos;
    }
}

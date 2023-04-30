using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleScaleUp : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public PaddleController leftPaddle;
    public PaddleController rightPaddle;
    public float increaseScale = 3f;
    public float duration = 5f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            leftPaddle.ActivatePUPaddleScaleUp(increaseScale, duration);
            rightPaddle.ActivatePUPaddleScaleUp(increaseScale, duration);

            manager.RemovePowerUp(gameObject);
        }
    }
}

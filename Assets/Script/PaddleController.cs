using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    
    public Vector2 speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Vector3 paddleScale;
    private Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        paddleScale = transform.localScale;
        rig.velocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = GetInput();
        MoveObject(movement);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            return Vector2.up * speed;
        }

        if (Input.GetKey(downKey))
        {
            return Vector2.down * speed;
        }

        return Vector2.zero;
    }

    private void MoveObject(Vector2 movement)
    {
        Debug.Log("TEST: " + movement);
        rig.velocity = movement;
    }

    public void ActivatePUPaddleSpeedUp(float magnitude, float duration)
    {
        speed *= magnitude;
        StartCoroutine(DeactivatePUSpeedUp(magnitude, duration));
    }

    private IEnumerator DeactivatePUSpeedUp(float magnitude, float duration)
    {
        yield return new WaitForSeconds(duration);
        speed /= magnitude;
    }

    public void ActivatePUPaddleScaleUp(float increaseScale, float duration)
    {
        StartCoroutine(IncreasePaddle(increaseScale, duration));
    }

    private IEnumerator IncreasePaddle(float increaseScale, float duration)
    {
        Vector3 paddleScale = transform.localScale;
        transform.localScale = new Vector3(paddleScale.x, paddleScale.y * increaseScale, paddleScale.z);
        yield return new WaitForSeconds(duration);
        transform.localScale = paddleScale;
    }

    
}

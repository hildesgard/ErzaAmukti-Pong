using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Transform spawnArea;
    public int maxPowerUpAmount;
    public int spawnInterval;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;
    public List<GameObject> powerUpTemplateList;
    private List<GameObject> powerUpList;
    private float timer;
    public float removeInterval;
    private float removeTimer;

    private void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0f;

        removeTimer = 0;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnInterval)
        {
            GenerateRandomPowerUp();
            timer -= spawnInterval;

        }

        removeTimer += Time.deltaTime;
        if (removeTimer > removeInterval)
        {

            RemoveAllPowerUp();
            removeTimer = 0;

        }

    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)));

    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x ||
            position.x > powerUpAreaMax.x ||
            position.y < powerUpAreaMin.y ||
            position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUp = Instantiate(powerUpTemplateList[randomIndex], new Vector3(position.x, position.y, powerUpTemplateList[randomIndex].transform.position.z), Quaternion.identity, spawnArea);
        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
        removeTimer = 0;
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        foreach (GameObject powerUp in powerUpList)
        {
            Destroy(powerUp);
        }
        powerUpList.Clear();
    }

}

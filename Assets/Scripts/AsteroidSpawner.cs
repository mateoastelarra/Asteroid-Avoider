using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenAsteroids = 1.5f;
    

    private float timer;
    private Camera mainCamera;

    private void Start() 
    {
        timer = secondsBetweenAsteroids;
        mainCamera = Camera.main;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SpawnAsteroid();
            timer = secondsBetweenAsteroids;
        }
    }

    private void SpawnAsteroid()
    {
        GameObject newAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        Instantiate(newAsteroid, SelectSpawningPoint(), Quaternion.identity);
    }

    private Vector3 SelectSpawningPoint()
    {
        int side = Random.Range(0,4);
        Vector2 spawningPoint = Vector2.one;
        switch (side)
        {
            case 0:
                spawningPoint = new Vector2(0, Random.Range(0f,1f));
                break;
            case 1:
                spawningPoint = new Vector2(1, Random.Range(0f,1f));
                break;
            case 2:
                spawningPoint = new Vector2(Random.Range(0f,1f), 0);
                break;
            case 3:
                spawningPoint = new Vector2(Random.Range(0f,1f), 1);
                break;
        }
        return mainCamera.ViewportToWorldPoint(new Vector3 (spawningPoint.x, spawningPoint.y, -mainCamera.transform.position.z));
    }
}

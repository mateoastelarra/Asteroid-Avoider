using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] asteroidPrefabs;
    [SerializeField] private float secondsBetweenAsteroids = 1.5f;
    [SerializeField] private Vector2 force;
    [SerializeField] private GameObject player;
    [Range(0,1)] 
    [SerializeField] float goToPlayerPosProbability;
    

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
        int side = Random.Range(0,4);

        Vector2 spawnPoint = Vector2.zero;
        Vector2 direction = Vector2.zero;

        switch (side)
        {
            case 0:
                spawnPoint = new Vector2(0, Random.value);
                direction = new Vector2(1, Random.Range(-1f, 1f));
                break;
            case 1:
                spawnPoint = new Vector2(1, Random.value);
                direction = new Vector2(-1, Random.Range(-1f, 1f));
                break;
            case 2:
                spawnPoint = new Vector2(Random.value, 0);
                direction = new Vector2(Random.Range(-1f, 1f), 1);
                break;
            case 3:
                spawnPoint = new Vector2(Random.value, 1);
                direction = new Vector2(Random.Range(-1f, 1f), -1);
                break;
        }

        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)];
        
        GameObject newAsteroid = Instantiate(
                                selectedAsteroid, 
                                worldSpawnPoint, 
                                Quaternion.Euler(new Vector3 (0f, 0f, Random.Range(0f, 360f))));

        Rigidbody RB = newAsteroid.GetComponent<Rigidbody>();

        // Make the asteroid go to player position with certain probability
        if (Random.value < goToPlayerPosProbability)
        {
            if (player == null){ return; }
            Vector3 goToPlayerPos = player.transform.position - newAsteroid.transform.position;
            direction.x = goToPlayerPos.x;
            direction.y = goToPlayerPos.y;
        }

        RB.velocity = direction.normalized * Random.Range(force.x, force.y);
    }

}

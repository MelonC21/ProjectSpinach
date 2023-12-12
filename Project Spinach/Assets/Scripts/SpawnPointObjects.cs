using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Created by Melvin and Victoria
public class SpawnPointObjects : MonoBehaviour
{
    //Array containing all desired spawn points in form of gameobjects
    [SerializeField] private Transform[] SpawnPoints;

    //Array for desired objects that will be placed randomly
    [SerializeField] private GameObject[] desiredSpawnables;

    //Spawn time between rotations of objects and start of game
    [SerializeField] private float spawnTimeTick;

    //Timer variable
    private float timerCountdown;

    //Updates each frame of the game
    void Update()
    {
        timerCountdown -= Time.deltaTime;
        if (timerCountdown < 0)
        {
            timerCountdown = spawnTimeTick;
            SpawnItems();
        }
    }

    //Randomly picks a spawnpoint
    void SpawnItems()
    {
        int spawnIndex = Random.Range(0, SpawnPoints.Length); // random index from the spawnpoints
        int objectIndex = Random.Range(0, desiredSpawnables.Length); // ran index from the desired objects
        Instantiate (desiredSpawnables[objectIndex], new Vector3 (SpawnPoints[spawnIndex].position.x, SpawnPoints[spawnIndex].position.y, 0), Quaternion.identity);
    }

}

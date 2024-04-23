using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectsObstacle : MonoBehaviour
{
    [SerializeField] private GameObject sphere;
    [SerializeField] private float maxSpawnTime;
    private float spawnTimeLeft;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimeLeft = maxSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimeLeft -= Time.deltaTime;
        if (spawnTimeLeft <= 0) {
            Instantiate(sphere, transform.position, transform.rotation);
            spawnTimeLeft = maxSpawnTime;
        }
    }
}

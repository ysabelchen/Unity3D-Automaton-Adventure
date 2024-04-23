using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumObstacle : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float limit = 75f;
    [SerializeField] private bool randomStart = false;
    private float random = 0f;

    private void Awake()
    {
        if (randomStart) {
            random = Random.Range(0f, 1f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float angle = limit * Mathf.Sin(Time.time + random * speed);
        transform.localRotation = Quaternion.Euler(0, 0, angle);
    }
}

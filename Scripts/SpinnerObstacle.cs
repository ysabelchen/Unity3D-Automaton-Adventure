using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerObstacle : MonoBehaviour
{
    [SerializeField] private Transform spinner;
    [SerializeField] private float spinSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinner.Rotate(0, 0, spinSpeed * Time.deltaTime);
    }

}

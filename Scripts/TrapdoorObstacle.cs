using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapdoorObstacle : MonoBehaviour
{
    //[SerializeField] private float rLerp = 0.03f;
    [SerializeField] private Transform pivot;
    private float speed = -90f;
    //private float degrees = -45f;
    public bool isTriggered = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered) {
            //transform.RotateAround(pivot.position, transform.forward, speed * Time.deltaTime);
            StartCoroutine(OpenTrapdoor());
            //transform.Rotate(speed * Time.deltaTime, 0, 0);

            //if (gameObject.transform.rotation.eulerAngles.x == degrees) {
            //if (transform.rotation == Quaternion.Euler(degrees, 0, 0)) {
                isTriggered = false;
            //}
        }
    }

    public IEnumerator OpenTrapdoor() {
        transform.Rotate(speed * Time.deltaTime, 0, 0);
        yield return null;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        isTriggered = true;
    }
}

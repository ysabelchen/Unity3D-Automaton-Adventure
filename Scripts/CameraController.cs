using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField] private Transform target;
    [SerializeField] private float pLerp = 0.1f;
    [SerializeField] private float rLerp = 0.03f;

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, target.position, pLerp);
        transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rLerp);
    }
}

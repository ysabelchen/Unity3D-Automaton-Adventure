using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRotation : MonoBehaviour
{
    [SerializeField] Vector2 turn;
    [SerializeField] private float sensitivity = 1.25f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        turn.x += Input.GetAxis("Mouse X");
        turn.y += Input.GetAxis("Mouse Y");
        transform.localRotation = Quaternion.Euler(-turn.y * sensitivity, turn.x * sensitivity, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform camTarget;
    [SerializeField] private float rLerp = 0.07f;

    private PlayerInputActions playerInputActions;
    private float originalSpeed = 1f;
    private float jumpForce = 7.5f;

    private void Start() {
        originalSpeed = speed;
        anim = GetComponent<Animator>();
    }

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Movement.Enable();
    }

    private void LateUpdate() {
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed = originalSpeed * 1.5f;
        } else {
            speed = originalSpeed;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, camTarget.rotation, rLerp);

        if (Input.GetKey(KeyCode.W)) {
            transform.position += speed * Time.deltaTime * transform.forward;
        } else if (Input.GetKey(KeyCode.S)) {
            transform.position -= speed * Time.deltaTime * transform.forward;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(jumpForce * Vector3.up, ForceMode.VelocityChange);
            anim.SetTrigger("Jump");
            anim.SetBool("inJump", true);
        }
    }

}
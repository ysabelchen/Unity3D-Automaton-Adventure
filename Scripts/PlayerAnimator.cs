using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    [SerializeField] private Animator anim;
    private float gradual;

    void Start() {
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))) {
            if (gradual < 2) {
                gradual += 0.025f;
                gradual = Mathf.Clamp(gradual, 0f, 2f);
            }
            anim.SetFloat("Speed", gradual);
        } else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) {
            if (gradual > 1) {
                gradual -= 0.025f;
            } else if (gradual < 1) {
                gradual += 0.05f;
                gradual = Mathf.Clamp(gradual, 0f, 1f);
            }
            anim.SetFloat("Speed", gradual);
        } else {
            if (gradual > 0f) {
                gradual -= 0.025f;
                gradual = Mathf.Clamp(gradual, 0, 2f);
            }
            anim.SetFloat("Speed", gradual);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RagdollController : MonoBehaviour
{
    [SerializeField] private CapsuleCollider mainCollider;
    [SerializeField] private GameObject skeleton;
    [SerializeField] private Animator anim;
    private Collider[] ragdollColliders;
    private Rigidbody[] ragdollRigidBodies;

    [SerializeField] private TextMeshProUGUI timerText;

    private void Awake() {
        ragdollColliders = skeleton.GetComponentsInChildren<Collider>();
        ragdollRigidBodies = skeleton.GetComponentsInChildren<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        DisableRagdoll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            EnableRagdoll();
            StartCoroutine(LoadEndScreen(4));
        }
    }

    public IEnumerator LoadEndScreen(int scene) {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }

    private void DisableRagdoll() {
        foreach (Rigidbody rb in ragdollRigidBodies) {
            rb.isKinematic = true;
        }

        foreach (Collider col in ragdollColliders) {
            col.enabled = false;
        }

        anim.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public void EnableRagdoll() {
        timerText.text = "";

        anim.enabled = false;

        foreach (Rigidbody rb in ragdollRigidBodies) {
            rb.isKinematic = false;
        }

        foreach (Collider col in ragdollColliders) {
            col.enabled = true;
        }

        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
}

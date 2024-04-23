using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private RagdollController playerRagdoll;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private float timer;
    private bool timerContinue;

    [SerializeField] private Collider endingLineTrigger;
    [SerializeField] private TextMeshProUGUI levelClearedText;

    private void Awake() {
        levelClearedText.text = "";
        timerContinue = true;
    }

    private void Update() {
        if (timerContinue) {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("#");
        }
        if (timer <= 0) {
            playerRagdoll.EnableRagdoll();
            levelClearedText.text = "Out of Time";
            timerContinue = false;
            StartCoroutine(LoadNextLevel(4));
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "EndingLine") {
            levelClearedText.text = "Level Cleared";
            timerContinue = false;
            StartCoroutine(LoadNextLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public IEnumerator LoadNextLevel(int scene) {
        timerText.text = "";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(scene);
    }
}

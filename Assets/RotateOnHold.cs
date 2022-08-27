using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RotateOnHold : MonoBehaviour {

    public float rotationSpeed = 1f;
    public float rotationDistance = 5f;
    public GameObject gameOverMenu;
    public int score = 0;
    public GameObject rotationPoint;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    private int direction;

    void Update () {
        transform.RotateAround (rotationPoint.transform.position, Vector3.forward * direction, rotationSpeed * Time.deltaTime);

        if (Input.GetKey (KeyCode.Space)) {
            direction = 1;
        } else {
            direction = -1;
        }

        scoreText.text = "Score: " + score;
        finalScoreText.text = "Score: " + score;

        if (score > PlayerPrefs.GetInt ("highscore")) {
            PlayerPrefs.SetInt ("highscore", score);
        }

        transform.LookAt (Camera.main.transform.position);
    }

    private void OnTriggerEnter (Collider other) {
        if (other.CompareTag ("Asteroid")) {
            Time.timeScale = 0.3f;
            transform.localScale = Vector3.zero;
            if (transform.childCount > 0) {
                Destroy (transform.GetChild (0).gameObject); // Destroy the linerenderer
            }
            gameOverMenu.SetActive (true);
            highScoreText.text = "High Score: " + PlayerPrefs.GetInt ("highscore");
            GetComponent<Rigidbody> ().isKinematic = true;
        }
    }

    public void Restart () {
        Time.timeScale = 1;
        SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction {
    UP,
    DOWN,
    LEFT,
    RIGHT
}

public class Asteroid : MonoBehaviour {

    public float rotationSpeed;
    public float maxTime = 7f;
    public Vector2 minMaxmoveSpeed = new Vector2 (3, 6);
    public Vector2 minMaxSize = new Vector2 (0.5f, 1);

    private Vector3 movement;

    private float timeSinceSpawn;

    private void Start () {
        float randomSize = Random.Range (minMaxSize.x, minMaxSize.y);
        transform.localScale = new Vector3 (randomSize, randomSize, randomSize);
    }

    void Update () {
        transform.RotateAround (transform.position, Vector3.forward, rotationSpeed);

        transform.position = transform.position + movement * Time.deltaTime;

        timeSinceSpawn += Time.deltaTime;

        // Destroy the asteroid if it has existed for too long
        if (timeSinceSpawn > maxTime) {
            Destroy (this.gameObject);
            if (Time.timeScale == 1) {
                FindObjectOfType<RotateOnHold> ().score += 1;
            }
        }
    }

    public void MoveDirection (Direction dir) {
        float x = 0;
        float y = 0;
        float moveSpeed = Random.Range (minMaxmoveSpeed.x, minMaxmoveSpeed.y);
        switch (dir) {
            case Direction.UP:
                y = moveSpeed;
                break;
            case Direction.DOWN:
                y = -moveSpeed;
                break;
            case Direction.LEFT:
                x = -moveSpeed;
                break;
            case Direction.RIGHT:
                x = moveSpeed;
                break;
        }
        movement = new Vector3 (x, y);

    }
}
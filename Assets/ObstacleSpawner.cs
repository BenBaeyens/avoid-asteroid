using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {
    public bool enableSpawns = true;
    public AnimationCurve spawnChance;
    public GameObject blockEnemy;

    public Vector2 minMaxOffset = new Vector2 (-5, 5);

    public float spawnDistance = 10f;

    public Direction dir;

    private void Start () {
        StartCoroutine (Spawn ());
    }

    private IEnumerator Spawn () {
        // Spawn
        float x = 0;
        float y = 0;

        float random = Random.Range (minMaxOffset.x, minMaxOffset.y);

        switch (dir) {
            case Direction.UP:
                y = -spawnDistance;
                x += random;
                break;
            case Direction.DOWN:
                y = spawnDistance;
                x += random;
                break;
            case Direction.LEFT:
                x = spawnDistance;
                y += random;
                break;
            case Direction.RIGHT:
                x = -spawnDistance;
                y += random;
                break;
        }

        Asteroid asteroid = Instantiate (blockEnemy, transform.position + new Vector3 (x, y, 0), Quaternion.identity).GetComponent<Asteroid> ();

        asteroid.MoveDirection (dir);

        // Restart the loop
        random = Random.Range (0f, 1f);
        yield return new WaitForSeconds (spawnChance.Evaluate (random));
        if (enableSpawns) {
            StartCoroutine (Spawn ());
        }
    }
}
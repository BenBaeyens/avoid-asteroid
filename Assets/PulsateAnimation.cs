using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulsateAnimation : MonoBehaviour {
    public float speed = 2f;

    public AnimationCurve curve;

    private float originalSize;

    public float newScale;

    private void Start () {
        originalSize = transform.localScale.x;
    }

    private void Update () {
        // Pulsate
        newScale = curve.Evaluate (Time.time * speed);

        transform.localScale = new Vector3 (newScale, newScale, newScale);
    }
}
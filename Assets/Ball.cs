using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    [SerializeField] private float torqueMult = 3f;

    public void Awake()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Add torque to the ball
        Vector2 directionToOther = other.transform.position - transform.position;
        float biggerComponent = Mathf.Abs(directionToOther.y) > Mathf.Abs(directionToOther.x)
            ? directionToOther.normalized.y
            : directionToOther.normalized.x;
        _rb2d.AddTorque(biggerComponent * torqueMult);
    }
}

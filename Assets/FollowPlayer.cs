using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] [Range(0, 1f)] private float slerpAmout;

    public void Update()
    {
        // Move camera towards the player
        transform.position = Vector3.Slerp(transform.position, player.position + offset, slerpAmout);
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Vector3 direction = Vector3.zero;
    private Collider collider;
    private Rigidbody rigidBody;
    [SerializeField] private float constantSpeed = 5f;
    // Use this for initialization
    void Start()
    {
        direction.x = 2;//Random.Range(-10f, 1f);
        direction.y = 1;// Random.Range(-1f, 10f);
        collider = GetComponent<Collider>();
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddForce(direction, ForceMode.Impulse);
    }

    void LateUpdate()
    {
        rigidBody.velocity = constantSpeed * (rigidBody.velocity.normalized);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GameManager.instance.TouchBlock(collision.gameObject.GetComponent<Block>());
        }
    }

}

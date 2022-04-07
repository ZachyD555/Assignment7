/*
 * Zach Daly
 * Assignment 7
 * Controls enemy movement and behavior
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody enemyRB;
    public GameObject player;
    public float speed = 3.0f;

    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
        // Add force towards the direction from the player to the enemy

        // Vector from enemy to player. .normalized to JUST GET DIRECTION
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        // Add force toward player
        enemyRB.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
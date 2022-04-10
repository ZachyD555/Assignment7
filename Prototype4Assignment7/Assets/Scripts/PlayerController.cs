/*
 * Zach Daly
 * Assignment 7
 * Controls player mechanics
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed;
    private float forwardInput;

    private GameObject focalPoint;
    public bool hasPowerUp;
    private float powerupStrength = 15.0f;
    public GameObject powerupIndicator;

    public Text loseText;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    void Update()
    {
        forwardInput = Input.GetAxis("Vertical");

        // move indicator
        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.4f, 0);

        if (gameObject.transform.position.y < -2)
        {
            loseText.gameObject.SetActive(true);
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void FixedUpdate()
    {
        playerRB.AddForce(focalPoint.transform.forward * speed * forwardInput);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Player hit " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            // get local ref to enemyRB
            Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();

            // set up vector3 with direction away from player
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            // add impulse force away from player
            enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        }
    }
}
/*
 * Zach Daly
 * Challenge 4
 * Controls enemy behavior
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyX : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private int goalLives;
    public Text loseText;


    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");

        GameObject theSPMan = GameObject.FindGameObjectWithTag("SpawnManager");
        SpawnManagerX spawnManager = theSPMan.GetComponent<SpawnManagerX>();

        speed += spawnManager.enemyWaveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        goalLives = GameObject.FindGameObjectsWithTag("Enemy").Length;

        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
            goalLives--;

            if (goalLives == 0)
            {
                loseText.gameObject.SetActive(true);
                Time.timeScale = 0;

                if (Input.GetKeyDown(KeyCode.R))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }
    }
}
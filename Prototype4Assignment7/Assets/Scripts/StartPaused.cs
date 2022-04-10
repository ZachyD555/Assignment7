/*
 * Zach Daly
 * Assignment 7
 * Pauses the game on start and waits for player to press spacebar
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPaused : MonoBehaviour
{
    public Text rules;

    void Start()
    {
        Time.timeScale = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            rules.gameObject.SetActive(false);
        }
    }
}
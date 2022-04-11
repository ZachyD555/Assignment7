/*
 * Zach Daly
 * Challenge 4
 * Starts game paused
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPausedX : MonoBehaviour
{
    public Text rules;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Time.timeScale = 1;
            rules.gameObject.SetActive(false);
        }
    }
}

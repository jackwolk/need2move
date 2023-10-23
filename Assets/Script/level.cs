using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{

    public Canvas deathMessage;
    public int currentLevel = 0;
    public GameObject[] Spawns;
    public GameObject[] FinalDoors;
    public PlayerMovement pm;
    public bool isDead;
    public bulletUI bUI;


    // Start is called before the first frame update
    void Start()
    {
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
        Cursor.lockState = CursorLockMode.Locked; 
        deathMessage = gameObject.transform.Find("deathMessage").GetComponent<Canvas>();
        deathMessage.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentLevel += 1; 
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentLevel -= 1;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartLevel(currentLevel);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartLevel(currentLevel);
        }
    }

    public void StartLevel(int Level)
    {
        gameObject.transform.position = Spawns[Level].transform.position;
        bUI.ForceReload();
    }

    public void checkRestart()
    {
        gameObject.transform.position = Spawns[currentLevel].transform.position;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        deathMessage.enabled = false;
        isDead = false;
        bUI.ForceReload();
    }

    public void endLevel()
    {
        currentLevel += 1;
        checkRestart();
    }

    public void SinglePlayerDeath()
    {
        isDead = true;
        Cursor.lockState = CursorLockMode.Confined;
        deathMessage.enabled = true;
        Time.timeScale = 0;


        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(i);
        }
    }

}

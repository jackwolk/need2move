using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{

    public int currentLevel = 0;
    public GameObject[] Spawns;
    public GameObject[] FinalDoors;


    // Start is called before the first frame update
    void Start()
    {

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
    }

    public void checkRestart()
    {
        gameObject.transform.position = Spawns[currentLevel].transform.position;
    }

    public void endLevel()
    {
        currentLevel += 1;
        checkRestart();
    }

}

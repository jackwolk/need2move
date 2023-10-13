using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class LevelEnd : MonoBehaviour
{

    public level LevelScript;
    public door DoorScript;
    public GameObject door;

    int timer = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        door = LevelScript.FinalDoors[LevelScript.currentLevel];
        DoorScript = door.GetComponent<door>();
    }

    private void OnTriggerEnter(Collider other)
    {
        timer = 0;
    }

    private void OnTriggerStay(Collider other)
    {


        if (DoorScript.isClosed == true)
        {
            timer += 1;
            if (timer >= 300) { LevelScript.endLevel(); }
        }
    }
}

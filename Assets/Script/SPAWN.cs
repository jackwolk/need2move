using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPAWN : MonoBehaviour


{
    public GameObject player;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
        player.transform.position = spawn.transform.position;
        }
    }
}

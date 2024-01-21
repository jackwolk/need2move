using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Death : MonoBehaviour
{
    public level level;

    // Start is called before the first frame update
    void Start()
    {
        level = GameObject.Find("Player").GetComponent<level>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.tag == "deathBarrier" && other.tag == "Player")
        {
            level.SinglePlayerDeath();
            Debug.Log("TRIGGER");
        }
    }



}

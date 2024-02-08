using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Timers;
using UnityEngine;

public class AirGunScript : MonoBehaviour
{
    public GameObject realplayer;
    public Rigidbody player;
    public GameObject camera;
    public int bulletCount = 3;
    public PlayerMovement playerMovement;
    public float delayMovement = 0f;
    public int force;
    public int maxBullets = 3;
    public bool doOnce = true;
    public bool timerComplete = false;

    Vector3 whereLooking;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = realplayer.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timerComplete == true)
        {
            StopCoroutine("Timer");
        }

        whereLooking = camera.transform.forward * force;



        if (Input.GetMouseButtonDown(0) && bulletCount > 0)
        {
            player.velocity = new Vector3(0,  0,  0);

            if(playerMovement.grounded == true)
            {
                player.drag = 0;
            }
            
            player.AddForce(whereLooking , ForceMode.Impulse);
            bulletCount -= 1;

        }

        if (playerMovement.grounded == true)
        {
            bulletCount = 3;
        }


    }

    public IEnumerator Timer() {
        yield return new WaitForSeconds(1);
        timerComplete = true;
}

    void AddVelocity() {
        player.AddForce(whereLooking, ForceMode.Impulse);
    }


}

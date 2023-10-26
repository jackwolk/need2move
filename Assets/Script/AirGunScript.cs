using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirGunScript : MonoBehaviour
{
    public GameObject realplayer;
    public Rigidbody player;
    public GameObject camera;
    public int bulletCount = 3;
    public PlayerMovement playerMovement;
    public float delayMovement = 0.2f;
    public int force;
    public int maxBullets = 3;

    Vector3 whereLooking;
    
    
    // Start is called before the first frame update
    void Start()
    {
        playerMovement = realplayer.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
        whereLooking = camera.transform.forward * force;


        
        if (Input.GetMouseButtonDown(0) && bulletCount>0)
        {
            player.velocity = new Vector3(0,  0,  0);
            player.AddForce(whereLooking , ForceMode.Impulse);
            bulletCount -= 1;

            StartCoroutine("StopMovement");
        }

        if(playerMovement.isGrounded == true)
        {
            bulletCount = 3;
        }


    }

    IEnumerator StopMovement()
    {
        playerMovement.enabled = false;

        yield return new WaitForSeconds(delayMovement);

        playerMovement.enabled = true;

    }


}

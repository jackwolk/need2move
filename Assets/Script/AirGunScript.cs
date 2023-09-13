using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirGunScript : MonoBehaviour
{

    public Rigidbody player;
    public GameObject camera;


    public int force;

    Vector3 whereLooking;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        whereLooking = camera.transform.forward * force;
       
        

         
        if (Input.GetMouseButtonDown(0))
        {
            player.AddForce(whereLooking, ForceMode.Impulse);
            //player.velocity = new Vector3(0,0,3);
        }
    }



}

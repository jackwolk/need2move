using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STICKYWALL : MonoBehaviour
{
    public GameObject player;
    public LayerMask wall;
    public Rigidbody playerrb;
    public float chkDistance;


    private void Start()
    {
        playerrb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(player.transform.position, playerrb.velocity, out hit, chkDistance, wall))
        {
            Debug.Log("Making Horizontal 0");
            playerrb.velocity = new Vector3(-playerrb.velocity.x, playerrb.velocity.y, -playerrb.velocity.z); 
        }

    }
}

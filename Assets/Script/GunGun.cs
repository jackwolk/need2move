using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGun : MonoBehaviour
{

    public GameObject bullet;
    public int maxBullet;
    public int currentBullet;
    public KeyCode reloadKey;
    public GameObject bulletSpawn;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && currentBullet > 0)
        {
            currentBullet -= 1;
            Instantiate(bullet, gameObject.transform.position + new Vector3(0,.5f,0), gameObject.transform.rotation);
        }

        if (Input.GetKeyDown(reloadKey))
        {
            currentBullet = maxBullet;
        }
    }
}

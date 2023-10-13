using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update

    int frame;
    public Rigidbody rb;
    public GameObject gun;
    public int speed;
    public int targetLayerNum;
    public int groundLayerNum;
    public int wallLayerNum;
    public target target;
    

    void Start()
    {
        frame = 0;
        gun = GameObject.Find("Gun Gun");
        gameObject.transform.Rotate(90, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        frame += 1;

        

        if(frame == 1)
        {
            rb.velocity = gun.transform.forward * speed;
            Debug.Log("JAJAJA");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {

        target = collision.gameObject.GetComponent<target>();
        if (collision.gameObject.layer == targetLayerNum)
        {
            Debug.Log("Hit");
            target.isHit = true;
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == groundLayerNum)
        {
            Debug.Log("GOUDN");
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == wallLayerNum)
        {
            Debug.Log("WEAL");
            Destroy(gameObject);
        }


    }


}

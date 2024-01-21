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
    public int bounceLayerNum;
    public int objectLayerNum;
    public int bounceNum = 0;
    public target target;
    public int timer = 0;
    public int maxTime = 500;
    Vector3 lastVelocity;
    bool canSee = false;
    public MeshRenderer mr;
    

    void Start()
    {
        mr.enabled = false;
        frame = 0;
        gun = GameObject.Find("Gun Gun");
        gameObject.transform.Rotate(90, 0, 0);
        StartCoroutine("SeeBullet");
    }

    IEnumerator SeeBullet()
    {
        yield return new WaitForSeconds(.025f);
        Debug.Log("I CAN SEE");
        mr.enabled = true;
    }

    private void FixedUpdate()
    {
        timer += 1;

        if(timer >= maxTime)
        {
            Destroy(gameObject);
        }

    }

    private void LateUpdate()
    {

        lastVelocity = rb.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        frame += 1;

        

        if(frame == 1)
        {
            rb.velocity = gun.transform.forward * speed;
           
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
        else if(collision.gameObject.layer == bounceLayerNum)
        {
            Debug.Log("BOUNC");
            
                float newSpeed = lastVelocity.magnitude;
                Vector3 newDirection = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

                rb.velocity = Vector3.ClampMagnitude(newDirection * Mathf.Max(lastVelocity.magnitude, 2), 65);

        }
        else if(collision.gameObject.layer == objectLayerNum)
        {
            Destroy(gameObject);
            collision.rigidbody.AddExplosionForce(3000, collision.transform.position, 100, 10000);
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public target target;
    public GameObject Target;
    public GameObject door1;
    public GameObject door2;
    int rotation = 0;



    // Start is called before the first frame update
    void Start()
    {
        target = Target.GetComponent<target>();
        rotation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.isHit == true && rotation<700) {
            door1.transform.Translate(0, 0, -0.01f);
            door2.transform.Translate(0, 0, 0.01f);
            rotation += 1;

        }
        else if(target.isHit == false && rotation > 0) {
            door1.transform.Translate(0, 0, 0.01f);
            door2.transform.Translate(0, 0, -0.01f);
            rotation -= 1;

        }
    }
}

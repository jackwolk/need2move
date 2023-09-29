using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponholder : MonoBehaviour
{

    public GameObject gungun;
    public GameObject airgun;

    bool TRUE = true;
    bool FALSE = false;

    // Start is called before the first frame update
    void Start()
    {
        


        airgun.active = TRUE;
        gungun.active  = FALSE;
    }

    // Update is called once per frame
    void Update()
    {
        airgun.active = TRUE;
        gungun.active = FALSE;
        if (Input.GetMouseButtonDown(1))
        {
            TRUE = !TRUE;
            FALSE = !FALSE;
        }

        
    }
}

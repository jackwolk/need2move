using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;




public class weaponholder : MonoBehaviour
{

    public GameObject gungun;
    public GameObject airgun;
    public RawImage crosshair;
    public Texture crosshair1;
    public Texture crosshair2;

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
        if (TRUE == true) {
            crosshair.texture = crosshair1;
            
        }
        else
        {
            crosshair.texture = crosshair2;
        }

    }
}

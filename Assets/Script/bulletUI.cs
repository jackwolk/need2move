using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class bulletUI : MonoBehaviour
{

    public GunGun gunscr;

    // Start is called before the first frame update
    void Start()
    {
        gunscr = GameObject.Find("Gun Gun").GetComponent<GunGun>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

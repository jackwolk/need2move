using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerapos : MonoBehaviour

    

{
    public GameObject cameraPos;
    public GameObject camera;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        camera.transform.position = cameraPos.transform.position;
        camera.transform.rotation = cameraPos.transform.rotation;
    }
}

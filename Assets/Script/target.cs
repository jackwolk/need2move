using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{
    public bool isHit;
    public float timer;
    public float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        isHit = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHit && timer < maxTime)
        {
            timer += Time.deltaTime;
        }
        if (isHit && timer >= maxTime)
        {
            timer = 0;
            isHit = false;
        }
    }
}

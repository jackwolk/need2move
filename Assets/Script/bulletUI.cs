using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class bulletUI : MonoBehaviour
{

    public GunGun gunscr;
    Vector3 StartPos;
    RawImage [] bullet_array;
    int tempMax;
    public RawImage bulletImage;
    public GameObject GunGun;
    public Canvas canvas;

    public bool hasGun = true;
    public bool doOnce = false;


    // Start is called before the first frame update
    void Start()
    {
        tempMax = gunscr.maxBullet;
        gunscr = GameObject.Find("Gun Gun").GetComponent<GunGun>();
        bullet_array = new RawImage[tempMax];

        StartPos = new Vector3(-862, -424, 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (hasGun == true && doOnce == false)
        {
            for (int i = 0; i < bullet_array.Length; i++)
            {
                RawImage image = Instantiate(bulletImage, canvas.transform, true);
                image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
                image.name = "BulletUIImage #" + i;
            }
            doOnce = true;
        }




        if (tempMax != gunscr.maxBullet)
        {
            tempMax = gunscr.maxBullet;
            bullet_array = new RawImage[tempMax];
        }

        if (GunGun.activeInHierarchy == true)
        {

            if (Input.GetMouseButtonDown(0) && gunscr.currentBullet > 0)
            {
                int current = gunscr.currentBullet - 1;
                Debug.Log(current);
                Destroy(GameObject.Find("BulletUIImage #" + current));
            }

            if (Input.GetKeyDown(gunscr.reloadKey))
            {
                for (int i = 0; i < bullet_array.Length; i++)
                {
                    Destroy(GameObject.Find("BulletUIImage #" + i));
                }

                for (int i = 0; i < bullet_array.Length; i++)
                {
                    RawImage image = Instantiate(bulletImage, canvas.transform, true);
                    image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
                    image.name = "BulletUIImage #" + i;
                }

            }


        }



        
        


    }


    public void ForceReload()
    {
        for (int i = 0; i < bullet_array.Length; i++)
        {
            Destroy(GameObject.Find("BulletUIImage #" + i));
        }

        for (int i = 0; i < bullet_array.Length; i++)
        {
            RawImage image = Instantiate(bulletImage, canvas.transform, true);
            image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
            image.name = "BulletUIImage #" + i;
        }

        gunscr.currentBullet = gunscr.maxBullet;
    }
}

using UnityEngine.UI;
using UnityEngine;

public class bulletUI : MonoBehaviour
{

    public GunGun gunscr;
    Vector3 StartPos;
    RawImage[] bullet_array;
    int tempMax;
    public RawImage bulletImage;
    public GameObject GunGun;
    public Canvas canvas;

    public AirGunScript airscr;
    int airTempMax;
    RawImage[] air_array;
    public GameObject AirGun;
    public RawImage airImage;

    public bool hasGun = true;
    public bool doOnce = false;
    public bool doOnce2 = false;


    // Start is called before the first frame update
    void Start()
    {

        gunscr = GunGun.GetComponent<GunGun>();
        tempMax = gunscr.maxBullet;
        bullet_array = new RawImage[tempMax];


        airscr = AirGun.GetComponent<AirGunScript>();
        airTempMax = airscr.maxBullets;
        air_array = new RawImage[airTempMax];


        StartPos = new Vector3(-862, -424, 0);


    }

    // Update is called once per frame
    void Update()
    {
        if (tempMax != gunscr.maxBullet)
        {
            tempMax = gunscr.maxBullet;
            bullet_array = new RawImage[tempMax];
        }

        if (airTempMax != airscr.maxBullets)
        {
            airTempMax = airscr.maxBullets;
            air_array = new RawImage[airTempMax];
        }










        if (GunGun.activeInHierarchy == true)
        {
            if (hasGun == true && doOnce == false)
            {

                for (int i = 0; i < air_array.Length; i++)
                {
                    Destroy(GameObject.Find("AirUIImage #" + i));
                }

                for (int i = 0; i < gunscr.currentBullet; i++)
                {
                    RawImage image = Instantiate(bulletImage, canvas.transform, true);
                    image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
                    image.name = "BulletUIImage #" + i;
                }
                doOnce = true;
                doOnce2 = false;
            }


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

        if (AirGun.active == true)
        {


            if (doOnce2 == false)
            {
                for (int i = 0; i < bullet_array.Length; i++)
                {
                    Destroy(GameObject.Find("BulletUIImage #" + i));
                }

                for (int i = 0; i < airscr.bulletCount; i++)
                {
                    RawImage image = Instantiate(airImage, canvas.transform, true);
                    image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
                    image.name = "AirUIImage #" + i;
                }
                doOnce2 = true;
                doOnce = false;
            }


            if (Input.GetMouseButtonDown(0) && airscr.bulletCount > 0)
            {
                int current = airscr.bulletCount - 1;
                Debug.Log(current);
                Destroy(GameObject.Find("AirUIImage #" + current));
            }

            if (airscr.playerMovement.grounded == true)
            {
                for (int i = 0; i < air_array.Length; i++)
                {
                    Destroy(GameObject.Find("AirUIImage #" + i));
                }

                for (int i = 0; i < air_array.Length; i++)
                {
                    RawImage image = Instantiate(airImage, canvas.transform, true);
                    image.rectTransform.anchoredPosition = StartPos + new Vector3(i * 100, 0, 0);
                    image.name = "AirUIImage #" + i;
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
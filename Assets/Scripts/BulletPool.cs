using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;
    private List<GameObject> yubiyubi;

    //Create a variable to see when there is enough yubis in the pool
    public int yubiEnoughCount = 300;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    void Start()
    {
        //yubiyubi = new List<GameObject>();

        //Create our list and depedning on our max count then we instantiates bullets at the start
        //of the game so we can use them and put them back in the list for object pooling
        yubiyubi = new List<GameObject>();

        for (int i = 0; i < yubiEnoughCount; i++)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            yubiyubi.Add(bul);
        }
    }

    public GameObject GetBullet()
    {
        if (yubiyubi.Count > 0)
        {
            for (int i = 0; i < yubiyubi.Count; i++)
            {
                if (!yubiyubi[i].activeInHierarchy)
                {
                    return yubiyubi[i];
                }
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            yubiyubi.Add(bul);

            //If yubi count goes over the pool limit then set not enough bullets in pool to false
            if (yubiyubi.Count >= yubiEnoughCount)
            {
                notEnoughBulletsInPool = false;
            }

            return bul;
        }

        return null;
    }
}

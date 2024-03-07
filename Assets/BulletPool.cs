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

    private void Awake()
    {
        bulletPoolInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        yubiyubi = new List<GameObject>();
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
        return bul;
    }
    return null;
   }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;

    [SerializeField] public float startAngle = 90f, endAngle = 270f;

    private Vector2 bulletMoveDirection;

    void Start()
    {
        InvokeRepeating("Fire", 0f, 3.5f);
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirx = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDiry = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirx, bulDiry, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            //If player scipt is not equal to null then create bullets
            if (playerscript.instance != null)
            {
                GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<EnemyBullet>().SetMoveDirection(bulDir);

                angle += angleStep;
            }
        }
    }
}

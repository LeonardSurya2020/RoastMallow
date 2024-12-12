using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting_Boss : MonoBehaviour
{
    public Bullets bullets;

    //public Transform firePoint;

    

    float timeBetween;
    public float startTimeBetween;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = (transform.localRotation * Vector2.right);
        timeBetween = startTimeBetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetween <= 0)
        {
            GameObject bullet = Instantiate(bullets.gameObject, transform.position, transform.rotation);

            Bullets goBullet = bullet.GetComponent<Bullets>();

            goBullet.direction = direction;
            timeBetween = startTimeBetween;
        }
        else
        {
            timeBetween -= Time.deltaTime;
        }
    }
}

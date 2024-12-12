using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSound;
    public TextMeshProUGUI BulletCounter;
    public static float bulletForce = 4f;

    public GameObject RechrGauge;
    public Animator gauge;

    public float delay = 2f;
    float cooldown = 0f;

    public static int totalBulletNum = 5;

    // Update is called once per frame
    void Update()
    {
        BulletCounter.text = totalBulletNum.ToString();
        if (Time.time >= cooldown)
        {
            if (totalBulletNum > 0)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    totalBulletNum -= 1;
                    Shoot();
                }
            }
            else
            {
                StartCoroutine(Reloading());
            }

        }
    }

    public void Shoot()
    {
        shootSound.Play();
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
    }


    public IEnumerator Reloading()
     {
         yield return new WaitForSeconds(0.5f);
         cooldown = Time.time + 0.2f / delay;
         totalBulletNum = 5;
        RechrGauge.SetActive(true);
        gauge.SetTrigger("recharge");
        yield return new WaitForSeconds(1f);
        RechrGauge.SetActive(false);
        

        //yield return new WaitForSeconds(0.1f);
    }
}

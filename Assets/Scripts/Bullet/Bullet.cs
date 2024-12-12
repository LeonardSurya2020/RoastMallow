using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;
    public static int damage = 1;
    //[SerializeField] private ParticleSystem explodeParticle = default;

    public void Start()
    {
        //explodeParticle.Pause();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<enemy>(out enemy EnemyComponent))
        {
            EnemyComponent.TakeDamage(damage);
        }
        DesObj();
        

    }

    public void DesObj()
    {
       
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.20f);
        Destroy(gameObject);
    }



}

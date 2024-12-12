using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHP;
    public int Damage;
    public int score;
    public Animator EnemyHitEffect;
    public static bool onCorner = false;
    public ParticleSystem Explode;
    public SpriteRenderer sr;

    public float lockPos = 0;


    private void Start()
    {
        MaxHp = CurrentHP;
        Explode.Pause();
    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(lockPos, lockPos, lockPos);
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.TryGetComponent<PlayerUnit>(out PlayerUnit PlayerComponent))
        {
            PlayerComponent.TakeDamage(Damage);
        }


        if (collision.gameObject.tag.Equals("Player") && onCorner == true)
         {
                Vector2 diff = transform.position - collision.transform.position;
                transform.position = new Vector2(transform.position.x + diff.x, transform.position.y + diff.y);
         }
        
    }
    public void TakeDamage(int totalDamage)
    {
        CurrentHP -= totalDamage;
        EnemyHitEffect.SetTrigger("hit");
        if (CurrentHP <= 0)
        {
            dead();
        }
    }

    public void dead()
    {
        Explode.Play();
        Scoring.totalScore += score;
        Destroy(sr);
        Destroy(gameObject, 1);
    }

}

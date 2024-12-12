using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiEbeny : MonoBehaviour
{
    public int MaxHp;
    public int CurrentHP;
    public int Damage;
    public int score;
    public Animator EnemyHitEffect;

    public float lockPos = 0;
    public GameObject ChildEnemy;

    private void Start()
    {
        MaxHp = CurrentHP;

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
        GameObject Child = Instantiate(ChildEnemy, transform.position, Quaternion.identity);
        Scoring.totalScore += score;
        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy_NormalProjectile : MonoBehaviour
{
    private Transform player;
    public Rigidbody2D rb;
    private Vector2 movedir;
    public int movspeed = 3;

    public int Damage;
    public GameObject hitEffect;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        movedir = (player.position - transform.position).normalized * movspeed;
        rb.velocity = new Vector2(movedir.x, movedir.y);
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerUnit>(out PlayerUnit PlayerComponent))
        {
            PlayerComponent.TakeDamage(Damage);
        }
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.20f);
        Destroy(gameObject);
    }
}

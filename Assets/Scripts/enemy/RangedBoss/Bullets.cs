using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Vector2 direction = new Vector2(1, 0);
    public float speed;

    public Vector2 velocity;


    Rigidbody2D rb;


    public GameObject hitEffect;
    public int Damage;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void Update()
    {
        velocity = direction * speed;
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        pos += velocity * Time.deltaTime;

        transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

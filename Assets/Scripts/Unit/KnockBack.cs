using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockBack : MonoBehaviour
{
    public Rigidbody2D rb;

    public float force = 16;
    public float delay = 0.15f;

    public UnityEvent onBegin, onDone;
    public GameObject sender;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Player"))
        {
            PlayFeedBack(sender);
        }
    }

    public void PlayFeedBack(GameObject sender)
    {
        StopAllCoroutines();
        onBegin?.Invoke();
        Vector2 direction = (transform.position - sender.transform.position).normalized;
        rb.AddForce(direction * force, ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb.velocity = Vector3.zero;
        onDone?.Invoke();
    }
}

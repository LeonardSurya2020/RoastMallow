using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleAbilityEnemies : MonoBehaviour
{
    public Animator anim;
    public void Start()
    {
        StartCoroutine(InvisManager());
    }
    IEnumerator InvisManager()
    {
        yield return new WaitForSeconds(0f);
       
        anim.SetBool("isInvisible", false);
        GetComponent<Collider2D>().enabled = false;
       
        yield return new WaitForSeconds(3f);
       
        anim.SetBool("isInvisible", true);
        GetComponent<Collider2D>().enabled = true;
        yield return new WaitForSeconds(3f);
        StartCoroutine(InvisManager());

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_mov : MonoBehaviour
{
    public Rigidbody2D rb;
    public static float ms = 1;
    private bool faceright;
    public Vector2 moveDir;

    //DELAY MOVEMENT (NOT USED YET)
    public float delay = 2f;
    float cooldown = 0f;

    public float horiz;
    float vertical;

    public static bool canAbi = false;
    public static bool canDash = false;

    //public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // MOVEMENT CHARACTER
    void Update()
    {
        if(Time.time >= cooldown)
        {
            horiz = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            moveDir = new Vector2(horiz, vertical).normalized;
            rb.velocity = new Vector2(ms * horiz, ms * vertical).normalized;

            if (Input.GetAxisRaw("Horizontal") > 0.5)
            {
                //anim.SetFloat("mov", 1);
                faceright = true;
                if (faceright == true)
                {
                    transform.localScale = new Vector2(1, 1);

                }

            }
            else if (Input.GetAxisRaw("Horizontal") < -0.5)
            {

                //rb.velocity = new Vector2(ms * horiz, rb.velocity.y);
                //anim.SetFloat("mov", 1);
                faceright = false;
                if (faceright == false)
                {
                    transform.localScale = new Vector2(-1, 1);

                }

            }
            else if (Input.GetAxisRaw("Vertical") > 0.5)
            {

                //rb.velocity = new Vector2(rb.velocity.x, ms * vertical);
            }
            else if (Input.GetAxisRaw("Vertical") < -0.5)
            {
                //rb.velocity = new Vector2(rb.velocity.x, ms * vertical);
            }
            else
            {
                rb.velocity = new Vector2(0, 0);
                //anim.SetFloat("mov", 0);
            }
           // StartCoroutine(delayMov());
            
        }
        
    }

    /* public IEnumerator delayMov()
     {
         yield return new WaitForSeconds(0.5f);
         rb.velocity = new Vector2(0 * horiz, 0 * vertical);
         cooldown = Time.time + 1f / delay;
         yield return new WaitForSeconds(0.5f);
     }*/


    //KNOCK BACK
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals ("Enemy"))
        {
            Vector2 diff = transform.position - collision.transform.position;
            transform.position = new Vector2(transform.position.x + diff.x, transform.position.y + diff.y);
        }
    }

}

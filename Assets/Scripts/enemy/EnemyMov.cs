using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMov : MonoBehaviour
{
    GameObject PlayerPosition;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start()
    {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if(PlayerPosition != null)
        {
            if (PlayerPosition.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(1, 1);
            }
            else if (PlayerPosition.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
       
    }
}

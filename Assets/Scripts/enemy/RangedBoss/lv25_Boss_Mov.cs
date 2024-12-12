using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv25_Boss_Mov : MonoBehaviour
{
    public float movSpeed;
    public bool moveUp;
    // Start is called before the first frame update
    void Start()
    {
        moveUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > 1)
        {
            moveUp = false;
        }
        else if(transform.position.y < -2)
        {
            moveUp = true;
        }

        if(moveUp == true)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y + movSpeed * Time.deltaTime);
        }
        else if(moveUp == false)
        {
            transform.position = new Vector2(transform.position.x , transform.position.y - movSpeed * Time.deltaTime);
        }
    }
}

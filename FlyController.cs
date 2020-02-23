using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    Rigidbody2D rb;
    float flyaxis;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.inertia = 100;
    }

    // Update is called once per frame
    void Update()
    {
        flyaxis = Input.GetAxis("FlyAxis") * Time.fixedDeltaTime * 500;
        rb.inertia = 100;
        if (Input.GetAxis("FlyAxis") != 0)
        {
            rb.velocity = new Vector3(0, flyaxis-1, 0);
            //rb.AddForce(new Vector2(0, Input.GetAxis("FlyAxis") * Time.fixedDeltaTime * 100), ForceMode2D.Force);
        }
        else
        {
            
        }
    }
}

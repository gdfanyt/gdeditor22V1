using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playrt : MonoBehaviour
{

    public static int mode;
    public bool isPlatformer;
    public static bool otherisplatformer;
    public SpriteRenderer cubeSprite;
    public SpriteRenderer shipSprite;
    // Start is called before the first frame update
    void Start()
    {
        mode = 0;
    }
   void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "enemy")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        if (collision.gameObject.tag == "FlyPortal")
        {
            mode = 1;
        }
        if (collision.gameObject.tag == "CubePortal")
        {
            mode = 0;
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "FlyPortal")
        {
            mode = 1;
        }
        if (collider.gameObject.tag == "CubePortal")
        {
            mode = 0;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(mode == 0)
        {
            cubeSprite.enabled = true;
            shipSprite.enabled = false;
        }
        if (mode == 1)
        {
            cubeSprite.enabled = false;
            shipSprite.enabled = true;
        }
        otherisplatformer = isPlatformer;
        if (!isPlatformer)
        {
            transform.position += Vector3.right * Time.fixedDeltaTime * 10;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Ray2D ray = new Ray2D(transform.position, Vector3.down);
                RaycastHit2D rh;

            }
        }
        
    }
}

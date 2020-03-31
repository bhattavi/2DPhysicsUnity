using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    public LayerMask ground;
    Rigidbody2D rb;
    Vector2 force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        force = Vector2.zero;

        if (Input.GetKey(KeyCode.A))
        {
            force.x = -10;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            force.x = 10;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 feet = new Vector2(transform.position.x, transform.position.y - 0.5f);
            Vector2 dimensions = new Vector2(1.0f, 0.2f);
            bool grounded = Physics2D.OverlapBox(feet, dimensions, 0, ground);

            if (grounded)
            {
                force.y = 400;
                Debug.Log("spacebar pressed");
            }
        }

    }
    private void FixedUpdate()
    {
        rb.AddForce(force);
        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x, -5, 5), rb.velocity.y);
    }




}


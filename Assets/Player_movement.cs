using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{

   [SerializeField] float speed = 10;
    SpriteRenderer sr;
    [SerializeField] float jumpPower = 200;
    Rigidbody2D rb;
    [SerializeField] LayerMask groundLayer;
    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxisRaw("Horizontal");
        transform.Translate(dir * speed * Time.deltaTime, 0, 0);
        if (dir < 0)
            sr.flipX = true;
        if (dir > 0)
            sr.flipX = false;
        bool jump = Input.GetButtonDown("Jump");
        if (jump && GroundCheck())
            rb.AddForce(Vector3.up * jumpPower);
       
    }
    bool GroundCheck()
    {
        return Physics2D.CapsuleCast(bc.bounds.center, bc.bounds.size,
            0f, 0f, Vector2.down, 0.5f, groundLayer);
    }
}

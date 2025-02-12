using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class S_Player : MonoBehaviour
{
    [SerializeField] float Speed = 1f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] GameObject player;
    [SerializeField] GameObject drill;
   
    SpriteRenderer spriteRender;
    Rigidbody2D rigid;
    Animator anim;

    Vector3 mousePosition;


    void Start()
    {

        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        if (Input.GetKey(KeyCode.Space))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, yInput * jumpForce);
        }
        else
            rigid.velocity = new Vector2(xInput * Speed, rigid.velocity.y);

        if (yInput < 0)
            player.layer = 3;
        else player.layer = 0;

        if (xInput != 0)
        {
            anim.SetBool("move", true);

            if (xInput > 0)
                spriteRender.flipX = true;
            else
                spriteRender.flipX = false;
        }
        else
            anim.SetBool("move", false);

        if (Input.GetMouseButton(0))
        {
            drill.SetActive(true);
            anim.SetBool("dig", true);

            if (mousePosition.x > transform.position.x)
                spriteRender.flipX = true;
            else
                spriteRender.flipX = false;
        
        }
        else
        {
            drill.SetActive(false);
            anim.SetBool("dig", false);
        }
    }

}

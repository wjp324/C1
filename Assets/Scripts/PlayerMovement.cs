using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private float originSpeed = 8f;

    [Header("ÒÆ¶¯²ÎÊý")]
    public float speed;
    public float crouchSpeed;

    [Header("×´Ì¬")]
    public bool isCrouch;

    private float xVelocity;

    Vector2 colliderStandSize;
    Vector2 colliderStandOffset;
    Vector2 colliderCrouchSize;
    Vector2 colliderCrouchOffset;

    // Start is called before the first frame update
    void Start()
    {
        speed = originSpeed;
        crouchSpeed = 3f;

        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();

        colliderStandSize = coll.size;
        colliderStandOffset = coll.offset;
        colliderCrouchSize = new Vector2(coll.size.x, coll.size.y / 2f);
        colliderCrouchOffset = new Vector2(coll.offset.x, coll.offset.y/2f);
    }

    // Update is called once per frame
    void Update()
    {
        GroundMovement();
    }

    void GroundMovement()
    {
        if (Input.GetButton("Crouch")) Crouch();
        else Standup();

        xVelocity = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
        FilpDirction();
    }

    private void FilpDirction()
    {
        transform.localScale = xVelocity < 0 ? new Vector2(-1, 1) : new Vector2(1, 1);
    }

    private void Crouch()
    {
        isCrouch = true;
        speed = crouchSpeed;
        coll.size = colliderCrouchSize;
        coll.offset = colliderCrouchOffset;
    }

    private void Standup()
    {
        isCrouch = false;
        speed = originSpeed;
        coll.size = colliderStandSize;
        coll.offset = colliderStandOffset;
    }
}

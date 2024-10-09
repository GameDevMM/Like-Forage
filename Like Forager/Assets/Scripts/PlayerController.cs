using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody2D;
    private Animator playerAnimator;

    private Vector2 movimentInput;
    private Vector2 mousePosition;

    private bool isLookLeft;
    private bool isWalk;

    public float movimentSpeed;

    void Start()
    {
        playerRigidbody2D = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (mousePosition.x < transform.position.x && isLookLeft == false)
        {
            Flip();
        }

        if (mousePosition.x > transform.position.x && isLookLeft == true)
        {
            Flip();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            playerAnimator.SetTrigger("Axe");
        }

        movimentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isWalk = movimentInput.magnitude != 0;

        playerRigidbody2D.velocity = movimentInput * movimentSpeed;

        playerAnimator.SetBool("isWalk", isWalk);
    }

    private void Flip()
    {
        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, 1, 1);
    }
}

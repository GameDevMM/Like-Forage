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
    private bool isAction;

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

        if(Input.GetButtonDown("Fire1") && isAction == false)
        {
            isAction = true;
            playerAnimator.SetTrigger("Axe");
        }

        movimentInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        isWalk = movimentInput.magnitude != 0;

        if(isAction == false)
        {
            playerRigidbody2D.velocity = movimentInput * movimentSpeed;
        }
        else
        {
            playerRigidbody2D.velocity = Vector2.zero;
            isWalk = false;
        }

        playerAnimator.SetBool("isWalk", isWalk);
    }

    private void Flip()
    {
        if(isAction ==  true)
        {
            return;
        }

        isLookLeft = !isLookLeft;
        float x = transform.localScale.x * -1;
        transform.localScale = new Vector3(x, 1, 1);
    }

    public void AxeHit()
    {

    }

    private void ActionDone()
    {
        isAction = false;
    }
}

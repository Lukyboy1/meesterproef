using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Animator animator;

    private Vector2 moveDirection;
    private Vector2 lookDirection = new Vector2(0,-1);
    public int npcid;
    public bool recipeActive;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.X))
        {
            RaycastHit2D hit = Physics2D.Raycast(rb.position + Vector2.up * 0.2f, lookDirection, 1.5f, LayerMask.GetMask("NPC"));
            if (hit.collider != null)
            {
                DialogueTrigger character = hit.collider.GetComponent<DialogueTrigger>();
                RecipeStart start = hit.collider.GetComponent<RecipeStart>();
                if (character != null)
                {
                    character.TriggerDialogue();
                }
                if (start != null)
                {
                    start.StartRecipe();
                    recipeActive = true;
                }
            }
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
        if (!Mathf.Approximately(moveDirection.x, 0.0f) || !Mathf.Approximately(moveDirection.y, 0.0f))
        {
            lookDirection.Set(moveDirection.x, moveDirection.y);
            lookDirection.Normalize();
        }
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        if (moveDirection.x + moveDirection.y > 1.0f)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed / 1.4f, moveDirection.y * moveSpeed / 1.4f);
        }
        if (moveDirection.x + moveDirection.y < -1.0f)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed / 1.4f, moveDirection.y * moveSpeed / 1.4f);
        }
        if (moveDirection.x + moveDirection.y == 0.0f)
        {
            rb.velocity = new Vector2(moveDirection.x * moveSpeed / 1.4f, moveDirection.y * moveSpeed / 1.4f);
        }
    }
}

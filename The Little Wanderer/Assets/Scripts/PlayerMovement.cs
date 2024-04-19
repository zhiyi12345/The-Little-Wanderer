using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int speed = 4;

    private Vector2 movement;
    private Rigidbody2D rb;
    private Animator animator;
    public static bool playerExists;
    public string startPoint;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void OnMovement(InputValue value)
    {
        if (!PauseResume.isPaused)
        {
            movement = value.Get<Vector2>();
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }

        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);

            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);

        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + speed * movement * Time.fixedDeltaTime);
    }


}
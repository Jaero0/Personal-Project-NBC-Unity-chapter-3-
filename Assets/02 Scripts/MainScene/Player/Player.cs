using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;

    Rigidbody2D rb;
    Animator animator;
    private bool canMove;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canMove = false;
    }

    void EnableMovement() //플레이어가 움직일 수 있는 bool값
    {
        canMove = true;
    }

    void Start()
    {
        Invoke("EnableMovement", 1.2f); //1.2초뒤에 EnableMovement가 호출되며 canMove가 true가 됨.
    }

    void FixedUpdate()
    {
        if (canMove) //canMove가 true가 되면 실행~
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            Move(h, v);
        }
    }

    void Move(float h, float v)
    {
        rb.velocity = new Vector3(h, v, 0).normalized * speed * Time.deltaTime;
    }
}

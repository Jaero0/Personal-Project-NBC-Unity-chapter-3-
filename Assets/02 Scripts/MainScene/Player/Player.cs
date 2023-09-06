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

    void EnableMovement() //�÷��̾ ������ �� �ִ� bool��
    {
        canMove = true;
    }

    void Start()
    {
        Invoke("EnableMovement", 1.2f); //1.2�ʵڿ� EnableMovement�� ȣ��Ǹ� canMove�� true�� ��.
    }

    void FixedUpdate()
    {
        if (canMove) //canMove�� true�� �Ǹ� ����~
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

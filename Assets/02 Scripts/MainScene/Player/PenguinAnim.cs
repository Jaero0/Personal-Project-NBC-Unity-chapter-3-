using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinAnim : MonoBehaviour
{

    Animator animator;
    Rigidbody2D rb;
    //Rigidbody2D rb2;
    //Rigidbody2D rb3;
    //Rigidbody2D rb4;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rb = transform.root.GetComponent<Rigidbody2D>(); //�ֻ��� �θ� ��ü
        //rb2 = GameObject.Find("Player").GetComponent<Rigidbody2D>(); //������Ʈ ã��
        //rb3 = transform.GetComponentInParent<Rigidbody2D>(); //�Ѵܰ� �θ�ü�� ������Ʈ ����
        //rb4 = transform.Parent.GetComponent<Rigidbody2D>(); //�Ѵܰ� �θ�ü�� ������Ʈ ��������
    }

    void Update()
    {
        AnimOn();
    }

    void AnimOn()
    {
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }
    }
}

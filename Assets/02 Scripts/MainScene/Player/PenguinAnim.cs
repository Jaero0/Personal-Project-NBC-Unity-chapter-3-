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
        rb = transform.root.GetComponent<Rigidbody2D>(); //최상위 부모 객체
        //rb2 = GameObject.Find("Player").GetComponent<Rigidbody2D>(); //오브젝트 찾기
        //rb3 = transform.GetComponentInParent<Rigidbody2D>(); //한단계 부모객체의 컴포넌트 참조
        //rb4 = transform.Parent.GetComponent<Rigidbody2D>(); //한단계 부모객체의 컴포넌트 가져오기
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

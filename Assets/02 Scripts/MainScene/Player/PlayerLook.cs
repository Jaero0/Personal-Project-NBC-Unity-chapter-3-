using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerLook : MonoBehaviour
{
    Transform tf;
    SpriteRenderer spRenderer;

    void Start()
    {
        tf = transform;
        spRenderer = transform.Find("Penguin").GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerLookMouse();
    }

    void PlayerLookMouse()
    {
        Vector2 mousePos = Input.mousePosition;

        Vector2 target = Camera.main.ScreenToWorldPoint(mousePos);

        if (target.x < tf.position.x)
        {
            spRenderer.flipX = true;
        }
        else
        {
            spRenderer.flipX = false;
        }
    }
}
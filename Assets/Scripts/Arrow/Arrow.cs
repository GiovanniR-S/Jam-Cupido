using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow:MonoBehaviour
{
    [SerializeField]
    public float spd = 6.5f;

    private GameObject arrow;

    private Collider2D col;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start ()
    {
        col = GetComponent<Collider2D>();

        rb = GetComponent<Rigidbody2D>();

        arrow = GameObject.FindGameObjectWithTag("arrow");

    }

    // Update is called once per frame
    void Update ()
    {
        int bulletX = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX ? -1 : 1;

        transform.Translate(new Vector2(bulletX * 20.0f * Time.deltaTime, 0f));

        GameObject.Destroy(arrow, 0.6f);

    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Cupid 
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField]
        public float spd = 6.5f;

        private GameObject arrow;

        private Collider2D col;
        private Rigidbody2D rb;


        void Start()
        {
            col = GetComponent<Collider2D>();

            rb = GetComponent<Rigidbody2D>();

            arrow = GameObject.FindGameObjectWithTag("arrow");

        }


        void Update()
        {

            int bulletX = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().flipX ? -1 : 1;

            transform.Translate(new Vector2(bulletX * 20.0f * Time.deltaTime, 0f));

            GameObject.Destroy(arrow, 0.6f);

        }

        public void OnCollisionEnter2D(Collision2D collision)
        {

        }
    }
}
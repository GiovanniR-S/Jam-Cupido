using DG.Tweening;
using System;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    [SerializeField]
    float spd;
    [SerializeField]
    int life;

    [SerializeField]
    public GameObject arrowPrefab;

    private Vector2 _movement;
    private Transform tran;
    private Rigidbody2D rb;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spd = 5.0f;
        life = 10;

        tran = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            int bulletX = spr.flipX ? -1 : 1;

            if(GameObject.FindGameObjectsWithTag("arrow").Length < 1)
            {
                GameObject arrowInstance = Instantiate(arrowPrefab, new Vector2(tran.position.x + (0.6f * bulletX), tran.position.y), Quaternion.identity);

            } 
        }
    }

    private void FixedUpdate()
    {
        move(_movement);
    }

    void move(Vector2 dir)
    {
        rb.MovePosition((Vector2)transform.position + (dir * spd * Time.deltaTime));

        if(Input.GetKey(KeyCode.A))
        {
            spr.flipX = true;
        } else if(Input.GetKey(KeyCode.D))
        {
            spr.flipX = false;
        }

    }
}

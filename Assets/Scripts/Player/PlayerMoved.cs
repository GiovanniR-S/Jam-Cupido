using DG.Tweening;
using UnityEngine;

public class PlayerMoved : MonoBehaviour
{
    [SerializeField]
    float spd;
    [SerializeField]
    int life;

    private Vector2 _movement;
    private Rigidbody2D rb;
    private SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        spd = 5.0f;
        life = 10;

        rb = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void FixedUpdate ()
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

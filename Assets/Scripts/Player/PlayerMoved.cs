using DG.Tweening;
using System;
using UnityEngine;


namespace Cupid 
{

    public class PlayerMoved : MonoBehaviour
    {

        /**** PRIVATE FIELDS ****/
        [SerializeField]
        private float _speed;
        [SerializeField]
        private int _life;

        private Vector2 _movement;
        private Transform _tran;
        private Rigidbody2D _rb;
        private SpriteRenderer _spr;


        private float _angle;
        private float _radius;


        /**** PUBLIC FIELDS ****/
        [SerializeField]
        public GameObject _arrowPrefab, _aim;



        void Start()
        {

            /**** INI ****/
            _speed = 5.0f;
            _life = 10;

            _tran = GetComponent<Transform>();
            _rb = GetComponent<Rigidbody2D>();
            _spr = GetComponent<SpriteRenderer>();
        }



        void Update()
        {

            /**** Get current mouse position & direction ****/
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - transform.position;

            /**** Aim angle ****/
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            _aim.transform.rotation = Quaternion.Euler(new(0, 0, angle + 90));
            _aim.transform.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector2(Constants.AIM_DISTANCE,0);
            
            

            /**** Get player movement ****/
            _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));


            /**** Check if player has shot ****/
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {

                /**** Set bullet direction ****/
                int bulletX = _spr.flipX ? -1 : 1;

                if (GameObject.FindGameObjectsWithTag("arrow").Length < 1)
                {

                    GameObject arrowInstance = Instantiate(_arrowPrefab, new Vector2(transform.position.x + (0.6f * bulletX), transform.position.y), Quaternion.identity);

                }
            }


            

        }


        /**** DEBUG ****/
        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawSphere(transform.position, Constants.AIM_DISTANCE);
        }



        private void FixedUpdate()
        {
            move(_movement);
        }



        void move(Vector2 dir)
        {

            _rb.MovePosition((Vector2)transform.position + (_speed * Time.deltaTime * dir));

            if (Input.GetKey(KeyCode.A))
                _spr.flipX = false;
            else if (Input.GetKey(KeyCode.D))
                _spr.flipX = true;

        }

    }

}
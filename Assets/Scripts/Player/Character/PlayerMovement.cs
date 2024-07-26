using System;
using UnityEngine;

namespace Cupid
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        
        [SerializeField] private float speed = 5.0f;

        private void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var vertical = Input.GetAxis("Vertical");
            
            rigidbody2D.velocity = new Vector2(horizontal * speed, vertical * speed);
        }
    }
}
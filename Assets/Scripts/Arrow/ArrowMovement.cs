using System;
using UnityEngine;

namespace Cupid
{
    public class ArrowMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5.0f;

        private void FixedUpdate()
        {
            transform.Translate(Vector2.up * (speed * Time.fixedDeltaTime));
        }
    }
}
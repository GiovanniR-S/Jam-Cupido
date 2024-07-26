using System;
using DG.Tweening;
using UnityEngine;

namespace Cupid
{
    public class HeadMovement : MonoBehaviour
    {
        [SerializeField] private Transform headPivot;
        [SerializeField] private Transform characterTransform; // Transform do personagem principal
        [SerializeField] private Transform aimIndicator; // Transform do indicador de mira
        private Camera _camera;

        // range of the angle is 40 to -50
        [SerializeField] private float minAngleRange = 30;
        [SerializeField] private float maxAngleRange = 135;
        [SerializeField] private float lerpSpeed = 0.5f;

        private void Awake()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            // Pega a posição do mouse na tela e converte para o espaço do mundo
            var mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            
            // Calcula a direção do mouse para o pivô da cabeça
            var direction = mousePosition - headPivot.position;
            
            // Calcula o ângulo em relação ao eixo Y
            var angle = Mathf.Atan2(-direction.x, direction.y) * Mathf.Rad2Deg ;

            // Verifica se o mouse está à esquerda ou à direita do personagem para flipar
            if (mousePosition.x > characterTransform.position.x)
            {
                // Flip para a esquerda
                characterTransform.localScale = new Vector3(-1, 1, 1);
                angle = Mathf.Clamp(angle + 90, minAngleRange, maxAngleRange);
            }
            else
            {
                // Flip para a direita
                characterTransform.localScale = new Vector3(1, 1, 1);
                angle = Mathf.Clamp(angle - 90, minAngleRange, maxAngleRange);
            }

            // Rota o pivô da cabeça para olhar na direção do mouse
            headPivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            
            //aimIndicator.rotation = Quaternion.Euler(new(0, 0, angle + 90));
            //aimIndicator.position = transform.position + Quaternion.Euler(0, 0, angle) * new Vector2(Constants.AIM_DISTANCE,0);

            var rot = Quaternion.Euler(new(0, 0, angle));

            aimIndicator.rotation = Quaternion.Lerp(aimIndicator.rotation, rot, lerpSpeed*Time.deltaTime);
            
            
        }
    }
}
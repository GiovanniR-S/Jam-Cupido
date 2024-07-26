using UnityEngine;

namespace Cupid
{
    public class BodyInertialRotation : MonoBehaviour
    {
        [SerializeField] private new Rigidbody2D rigidbody2D;
        [SerializeField] private Transform pivot; // Ponto de rotação
        [SerializeField] private float rotationSpeed = 5f; // Velocidade da rotação
        [SerializeField] private float maxRotationAngle = 45f; // Ângulo máximo de rotação
        [SerializeField] private float maxSpeed = 10f; // Velocidade máxima esperada

        private void Update()
        {
            // Obter a direção e magnitude da velocidade do Rigidbody2D
            Vector2 velocity = rigidbody2D.velocity;
            float speed = velocity.magnitude;

        
            // Calcular a fração da velocidade em relação à velocidade máxima
            float speedFraction = Mathf.Clamp01(speed / maxSpeed);

            // Determinar a direção da rotação com base na direção do movimento
            float targetAngle = 0f;
            if (velocity.x < 0)
            {
                targetAngle = Mathf.Lerp(0f, maxRotationAngle, speedFraction); // Rotação horária para a direita
            }
            else if (velocity.x > 0)
            {
                targetAngle = Mathf.Lerp(0f, -maxRotationAngle, speedFraction); // Rotação anti-horária para a esquerda
            }

            if (velocity.y < 0)
            {
                targetAngle += Mathf.Lerp(0f, maxRotationAngle, speedFraction) *0.8f; // Rotação horária para cima
            }
            else if (velocity.y > 0)
            {
                targetAngle += Mathf.Lerp(0f, -maxRotationAngle , speedFraction) *0.8f; // Rotação anti-horária para baixo
            }
            
            targetAngle = Mathf.Clamp(targetAngle, -maxRotationAngle, maxRotationAngle);

            // Interpolar suavemente a rotação atual para o ângulo alvo
            float currentAngle = pivot.rotation.eulerAngles.z;
            if (currentAngle > 180f) currentAngle -= 360f; // Corrigir para valores negativos

            float newAngle = Mathf.LerpAngle(currentAngle, targetAngle, rotationSpeed * Time.deltaTime);
            pivot.rotation = Quaternion.Euler(0f, 0f, newAngle);
        
        }
    }
}

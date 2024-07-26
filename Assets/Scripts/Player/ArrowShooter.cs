using UnityEngine;

namespace Cupid
{
    public class ArrowShooter : MonoBehaviour
    {
        [SerializeField] private GameObject arrowPrefab;
        [SerializeField] private Transform spawnPoint;
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var arrow = Instantiate(arrowPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class CountDown : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        public float initialTime = 60 * 3;
        private float currentTime;
        
        public UnityEvent countDownFinishedEvent;
        
        private void Start()
        {
            currentTime = initialTime;
        }
        
        private void Update()
        {
            
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            
            if (currentTime <= 0)
            {
                currentTime = 0;
                countDownFinishedEvent.Invoke();
            }
            
            text.text = $"{(int)currentTime / 60}:{(int)currentTime % 60}";
        }
    }
}
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace BobuTemplate
{
    public class TimeCounter : MonoBehaviour
    {
        public static TimeCounter instance;
        private TMP_Text _timeCounterText;
        [SerializeField] private float timeLeft;

           
        private void Awake()
        {
            _timeCounterText = GetComponent<TMP_Text>();
            instance = this;
        }

        void Update()
        {
           Timee();
        }

        public void Timee()
        {
            
            _timeCounterText.enabled = true;

            timeLeft -= Time.deltaTime;
            
            if (timeLeft<60)
            {
                int secondss = Mathf.FloorToInt(timeLeft % 60f);
                _timeCounterText.text = string.Format("{0:00}", secondss);
                //_timeCounterText.fontSize = 75;
            }
            else
            {
                int minutes = Mathf.FloorToInt(timeLeft / 60f);
                int seconds = Mathf.FloorToInt(timeLeft % 60f);
                // string format int gelen degeri stringe cevirir ve texte atar, text de ekranda yazdirilmasini saglar. 
                _timeCounterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
}

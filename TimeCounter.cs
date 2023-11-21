using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class TimeCounter : MonoBehaviour
{
    private TMP_Text _timeCounterText;
   
    [SerializeField] private float timeLeft;
 
 
 
    
    
    private void Awake()
    {
        _timeCounterText = GetComponent<TMP_Text>();
       
    }

   
  
    void Update()
    {
       Time();
    }

    public void Time()
    {
           // gameObject.SetActive(true);
            _timeCounterText.enabled=true;
        

        /*
            timeLeft -= UnityEngine.Time.deltaTime;
            int minutes = Mathf.FloorToInt(timeLeft / 60f);
            int seconds = Mathf.FloorToInt(timeLeft % 60f);
            // string format int gelen de�eri stringe cevirir ve texte atar, text de ekranda yazdirilmasini saglar. 
            _timeCounterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            */

        timeLeft -= UnityEngine.Time.deltaTime;
        int seconds = Mathf.FloorToInt(timeLeft % 60f);
        _timeCounterText.text = string.Format("{0:00}", seconds);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //thanh thoi gian o man hinh dead
    public Slider timeOfCup;

    public Text timerText;
    public Text timerTextDead;
    public Text timerTextWin;
    float time=0;
    bool run = false;
    float seconds;
    float minutes;
    private void Update()
    {
        if(run)
        {
            UpdateTimerText();
        }
    }
   
    private void UpdateTimerText()
    {
        time= time + Time.deltaTime;
        seconds = (int)(time % 60);
        minutes = (int)((time / 60)%60);

        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        timerTextDead.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        timerTextWin.text = minutes.ToString("00") + ":" + seconds.ToString("00");
        UpdateUITime();
    }
    void UpdateUITime()
    {
        if (time <= 30)
        {
            timeOfCup.value = 1f;
        }
        else if (time <= 60)
        {
            timeOfCup.value = 0.7f;
        }
        else if (time <= 90)
        {
            timeOfCup.value = 0.4f;
        }
        else
        {
            timeOfCup.value = 0f;
        }
        
    }
    public void StartTimer()
    {
        run = true;
    }
    public void stoptimer()
    {
        run = false;
    }
    public void resettimer()
    {
        run = false;
        time = 0;
        UpdateTimerText();
    }
}

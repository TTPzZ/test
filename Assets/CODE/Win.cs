using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject win,hidePlayer,showPlayer;
    public Timer timer;
    public Text time1;
    public Text time2;
    public AudioSource heavenly;
    private void Start()
    {
        //import
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }
    public void ooo()
    {
        //hien man hinh win
        win.SetActive(true);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //cho truoc khi show screen win
        Invoke("ooo", 1f);
        //am thanh khi win
        heavenly.Play();
        //an player o duoi nuoc
        hidePlayer.SetActive(false);
        //hien anim khi win 
        showPlayer.SetActive(true);
        //dung bo dem thoi gian
        timer.stoptimer();
        //gan
        time2.text = time1.text;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    public GameObject win;
    public Timer timer;
    public Text time1;
    public Text time2;
    public AudioSource heavenly;

    private void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        heavenly.Play();
        win.SetActive(true);
        timer.stoptimer();
        time2.text = time1.text;
    }
}

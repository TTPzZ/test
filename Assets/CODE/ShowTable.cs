using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTable : MonoBehaviour
{
    public GameObject Show;
    public GameObject Hide;
     public void delay()
    {
        Show.SetActive(true);
        Hide.SetActive(false);
    }
    public void hehe()
    {
        Invoke("delay", 0.2f);
    }
}

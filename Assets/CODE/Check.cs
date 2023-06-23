using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : MonoBehaviour
{
    public GameObject show;
    public GameObject hide;
    public void setCheck()
    {
        show.SetActive(true);
        hide.SetActive(false);
    }
}

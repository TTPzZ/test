using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMenu : MonoBehaviour
{
    public GameObject Bf, Lt;
    public void resetAn()
    {
        Bf.SetActive(true);
        Lt.SetActive(false);
    }

    public void Clickk()
    {
        Bf.SetActive(false);
        Lt.SetActive(true);
        Invoke("resetAn", 1f);
    }
}

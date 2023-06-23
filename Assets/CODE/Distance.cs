using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{

    public Transform owl;
    public Transform dich;
    public Text khoangcach;
    public void Update()
    {
        float distance=Vector2.Distance(owl.position, dich.position);
        khoangcach.text = distance.ToString("0");
    }

}

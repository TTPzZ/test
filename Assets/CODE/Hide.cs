using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    public GameObject hidePrefab;
    public void hidee()
    {
        hidePrefab.SetActive(false);
    }
}

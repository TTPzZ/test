using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideOwl : MonoBehaviour
{
    public GameObject player1,player2,che;

    public void haizz()
    {
        player1.SetActive(true);
        player2.SetActive(false);
        che.SetActive(false);
    }
    private void Start()
    {
        Invoke("haizz", 2f);
    }
}

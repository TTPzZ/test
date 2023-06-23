using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public GameObject aimBtt, aimBtt2;
    public void gameOver()
    {
        aimBtt.SetActive(false);
        aimBtt2.SetActive(true);
        //Load l?i màn ch?i
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

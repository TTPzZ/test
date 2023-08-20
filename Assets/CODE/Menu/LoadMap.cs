using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMap : MonoBehaviour
{
    //public AudioSource Bep;
    private void Start()
    {
    
    }
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadOption()
    {
        SceneManager.LoadScene("Option");
    }
    //public void LoadAudio()
    //{
     
    //    Bep.Play();
    //}
}

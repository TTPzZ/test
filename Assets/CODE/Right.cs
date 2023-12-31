//t??ng t? nh? Left b�y gi? l� b�n ph?i
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Spine.Unity;

public class Right : MonoBehaviour
{
    bool move = false;
    public Rigidbody2D owl;
    //public float speed = 20;
    public Slider staminaSlider;
    public GameObject GameOverrr;
    public AudioSource dead;

    public SkeletonAnimation HandR;
    public AnimationReferenceAsset surf, swimming;

    public Timer timer;

    public GameObject wavehs;
    public void Start()
    {
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }

    private void FixedUpdate()
    {
        if(move==true)
        {
            owl.AddForce(transform.right * Static.speedSwimming * Time.fixedDeltaTime * 150f, ForceMode2D.Force);
            owl.AddForce(transform.up * Static.speedSwimming * Time.fixedDeltaTime * 150f, ForceMode2D.Force);

            Static.currentStamina -= Static.Giam * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            if (Static.currentStamina <= 0f)
            {
                dead.Play();
                GameOverrr.SetActive(true);
                timer.stoptimer();
            }
            UpdateUI();
            wavehs.SetActive(true);
        }
        else
        {
            Static.currentStamina += Static.Tang * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            //UpdateUI();
            wavehs.SetActive(false);
        }
    }

    void UpdateUI()
    {
        staminaSlider.value= Static.currentStamina /Static.maxStamina;
    }
    //c� th? ??t b?t k� ?�u mi?n sao ??t tr??c h�m g?i n�
    public void setAciton(AnimationReferenceAsset animation, bool loop, float timeScale)
    {
        HandR.state.SetAnimation(0,animation,loop).TimeScale = timeScale;
    }

    public void MoveOwl(bool _move)
    {
        move= _move;
        if (move == true)
        {
            setAciton(swimming, true, 4f);
        }
        else
        {
            setAciton(surf, true, 1f);
        }
    }
}

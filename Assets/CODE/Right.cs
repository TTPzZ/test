//t??ng t? nh? Left bây gi? là bên ph?i
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
        }
        else
        {
            Static.currentStamina += Static.Tang * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        staminaSlider.value= Static.currentStamina /Static.maxStamina;
    }
    //có th? ??t b?t kì ?âu mi?n sao ??t tr??c hàm g?i nó
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

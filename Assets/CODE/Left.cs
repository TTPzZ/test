using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//khai b�o ?? s? d?ng c�c UI c?a Unity
using UnityEngine.UI;
//khai b�o ?? c� th? s? d?ng animation ???c t?o t? spine
using Spine.Unity;

public class Left : MonoBehaviour
{
    //x�c nh?n s? ki?n hold
    bool move = false;
    public Rigidbody2D owl;
    //t?c ?? c?a nh�n v?t sau n�y s? thay b?ng static ?? qu?n l� h�ng lo?t
    //public float speed = 20f;
    //thanh stamina c?a nh�n v?t
    public Slider staminaSlider;
    //thanh thoi gian o man hinh dead
    public Slider timeOfCup;
    //m�n h�nh game over
    public GameObject GameOverrr;
    //�m thanh khi h?t stamina
    public AudioSource dead;
    //ch? th? c?a h�nh ??ng
    public SkeletonAnimation HandL;
    //c�c animation c?a ch? th?
    public AnimationReferenceAsset surf, swimming;
    //??i kh�i l� bi?n t?m cho gi� tr? mu?n tham chi?u ??n
    public Timer timer;
    //an hien song
    public GameObject wavehs;
    public void Start()
    {
        //t�m b?ng tag v� nh?n v�o bi?n t?m t?o ? tr�n
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }
    //h�m ch?y animation
    public void setAction(AnimationReferenceAsset animation,bool loop,float timeScale)
    {
        HandL.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }
    //h�m d�ng ?? g?i v� x�c nh?n li�n t?c c�c logic trong game
    private void FixedUpdate()
    {
        if(move==true)
        {
            //cho nh�n v?t ch?y sang tr�i v?i ?i?u ki?n l� nh�n v?i s? �m
            owl.AddForce(transform.right * Static.speedSwimming * Time.fixedDeltaTime*-150f, ForceMode2D.Force);
            //l�m cho nh�n v?t di chuy?n l�n tr�n
            owl.AddForce(transform.up * Static.speedSwimming * Time.fixedDeltaTime*150f, ForceMode2D.Force);
            //gi?m stamina nh�n v?t khi c� thao t�c nh?n
            Static.currentStamina -= Static.Giam * Time.deltaTime;
            //tr�nh tr??ng h?p x?y ra l?i khi stamina v? qu� 0 ho?c qu� 100
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            //n?u nh? stamina v? 0 th� ch?y s? ki?n nh?m x�c nh?n nh�n v?t ?� dead
            if (Static.currentStamina <= 0f)
            {
                //�m thanh khi ch?t
                dead.Play();    
                //m�n h�nh khi ch?t
                GameOverrr.SetActive(true);
                //th?i gian d?ng l?i khi ch?t
                timer.stoptimer();
                //UpdateUITime();
            } 
            //g?i h�m c?p nh?t stamina
            UpdateStamina();
            wavehs.SetActive(true);
        }
        //khi kh�ng c� s? ki?n nh?n n?a th� h?i l?i th? l?c
        else
        {
            Static.currentStamina += Static.Tang * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            wavehs.SetActive(false);
        }         
    }
    //ham cap nhat thanh thoi gian cua bang dead
    void UpdateUITime()
    {
        timeOfCup.value = 0f;
    }
    //h�m c?p nh?t stamina
    void UpdateStamina()
    {
        staminaSlider.value= Static.currentStamina /Static.maxStamina;
    }
    //khi c� s? ki?n nh?n b?ng trigger th� s? thay ??i gi� tr? c?a move t? false sang true v� ng??c l?i
    public void MoveOwl(bool _move)
    {
        move = _move;
        if (move == true)
        {
            //g?i h�m th?c hi?n h�nh ??ng
            setAction(swimming, true, 4f);
        }
        else
        {
            //t??ng t? h�m tr�n nh?ng g?i s? ki?n surf
            setAction(surf, true, 1f);
        }
    }
}
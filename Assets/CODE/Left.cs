using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//khai báo ?? s? d?ng các UI c?a Unity
using UnityEngine.UI;
//khai báo ?? có th? s? d?ng animation ???c t?o t? spine
using Spine.Unity;

public class Left : MonoBehaviour
{
    //xác nh?n s? ki?n hold
    bool move = false;
    public Rigidbody2D owl;
    //t?c ?? c?a nhân v?t sau này s? thay b?ng static ?? qu?n lí hàng lo?t
    //public float speed = 20f;
    //thanh stamina c?a nhân v?t
    public Slider staminaSlider;
    //thanh thoi gian o man hinh dead
    public Slider timeOfCup;
    //màn hình game over
    public GameObject GameOverrr;
    //âm thanh khi h?t stamina
    public AudioSource dead;
    //ch? th? c?a hành ??ng
    public SkeletonAnimation HandL;
    //các animation c?a ch? th?
    public AnimationReferenceAsset surf, swimming;

    //??i khái là bi?n t?m cho giá tr? mu?n tham chi?u ??n
    public Timer timer;
    public void Start()
    {
        //tìm b?ng tag và nh?n vào bi?n t?m t?o ? trên
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }
    //hàm ch?y animation
    public void setAction(AnimationReferenceAsset animation,bool loop,float timeScale)
    {
        HandL.state.SetAnimation(0, animation, loop).TimeScale = timeScale;
    }
    //hàm dùng ?? g?i và xác nh?n liên t?c các logic trong game
    private void FixedUpdate()
    {
        if(move==true)
        {
            //cho nhân v?t ch?y sang trái v?i ?i?u ki?n là nhân v?i s? âm
            owl.AddForce(transform.right * Static.speedSwimming * Time.fixedDeltaTime*-150f, ForceMode2D.Force);
            //làm cho nhân v?t di chuy?n lên trên
            owl.AddForce(transform.up * Static.speedSwimming * Time.fixedDeltaTime*150f, ForceMode2D.Force);
            //gi?m stamina nhân v?t khi có thao tác nh?n
            Static.currentStamina -= Static.Giam * Time.deltaTime;
            //tránh tr??ng h?p x?y ra l?i khi stamina v? quá 0 ho?c quá 100
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            //n?u nh? stamina v? 0 thì ch?y s? ki?n nh?m xác nh?n nhân v?t ?ã dead
            if (Static.currentStamina <= 0f)
            {
                //âm thanh khi ch?t
                dead.Play();    
                //màn hình khi ch?t
                GameOverrr.SetActive(true);
                //th?i gian d?ng l?i khi ch?t
                timer.stoptimer();
                //UpdateUITime();
            } 
            //g?i hàm c?p nh?t stamina
            UpdateStamina(); 
        }
        //khi không có s? ki?n nh?n n?a thì h?i l?i th? l?c
        else
        {
            Static.currentStamina += Static.Tang * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
   
        }    
        
    }
    //ham cap nhat thanh thoi gian cua bang dead
    void UpdateUITime()
    {
        timeOfCup.value = 0f;
    }
    //hàm c?p nh?t stamina
    void UpdateStamina()
    {
        staminaSlider.value= Static.currentStamina /Static.maxStamina;
    }
    //khi có s? ki?n nh?n b?ng trigger thì s? thay ??i giá tr? c?a move t? false sang true và ng??c l?i
    public void MoveOwl(bool _move)
    {
        move = _move;
        if (move == true)
        {
            //g?i hàm th?c hi?n hành ??ng
            setAction(swimming, true, 4f);
        }
        else
        {
            //t??ng t? hàm trên nh?ng g?i s? ki?n surf
            setAction(surf, true, 1f);
        }
    }
}
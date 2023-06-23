using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    bool move=false;
    //vat li cua con owl
    public Rigidbody2D owl;
    //vat li cua nut hold dau game
    public Rigidbody2D hold;
    //toc do khi bat dau
    public float speed;
    //thanh stamina cua nhan vat
    public Slider staminaSlider;
    //thanh thoi gian o man hinh dead
    public Slider timeOfCup;
    //man hinh game over
    public GameObject GameOverrr;
    // trick stop nhan vat
    public GameObject StopOwl;
    //am thanh thi nhan vat het stamina
    public AudioSource soundDead;
    //thoi gian
    public Timer timer;
    public void Start()
    {
        //import bien time tu tep co tag Jump voi class Timer
        timer = GameObject.FindGameObjectWithTag("Jump").GetComponent<Timer>();
    }
    private void FixedUpdate()
    {
        //khi giu
        if (move==true)
        {
            //cho trong luc cua owl ve 0 de bat dau boi
            owl.gravityScale = 0; 
            //cho owl tien ve phia truoc
            owl.AddForce(transform.up * speed * Time.fixedDeltaTime*10, ForceMode2D.Force);
            //giam stamina khi nhan
            Static.currentStamina -= 55f * Time.deltaTime;
            //ham dung de tranh gay ra loi
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            //khi stamina cua nhan vat tro ve 0
            if (Static.currentStamina <= 0f)
            {
                // hien cac man hinh khi owl dead
                timer.stoptimer();
                soundDead.Play();
                GameOverrr.SetActive(true);
                StopOwl.SetActive(true);
                UpdateUITime();
            }
            //cap nhat lai thanh stamina
            UpdateUI();
        }
        //khi khong giu
        else
        {
            //lam cho nhan vat khong di chuyen nua
            owl.velocity = Vector2.up * 0;
            //tuong tu o tren
            Static.currentStamina += Static.Tang * Time.deltaTime;
            Static.currentStamina = Mathf.Clamp(Static.currentStamina, 0f, Static.maxStamina);
            UpdateUI();
        }
    }
    //ham cap nhat thanh thoi gian cua bang dead
    void UpdateUITime()
    {
        timeOfCup.value = 0f;
    }
    //awake ham luon chay dau tien cua chuong trinh
    public void Awake()
    {
        //lam cho stamina toi da khi bat dau
        Static.currentStamina = Static.maxStamina;
        UpdateUI();
    }

    void UpdateUI()
    {
        staminaSlider.value = Static.currentStamina / Static.maxStamina;
    }
    //theo doi xem nguoi dung dang giu hay khong
    public void MoveOwl(bool _move)
    {
        //thay doi qua lai gia tri cua move
        move = _move;
        if (move == false)
        {
            //lam cho chu hole bi roi xuong
            hold.gravityScale = 10f;
        }
    }
}

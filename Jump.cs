using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    //в инспекторе мы можем выбрать, какие слои будут землёй
    public LayerMask whatIsGround;
    //позиция для проверки касания земли
    public Transform groundCheck;
    //переменная, которая будет true, если крыса находится на земле
    public bool isGrounded;
    //значение величины силы
    public float jumpForce;
    //переменная для скорости движения
    public float speed;
    //ссылочная переменная для компонента Rigidbody2D
    Rigidbody2D rb;

    void Start()
    {
        //делаем ссылку на Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    //я буду использовать Update() для более точного определения прыжка
    void Update()
    {
        //проверка, нажат-ли прыжок и находится-ли крыса на земле
        if (Playrt.mode == 0)
        {
            if ((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGrounded)
            {
                //применяем силу на Rigidbody2D вдоль оси Y для прыжка
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                //переключаем переменную, чтобы предотвратить следующий прыжок, или мы могли бы снова прыгнуть (до того, как isGrounded будет переключена в FixedUpdate ())
                isGrounded = false;
            }
        }
        if(Playrt.mode == 1)
        {
            float flyaxis = Input.GetAxis("FlyAxis") * Time.fixedDeltaTime * 500;
            if (Input.GetAxis("FlyAxis") != 0)
            {
                rb.velocity = new Vector2(0, flyaxis - 1);
                //rb.AddForce(new Vector2(0, Input.GetAxis("FlyAxis") * Time.fixedDeltaTime * 100), ForceMode2D.Force);
            }
        }
    }

    void FixedUpdate()
    {

        //изменяем переменную, зависящую от результата Physics2D.OverlapPoint
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);
        if (Playrt.otherisplatformer)
        {
            //декларация переменной с её инициализацией значением полученным с горизонтальной оси (значение лежит в области между -1 и 1)
            float x = Input.GetAxis("Horizontal");
            //декларация локального вектора и инициализация посчитанным значением
            //x: значение от InputManager * speed
            //y: принять текущее значение, мы не будем его менять, из-за использования силы тяжести
            //z: должно быть равно нулю, нам не нужно движение по оси Z
            Vector3 move = new Vector3(x * speed, rb.velocity.y, 0f);
            //Изменить скорость игрока на вычисленный вектор
            rb.velocity = move;
        }
        
    }
}
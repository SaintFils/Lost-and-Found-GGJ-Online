using System;
using UnityEngine;
using UnityEngine.UI;

//Скрипт позволяющий выводить таймер после получения бонуса двойного прыжка
public class DoubleJumpBonus : MonoBehaviour
{
    [SerializeField] private Text _showTimer; //вывод текста таймера
    [SerializeField] private GameObject _timerBar; //Сам таймер 
    [SerializeField] private float _rayCastDistance = 0.5f;

    private Rigidbody _boy;

    private float _doubleJumpTime = 5;
    public bool _dobleJumpEarned;
    private bool _isGround;
    private bool _ableDoubleJump;

    private void Start()
    {
        _boy = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //UI
        if (_dobleJumpEarned)
        {
            UIDoubleJUmp();
            Invoke("OffTimer", _doubleJumpTime);
        }
        else
        {
            UIDisableDoubleJump();
        }

       //Double Jump
       if (Input.GetKey(KeyCode.Space) && _isGround) // Если игрок нажал на прыжок, и он на земле, тогда прыжок совершается
       {
           _boy.AddForce(transform.up * 1f, ForceMode.Impulse);
           _ableDoubleJump = true;
       }
       else
       {
            if (_ableDoubleJump && Input.GetKey(KeyCode.Space) && _dobleJumpEarned && !_isGround) //Если игрок подобрал бонусный прыжок и нажал на прыжок и переменная с двойным прыжком активна и он находится над землей, тогда он совершает второй прыжок в воздухе
            {
                _boy.AddForce(transform.up * 1f, ForceMode.Impulse);
               _ableDoubleJump = false;
            }

       }

        CheckIsGrounded();
    }


    public void UIDoubleJUmp() // вывод таймера после получения двойного прыжка
    {
        _doubleJumpTime -= Time.deltaTime;
        float x = Convert.ToInt32(_doubleJumpTime);
        _timerBar.SetActive(true);
        _showTimer.text = $"DOUBLE JUMP: {x}";
    }


    private void UIDisableDoubleJump() //выключение таймера после окончания
    {
        _doubleJumpTime = 5;
        _timerBar.SetActive(false);
        _showTimer.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("doubleJump")) //Если игрок ксается объекта с тегом "doubleJump" в нашем случае это бонуска, тогда он и получает возможность прыгать
        {
            _dobleJumpEarned = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("floor")) //Если игрок ксается объекта с тегом "floor", проверка на то находиться ли он на земле
        {
            _isGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _isGround = false;
    }

    public void CheckIsGrounded()
    {
        _isGround = Physics.Raycast(transform.position,Vector3.down, _rayCastDistance);
        Debug.Log(_isGround);
    }


    private void OffTimer() //выключение таймера
    {
        _dobleJumpEarned = false;
    }
}

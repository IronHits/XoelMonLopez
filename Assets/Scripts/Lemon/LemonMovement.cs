using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LemonMovement : MonoBehaviour
{

    //Zona de varaiable globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    //Se guarda la dirección del movimiento
    [SerializeField]
    private Vector3 _direction;

    private Rigidbody _rb;
    private Animator _anim;
    private AudioSource _audioSource;
    private float _horizontal;
    private float _vertical;



    private void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {
        Rotation();

    }

    //Recuerda no se hace en el FixedUpdates
    private void OnAnimatorMove()
    {

        _rb.MovePosition(transform.position + (_direction * _anim.deltaPosition.magnitude));

    }


    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        IsAnimate();
        AudioSteps();

    }

    private void InputsPlayer()
    {

        //Tecla A y D, flecha < >
        _horizontal = Input.GetAxis("Horizontal");
        //Teclas W y S, flechas arriba y abajo
        _vertical = Input.GetAxis("Vertical");
        //Vector3.forward, right, left. new Vector3(x y z)
        _direction = new Vector3(_horizontal, 0.0f, _vertical);

        _direction.Normalize();



    }


    private void IsAnimate()
    {

        if (_horizontal != 0.0f || _vertical != 0.0f)
        {
            _anim.SetBool("IsWalking", true);
        }

        else
        {
            _anim.SetBool("IsWalking", false);


        }
    }

    private void Rotation()
    {

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, _direction, _turnSpeed * Time.deltaTime, 0.0f);
        Quaternion rotation = Quaternion.LookRotation(desiredForward);
        _rb.MoveRotation(rotation);


    }

    //Método para reproducción de audio de pasos de Lemon
    private void AudioSteps()
    {

        if (_horizontal != 0.0f || _vertical != 0.0f)
        {
            if(_audioSource.isPlaying == false)
            {
                _audioSource.Play();
            }
           
        }

        else
        {
            _audioSource.Stop();

        }
    }

}







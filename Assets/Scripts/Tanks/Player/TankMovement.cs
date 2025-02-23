using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{

    //Zona variables globales
    [Header("Movement")]
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _turnSpeed;

    private float _horizontal;
    private float _vertical;   
    private Rigidbody _rb;

    [Header("Sound")]
    [SerializeField]    
    private AudioClip _idleClip;
    [SerializeField]
    private AudioClip _drivenClip;
    private AudioSource _audioSource;



    void Awake()
    {

        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

     
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    // Update is called once per frame
    void Update()
    {

        InputsPlayer();
        AudioPlayer();

    }


    private void InputsPlayer()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    private void Move()
    {
        
        Vector3 direction = transform.forward * _vertical * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + direction);

    }

    private void Turn()
    {

        float turn = _horizontal * _turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, _horizontal, 0.0f);
        _rb.MoveRotation(transform.rotation * turnRotation);

    }


    private void AudioPlayer()
    {

        if (_vertical != 0.0f || _horizontal != 0.0f) //Si se está moviendo
        {
            if (_audioSource.clip != _drivenClip)
            {
                _audioSource.clip = _drivenClip;
                _audioSource.Play();
            }
        }
        else //Si está parado
        {
            if(_audioSource.clip != _idleClip)
            {
                _audioSource.clip = _idleClip;  
                _audioSource.Play();
            }
        }
    }



}

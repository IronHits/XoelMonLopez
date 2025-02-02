using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{

    //Zona variables globales

    [Header("Images")]
    [SerializeField]
    private Image _wonImage;
    [SerializeField]
    private Image _deathImage;
    [Header("Fade")]

    [SerializeField]
    private float _fadeDuration;
    [SerializeField]
    private float _displayImageDuration;
    [SerializeField]    
    private float _timer;


    public bool IsLemonAtExit;
    public bool IsLemonDeath;
    public bool IsRestartLevel;

    



    //Audio
    [Header("Audio")]
    [SerializeField]
    private AudioClip _wonClip;
    [SerializeField]
    private AudioClip _deathClip;
    private AudioSource _audioSource;


    private void Awake()
    {
        
        _audioSource = GetComponent<AudioSource>();

    }


    

    // Update is called once per frame
    void Update()
    {
        
        if(IsLemonAtExit)
        {
            Won();
        }
        else if (IsLemonDeath)
        {
            Death();
        }

    }

    private void Won()
    { 

        _audioSource.clip = _wonClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime; // +=
        //Aumentar canal alfa
        _wonImage.color = new Color(_wonImage.color.r, _wonImage.color.g, _wonImage.color.b, _timer/_fadeDuration);

        //LA imagen permacene un tiempo
        if(_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("He Ganado");
            SceneManager.LoadScene(0);
            
        }

    }

    private void Death()
    {

        _audioSource.clip = _deathClip;
        if (_audioSource.isPlaying == false)
        {
            _audioSource.Play();

        }

        _timer = _timer + Time.deltaTime; // +=
        //Aumentar canal alfa
        _deathImage.color = new Color(_deathImage.color.r, _deathImage.color.g, _deathImage.color.b, _timer / _fadeDuration);

        //LA imagen permacene un tiempo
        if (_timer > _fadeDuration + _displayImageDuration)
        {
            Debug.Log("He Perdido");
            SceneManager.LoadScene(0);


        }
    
    }

    //Lemon detecta el collider de GameManager
    private void OnTriggerEnter(Collider infoAccess)
    {
        if(infoAccess.CompareTag("Lemon"))
        {
            IsLemonAtExit = true;
        }

    }





}

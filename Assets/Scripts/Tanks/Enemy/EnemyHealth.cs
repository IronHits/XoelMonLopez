using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [Header("health")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHeath;
    [SerializeField]
    private float _damageShell;

    [Header("HealthBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosion")]
    [SerializeField]
    private ParticleSystem _smallExplosion;
    [SerializeField]
    private ParticleSystem _bigExplosion;


    // Start is called before the first frame update
    void Awake()
    {
        _smallExplosion.Stop();
        _bigExplosion.Stop();
        _currentHeath = _maxHealth;
        _lifeBar.fillAmount = 1.0f;


    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("Shell"))
        {
            _smallExplosion.Play();
            _currentHeath -= _damageShell;
            _lifeBar.fillAmount = _currentHeath/ _maxHealth;
            Destroy(infoAccess.gameObject);

            if(_currentHeath <= 0.0f)
            {
                Death();
            }
        }
               
    }


    private void Death()
    {
        _bigExplosion.Play();
        Destroy(gameObject,0.5f);

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}

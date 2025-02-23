using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{

    //Zona variables globales
    [Header("TankHealth")]
    [SerializeField]
    private float _maxHealth;
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _damageEnemyShell;

    [Header("ProgressBar")]
    [SerializeField]
    private Image _lifeBar;

    [Header("Explosions")]
    [SerializeField]
    private ParticleSystem _bigExplosion;
    [SerializeField]
    private ParticleSystem _smallExplosion;

    [Header("Game Over")]
    [SerializeField]
    private GameManagerTank _gameManager;
    
    

    
    void Awake()
    {
        _bigExplosion.Stop();
        _smallExplosion.Stop();

        _currentHealth = _maxHealth;
        _lifeBar.fillAmount = 1.0f;

    }

    private void OnTriggerEnter(Collider infoAccess)
    {
        if (infoAccess.CompareTag("ShellEnemy"))
        {
            _smallExplosion.Play();
            _currentHealth -= _damageEnemyShell;
            _lifeBar.fillAmount = _currentHealth / _maxHealth;
            Destroy(infoAccess.gameObject);

            if(_currentHealth <= 0.0f)
            {
                _bigExplosion.Play();
                Death();
            }

        }
    }
   
    private void Death()
    {
        _gameManager.GameOver();

        Destroy(gameObject, 0.5f);
    }
    

  
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class EnemyTankAttack : MonoBehaviour
{

    //Zona variables globales
    [Header("Time")]
    [SerializeField]
    private float _timer;
    [SerializeField]
    private float _timeBetweenAttack;

    private bool _isAttack;

    [Header("Prefab")]
    [SerializeField]
    private Rigidbody _shellEnemyPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private float _factorLaunchForce;

    [Header("Raycast")]
    private Ray _ray;
    private RaycastHit _hit;
    [SerializeField]
    private float _distance;
    

    private void Awake()
    {
        _isAttack = false;
    }

    private void FixedUpdate()
    {
        if (_isAttack)
        {
            Launch();
            _isAttack=false;
        }
    }

    // Update is called once per frame
    void Update()
    {       
        CountTimer();
    }

    private void CountTimer()
    {

        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        _timer += Time.deltaTime;

        if(Physics.Raycast(_ray, out _hit))
        {
            if(_hit.collider.CompareTag("TankPlayer") && _timer >= _timeBetweenAttack)
            {
                _timer = 0.0f;
                _isAttack = true;
                _distance = _hit.distance;

            }
            
            

        }

        

    }

    private void Launch()
    {
        float launchForceFinal = _launchForce * _distance * _factorLaunchForce; 
        Rigidbody cloneShellPrefab = Instantiate(_shellEnemyPrefab, _posShell.position, _posShell.rotation);
        cloneShellPrefab.velocity = _posShell.forward * launchForceFinal;
    }


}

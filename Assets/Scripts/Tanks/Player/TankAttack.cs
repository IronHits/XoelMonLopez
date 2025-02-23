using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    //Zona variables globales
    [SerializeField]
    private Rigidbody _shellPrefab;
    [SerializeField]
    private Transform _posShell;
    [SerializeField]
    private float _launchForce;
    [SerializeField]
    private AudioSource _audioSource;



    // Update is called once per frame
    void Update()
    {
        InputPlayer();
    }

    private void InputPlayer()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Launch();
                    
                 
        }
    }

    private void Launch()
    {
        Rigidbody cloneShellPrefab = Instantiate(_shellPrefab, _posShell.position, _posShell.rotation);

        _audioSource.Play();

        cloneShellPrefab.velocity = _posShell.forward * _launchForce;
    }
}



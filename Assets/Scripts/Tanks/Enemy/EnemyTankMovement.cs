using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankMovement : MonoBehaviour
{
    //Zona variables globales
    [SerializeField]
    private GameObject _player;
    private NavMeshAgent _agent;


    
    void Awake()
    {

        _player = GameObject.FindGameObjectWithTag("TankPlayer");
        _agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(_player == null)
        {
            return;
        }

        GetPlayer();
    }

    private void GetPlayer()
    {
        _agent.SetDestination(_player.transform.position);
    }


}


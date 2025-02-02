using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{

    //Zona variables globales
    [Header("WayPoints")]
    //Array de posiciones
    [SerializeField]
    private Transform[] _positionsArray;
    [SerializeField]
    private float _speed;
    //Almacenar posicion
    private Vector3 _posToGo;
    //Qué posición de Array estoy
    private int _i;
    private Ray _ray;
    private RaycastHit _hit;

    public GameManager GameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        _i = 0;
        _posToGo = _positionsArray[_i].position;

    }

    private void FixedUpdate()
    {

        DetectionLemon();


    }

    // Update is called once per frame
    void Update()
    {

        MoveGhost();
        ChangeMove();
        Rotate();

    }

private void MoveGhost()
    {

        transform.position = Vector3.MoveTowards(transform.position, _posToGo, _speed * Time.deltaTime);

    }

    private void ChangeMove()
    {
        //Si el fantasma llega al destino 2...
        if (Vector3.Distance(transform.position, _posToGo) <= Mathf.Epsilon)
        {
            //Comprobar si estoy en la última casilla del array
            if(_i == _positionsArray.Length - 1)
            {

                //Vuelvo a la casilla inicial
                _i = 0;
            }
            else
            {
                _i++; //_i = _i + i;
            }
       
            _posToGo = _positionsArray[_i].position;
        }

    }

    private void Rotate()
    {
        transform.LookAt(_posToGo);
    }


    private void DetectionLemon()
    {

        //Subir el origen del ray 1m en eje y respecto pivote
        _ray.origin = new Vector3(transform.position.x, transform.position.y + 1.0f, transform.position.z);
        _ray.direction = transform.forward;

        if(Physics.Raycast(_ray, out _hit))
        { 

            if(_hit.collider.CompareTag("Lemon"))
            {
                
                Debug.Log("Te PILLEEE");
                GameManagerScript.IsLemonDeath = true;

            }
            

        }
    }

}

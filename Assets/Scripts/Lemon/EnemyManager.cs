using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour

{

    //Zona de variables globales
    [Header("Instantiate")]
    //Nos pilla el prefab de la gargola
    [SerializeField]
    private GameObject _enemyGarPrefab;
    //Array para las posiciones de instanciado
    [SerializeField]
    private Transform[] _posRotEnemiesArray;
    //LLama a GameManager script para asignarlo en el inspector
    [SerializeField]
    public GameManager GameManagerScript;
    



    // Update is called once per frame
    void Awake()
    {
        
        CreateGarEnemies();

    }


    
     private void CreateGarEnemies()
    {
        for (int i = 0; i < _posRotEnemiesArray.Length; i++)  
        {
            Instantiate(_enemyGarPrefab, _posRotEnemiesArray[i].position, _posRotEnemiesArray[i].rotation);

             
        }
    }

}

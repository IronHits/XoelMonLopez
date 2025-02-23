using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerTank : MonoBehaviour
{

    //Zona variables globales
    [Header("Game Over")]
    [SerializeField]
    private GameObject _panelGameOver;
    [SerializeField]
    private EnemyTankManager _enemyTankManager;
   

   

    public void GameOver()
    {
        _panelGameOver.SetActive(true);
        _enemyTankManager.enabled = false;
    }

    public void LoadSceneLevel()
    {

        SceneManager.LoadScene(1);
    }

    

}

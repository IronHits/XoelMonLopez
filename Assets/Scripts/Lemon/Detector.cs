using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{

    //Zona variables globales
    public GameManager GameManagerScript;


    
    //Busca el script GameManager en la escena
    //Está referenciado en zona de variables para asignarlo en el inspector, pero no funciona
    void Start()
    {
        GameManagerScript = FindObjectOfType<GameManager>();
        
    }


    //Detecta que Lemon toca con Detector
    public void OnTriggerEnter(Collider infoAccess)
    {
        
        if (infoAccess.CompareTag("Lemon"))
        {

            Debug.Log("Te he PILLADO");
            GameManagerScript.IsLemonDeath = true;
    

        }
    }


}

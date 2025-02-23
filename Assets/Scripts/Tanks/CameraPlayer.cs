using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour
{
    //Zona de variable Globales
    public Transform Target;
    [Header("Vectors")]
    //Velocidad de seguimiento
    [SerializeField]
    private float _smoothing;
    //Distancia inicial entre player y c�mara
    [SerializeField]
    private Vector3 _offset;

  

    // Update is called once per frame
    private void LateUpdate()
    {

        //Posici�n a la que queremos la c�mara usando la rotaci�n del player 
        Vector3 desiredPosition = Target.position + (Target.forward * _offset.z) + (Target.right * _offset.x) +
                                  (Target.up * _offset.y);
        //Suavizamos
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

        //Hacemos que la c�mara mire al player
        transform.LookAt(Target.position);
    }
}

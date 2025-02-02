using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLemon : MonoBehaviour
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



    // Start is called before the first frame update
    void Start()
    {
        
        _offset = transform.position - Target.position;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        
        //Posici�n a la que queremos la c�mara y movemos 
        Vector3 desiredPosition = Target.position + _offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothing * Time.deltaTime);

    }
}

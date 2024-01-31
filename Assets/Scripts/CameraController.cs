using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Este script se encarga de controlar la cámara en un Roll a Ball
 */
public class CameraController : MonoBehaviour
{
    public GameObject player;
    
    public GameObject Ground;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // transform.position = player.transform.position + offset +  new Vector3 (12, 3, 22);


		/*
		// Esto es para que la camara se acerque del punto central, la parte 1 del punto 3
		if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
        
		// Esto es para que la camara se aleje del punto central,  la parte 1 del punto 3
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * 10.0f * Time.deltaTime);
        
        //if(Input.GetKey(KeyCode.A))
            //transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        
        //if(Input.GetKey(KeyCode.D))
            //transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
		*/

        // parte 2 del punto 2 sobre un movimiento diferente
        /*
		// Esto es para que la camara se acerque del punto central
		if(Input.GetKey(KeyCode.W)){
            //transform.Translate(Vector3.forward * 10.0f * Time.deltaTime);
			transform.Rotate(transform.up, -player.transform.position.y  * 10f * Time.deltaTime);
        }
		// Esto es para que la camara se aleje del punto central
        if(Input.GetKey(KeyCode.S))
            transform.Translate(-Vector3.forward * 10.0f * Time.deltaTime);
        */
        
        // parte 2 del punto 3
        // Para que la camara se mueva alrededor de la mesa del juego 
        transform.RotateAround(Ground.transform.position, Vector3.up, 20 * Time.deltaTime);
        
    }
}

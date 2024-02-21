using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
/*
 * Este script se encarga de controlar al jugador en un Roll a Ball
 */
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
	
	// variable para el puntaje de la pelota
	private int count;
    
    public float speed = 0;

	// variable para el texto del puntaje
	public TextMeshProUGUI countText;

	// variable para el texto de victoria
	public GameObject winTextObject;

	// para el prefab de los pickups
	public GameObject pickupPrefab;

	public int minPickups = 5; // Minimum number of pickups to spawn
    public int maxPickups = 10; // limite superior de pickups a spawnear

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hola, debugueando");
		count = 0;
		SpawnPickupsRandomly();
		SetCountText();
		winTextObject.SetActive(false);
    }
    int CountPickupsLeft(string tag = "PickUp")
    {
        // Count the number of pickups in the scene
        GameObject[] pickups = GameObject.FindGameObjectsWithTag("PickUp");

        int pickupCount = pickups.Length;
		return pickupCount;
    }
    private void FixedUpdate(){
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
        // Si la bola se sale del plano, se reinicia
        if (transform.position.y < -10){
            transform.position = new Vector3(0, 0.5f, 0);
            rb.velocity = Vector3.zero;
        }
    }
    
    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        Debug.Log(movementVector);
        
        movementX = movementVector.x; 
        movementY = movementVector.y;
        
    }
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
		countText.text = countText.text + "\nStillAlive: " + CountPickupsLeft().ToString();
		if (CountPickupsLeft() == 0)
        {
            winTextObject.SetActive(true);
        }
	}

    /*
     * Este método se encarga de detectar cuando se presiona la barra espaciadora
     */
    void OnFire()
    {
        Debug.Log("Fire!");
    }
	void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("PickUp")){
            other.gameObject.SetActive(false);
			count++;
			SetCountText();
        }
    }

	void SpawnPickupsRandomly()
    {
        int numPickupsToSpawn = Random.Range(minPickups, maxPickups + 1);

        for (int i = 0; i < numPickupsToSpawn; i++)
        {
            // Random position within a certain range (you can adjust as needed)
            Vector3 spawnPosition = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));

            Instantiate(pickupPrefab, spawnPosition, Quaternion.identity);
        }
    }

}

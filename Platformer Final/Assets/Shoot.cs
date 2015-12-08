using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	//variables
	public Transform firePoint;
	public GameObject projectile;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.X)) {
		Instantiate(projectile, firePoint.position, firePoint.rotation);



		}
 

	}
}

using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public GameObject currentCheckPoint;
	private Controller2D player;

	//Respawn Delay
	public float respawnDelay;

	//Store Gravity Value
	private float gravityStore;

	// Particles
	public GameObject deathParticle;
	public GameObject respawnParticle;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<Controller2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void RespawnPlayer(){
		StartCoroutine ("RespawnPlayerCo");
	}
	
	public IEnumerator RespawnPlayerCo(){
	//Generate Death Particle
	//Instantiate (DestroyParticle, player.transform.position, player.transform.rotation);
	//Hide Player
	player.enabled = false;
	player.GetComponent<Renderer> ().enabled = false;
	// Gravity Reset
	//gravityStore = player.GetComponent<Rigidbody2D>().gravityScale;
	player.GetComponent<Rigidbody2D>().gravityScale = 0f;
	player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
	// Point Penalty
	//ScoreManager.AddPoints(-pointPenaltyOnDeath);
	//Debug Message
	Debug.Log ("Player Respawn");
	//Respawn Delay
	yield return new WaitForSeconds (respawnDelay);
	//Gravity Restore
	player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
	//Match Players transform position
	player.transform.position = currentCheckPoint.transform.position;
	//Show Player
	player.enabled = true;
	player.GetComponent<Renderer> ().enabled = true;
	//Spawn Player
	Instantiate (respawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Enablegames;

public class Collectible : MonoBehaviour {

	EGGameManager game;
	// Use this for initialization
	void Start () {
		game = GameObject.Find ("GameLogic").GetComponent<EGGameManager> ();
		enabled = true;
	}

	void CreateCollectible()
	{
		Quaternion rot = Quaternion.identity;//FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = Vector3.zero;//contact.point;
		pos.x = (Random.value-0.5f)*10.0f;pos.y=2.0f;pos.z=1f;
		Collectible cs=Instantiate (collectible, pos, rot).gameObject.GetComponent<Collectible>();
		cs.collectible = collectible;  //hack because Unity bug makes prefab reference the instance 
	}
	// Update is called once per frame
	void Update () {
        transform.Rotate(1, 0, 0);
		//Debug.Log ("pos=" + this.transform.position);
		if (this.transform.position.y < -1.5f) {   //Collectible missed
			game.score--;
	        Tracker.Instance.Message(new TrackerMessage("Object Missed", string.Format("XPos: {0} ; YPos: {1}", this.transform.position.x.ToString(),  this.transform.position.y.ToString())));
	        Tracker.Instance.Message(new TrackerMessage("Object Missed", string.Format("Score: {0}", game.score.ToString())));
			this.gameObject.GetComponent<AudioSource> ().Play ();
			CreateCollectible ();
			Destroy (gameObject);
		}	
	}
	public GameObject collectible;

    void OnCollisionEnter(Collision collision)
    {
		Debug.Log ("Collectible hit!");
		game.score+=10;
        Tracker.Instance.Message(new TrackerMessage("Object Collected", string.Format("XPos: {0} ; YPos: {1}", this.transform.position.x.ToString(),  this.transform.position.y.ToString())));
        Tracker.Instance.Message(new TrackerMessage("Object Collected", string.Format("Score: {0}", game.score.ToString())));
		this.gameObject.GetComponent<AudioSource> ().Play ();
		CreateCollectible();
		Destroy(gameObject);

    }
}

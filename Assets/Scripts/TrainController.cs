using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void TrainElimination(){
		Destroy (gameObject);
	}

	
	void OnTriggerEnter2D( Collider2D other )
	{
		if (other.CompareTag ("House")) {
			Destroy (gameObject);
			TrainCreatorController.numberOfTrains--;
		}
	}
}


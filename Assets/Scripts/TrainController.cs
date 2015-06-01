using UnityEngine;
using System.Collections;

public class TrainController : MonoBehaviour {
	private float speed = 1.0f;
	private Vector3 currentPosition;
	private Vector3 moveToward;
	private Vector3 distance;
	// Use this for initialization
	void Start () {
		currentPosition = transform.position;
		moveToward = new Vector3(0, currentPosition.y, currentPosition.z);
		distance = moveToward - currentPosition;
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = transform.position;
		transform.position = distance / speed * Time.deltaTime + currentPosition;
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


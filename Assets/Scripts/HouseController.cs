using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {
	private int count = 0;
	private Vector3 currentPosition;
	private Vector3 moveToward;
	private float speed;

	// Use this for initialization
	void Start () {		
		currentPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		PolygonCollider2D coll = GetComponent<PolygonCollider2D> ();
		coll.isTrigger = true;
		coll.enabled = true;
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		count++;
		Debug.Log("Hit " + count);
		if (other.CompareTag ("Train") || other.CompareTag ("Car") || other.CompareTag ("Truck")) {
//			currentPosition = transform.position;
//			moveToward = new Vector3(-10, currentPosition.y, currentPosition.z);
//			transform.position = moveToward;
//			GetComponent<Animator>().SetBool( "IsTouched", true );
			StartCoroutine(Shake(0.5f));
			
		}
	}

	IEnumerator Shake(float waitTime){
		float endTime = Time.time + waitTime;
		while (Time.time < endTime) {
//			Debug.Log ("Shake");
			moveToward = new Vector3(-0.4f, currentPosition.y, currentPosition.z);
			transform.position = moveToward;
//			Debug.Log ("x " + transform.position.x + " y " + transform.position.y + " z " + transform.position.z);
			yield return new WaitForSeconds(0.04f);

			moveToward = new Vector3(0.4f, currentPosition.y, currentPosition.z);
			transform.position = moveToward;
			yield return new WaitForSeconds(0.04f);
		}
		moveToward = new Vector3(0, currentPosition.y, currentPosition.z);

//		GetComponent<Animator>().SetBool( "IsTouched", false );
	}
}

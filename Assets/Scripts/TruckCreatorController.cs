using UnityEngine;
using System.Collections;

public class TruckCreatorController: MonoBehaviour {
	public float minSpawnTime = 2f; 
	public float maxSpawnTime = 5f; 
	private float startTime;
	private float pastTime;
	public static int numberOfTrucks = 0;
	
	public GameObject truckPrefab;
	public GameObject truckReversePrefab;

	private bool started = false;

	void Start () 
	{
		
	}

	void Update(){
		if (CreatorManagerController.createTruck == true && started == false){
			started = true;
			startTime = Time.time;
			Invoke("SpawnTruck",minSpawnTime);

		}
		else if (CreatorManagerController.createTruck == false && started == true){
			started = false;
		}
	}
	
	void SpawnTruck() {
		Camera camera = Camera.main;
		//		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		Vector3 truckPos = 
			new Vector3(xMax,
			            0,
			            0);
		
		Instantiate(truckPrefab, truckPos, Quaternion.identity);
		pastTime = Time.time - startTime;
		pastTime = 1 + pastTime / 20;
		if (numberOfTrucks < 25) {
			//			Invoke ("SpawnTrain", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			
			Invoke ("SpawnTruck", 1f);
			
			numberOfTrucks++;
			Debug.Log ("number of trucks after spawn " + numberOfTrucks);
		} else {
			StartCoroutine(WaitForLessTrucks());
		}
	}
	
	IEnumerator WaitForLessTrucks(){
		while (numberOfTrucks >= 25) {
			yield return new WaitForSeconds(0.1f);
			
		}
		Invoke ("SpawnTruck", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
	}
}
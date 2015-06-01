using UnityEngine;
using System.Collections;

public class CarCreatorController: MonoBehaviour {
	public float minSpawnTime = 2f; 
	public float maxSpawnTime = 5f; 
	private float startTime;
	private float pastTime;
	public static int numberOfCars = 0;
	
	public GameObject carPrefab;
	public GameObject carReversePrefab;

	private bool started = false;

	void Start () 
	{
		
	}

	void Update(){
		if (CreatorManagerController.createCar == true && started == false){
			started = true;
			startTime = Time.time;
			Invoke("SpawnCar",minSpawnTime);

		}
		else if (CreatorManagerController.createCar == false && started == true){
			started = false;
		}
	}
	
	void SpawnCar() {
		Camera camera = Camera.main;
		//		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		Vector3 carPos = 
			new Vector3(xMax,
			            0,
			            0);
		
		Instantiate(carPrefab, carPos, Quaternion.identity);
		pastTime = Time.time - startTime;
		pastTime = 1 + pastTime / 20;
		if (numberOfCars < 25) {
			//			Invoke ("SpawnCar", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			
			Invoke ("SpawnCar", 1f);
			
			numberOfCars++;
			Debug.Log ("number of cars after spawn " + numberOfCars);
		} else {
			StartCoroutine(WaitForLessCars());
		}
	}
	
	IEnumerator WaitForLessCars(){
		while (numberOfCars >= 25) {
			yield return new WaitForSeconds(0.1f);
			
		}
		Invoke ("SpawnCar", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
	}
}
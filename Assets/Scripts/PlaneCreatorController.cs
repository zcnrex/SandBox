using UnityEngine;
using System.Collections;

public class PlaneCreatorController: MonoBehaviour {
	public float minSpawnTime = 2f; 
	public float maxSpawnTime = 5f; 
	private float startTime;
	private float pastTime;
	public static int numberOfPlanes = 0;
	
	public GameObject planePrefab;
	public GameObject planeReversePrefab;

	private bool started = false;

	void Start () 
	{
		
	}

	void Update(){
		if (CreatorManagerController.createPlane == true && started == false){
			started = true;
			startTime = Time.time;
			Invoke("SpawnPlane",minSpawnTime);

		}
		else if (CreatorManagerController.createPlane == false && started == true){
			started = false;
		}
	}
	void SpawnPlane() {
		Camera camera = Camera.main;
		//		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize;
		
		Vector3 planePos = 
			new Vector3(xMax,
			            yMax / 2,
			            0);
		
		Instantiate(planePrefab, planePos, Quaternion.identity);
		pastTime = Time.time - startTime;
		pastTime = 1 + pastTime / 20;
		if (numberOfPlanes < 25) {
			//			Invoke ("SpawnTrain", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			
			Invoke ("SpawnTrain", 1f);
			
			numberOfPlanes++;
			Debug.Log ("number of planes after spawn " + numberOfPlanes);
		} else {
			StartCoroutine(WaitForLessPlanes());
		}
	}
	
	IEnumerator WaitForLessPlanes(){
		while (numberOfPlanes >= 25) {
			yield return new WaitForSeconds(0.1f);
			
		}
		Invoke ("SpawnPlane", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
	}
}
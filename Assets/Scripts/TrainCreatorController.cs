using UnityEngine;
using System.Collections;

public class TrainCreatorController: MonoBehaviour {
	public float minSpawnTime = 2f; 
	public float maxSpawnTime = 5f; 
	private float startTime;
	private float pastTime;
	public static int numberOfTrains = 0;
	
	public GameObject trainPrefab;
	public GameObject trainReversePrefab;
	
	void Start () 
	{
		startTime = Time.time;
		Invoke("SpawnTrain",minSpawnTime);
	}
	
	void SpawnTrain() {
		Camera camera = Camera.main;
		//		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		Vector3 trainPos = 
			new Vector3(xMax,
			            0,
			            0);
		
		Instantiate(trainPrefab, trainPos, Quaternion.identity);
		pastTime = Time.time - startTime;
		pastTime = 1 + pastTime / 20;
		if (numberOfTrains < 25) {
//			Invoke ("SpawnReverseTrain", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			
//			Invoke ("SpawnReverseTrain", 10f);

			numberOfTrains++;
			Debug.Log ("number of trains after spawn " + numberOfTrains);
		} else {
			StartCoroutine(WaitForLessBubbles());
		}
	}

	
	void SpawnReverseTrain() {
		Camera camera = Camera.main;
		//		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = camera.aspect * camera.orthographicSize * 1.75f;
		float yMax = camera.orthographicSize - 0.5f;
		
		Vector3 trainReversePos = 
			new Vector3(-xMax,
			            0,
			            0);
		
		Instantiate(trainReversePrefab, trainReversePos, Quaternion.identity);
		pastTime = Time.time - startTime;
		pastTime = 1 + pastTime / 20;
		if (numberOfTrains < 25) {
//			Invoke ("SpawnTrain", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			
//			Invoke ("SpawnTrain", 10f);
			
			numberOfTrains++;
			Debug.Log ("number of reversed trains after spawn " + numberOfTrains);
		} else {
			StartCoroutine(WaitForLessBubbles());
		}
	}

	IEnumerator WaitForLessBubbles(){
		while (numberOfTrains >= 25) {
			yield return new WaitForSeconds(0.1f);
			
		}
		Invoke ("SpawnTrain", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
	}
}
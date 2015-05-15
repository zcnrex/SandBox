using UnityEngine;
using System.Collections;

public class TrainCreatorController: MonoBehaviour {
	public float minSpawnTime = 2f; 
	public float maxSpawnTime = 5f; 
	private float startTime;
	private float pastTime;
	public static int numberOfTrains = 0;
	
	public GameObject trainPrefab;
	
	void Start () 
	{
		startTime = Time.time;
		Invoke("SpawnBubble",minSpawnTime);
	}
	
	void SpawnBubble() {
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
			Invoke ("SpawnBubble", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
			numberOfTrains++;
			Debug.Log ("number of bubbles after spawn " + numberOfTrains);
		} else {
			StartCoroutine(WaitForLessBubbles());
		}
	}
	
	IEnumerator WaitForLessBubbles(){
		while (numberOfTrains >= 25) {
			yield return new WaitForSeconds(0.1f);
			
		}
		Invoke ("SpawnBubble", Random.Range (minSpawnTime / pastTime, maxSpawnTime / pastTime));
	}
}
﻿using UnityEngine;
using System.Collections;

public class HouseController : MonoBehaviour {
	private int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D( Collider2D other )
	{
		count++;
		Debug.Log("Hit " + count);
		if (other.CompareTag ("Train")) {
			GetComponent<Animator>().SetBool( "IsTouched", true );
			StartCoroutine(Shake(0.5f));
			
		}
	}

	IEnumerator Shake(float waitTime){
		float endTime = Time.time + waitTime;
		while (Time.time < endTime) {
			yield return new WaitForSeconds(waitTime);
			
		}
		GetComponent<Animator>().SetBool( "IsTouched", false );
	}
}

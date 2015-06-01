using UnityEngine;
using System.Collections;

public class SwipeController : MonoBehaviour {
	private Touch initialTouch = new Touch();
	private float distance = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		foreach (Touch t in Input.touches) {
			if (t.phase == TouchPhase.Began) {
				initialTouch = t;
			}
			else if (t.phase == TouchPhase.Moved){
				float deltaX = initialTouch.position.x - t.position.x;
				float deltaY = initialTouch.position.y - t.position.y;

				distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY + deltaY));
				bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

				if (distance > 100f){

				}
			}
			else if (t.phase == TouchPhase.Ended){
				initialTouch = new Touch();
			}
		}
	
	}
}

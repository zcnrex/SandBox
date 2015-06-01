using UnityEngine;
using System.Collections;

public class CreatorManagerController : MonoBehaviour {
	public bool Train = false;
	public bool Plane = false;
	public bool Truck = false;
	public bool Car = false;

	public static bool createTrain;
	public static bool createPlane;
	public static bool createTruck;
	public static bool createCar; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		createTrain = Train;
		createPlane = Plane;
		createTruck = Truck;
		createCar = Car; 
	}
}

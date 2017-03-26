using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iten2 : MonoBehaviour {
	public GameObject FreeCarpreFab;
	public GameObject coinPrefab;
	public GameObject conePreFab;
	private int startPos = -160;
	private int goalPos = 120;
	private float posRange = -3.4f;
	private GameObject Unity;
	private GameObject LastItem;

	public void ItemCreate(){
			int num = Random.Range (0, 10);
			if (num <= 1) {
				for (float j = -1; j <= 1; j += 0.4f) {
					GameObject cone = Instantiate (conePreFab) as GameObject;
					cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, 0);
				}
			} else {
				for (int j = -1; j < 2; j++) {
					int item = Random.Range (1, 11);
					int offsetZ = Random.Range (-5, 6);
					if (1 <= item && item <= 6) {
						GameObject coin = Instantiate (coinPrefab) as GameObject;
						coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, offsetZ);
					} else if (7 <= item && item <= 9) {
						GameObject car = Instantiate (FreeCarpreFab) as GameObject;
						car.transform.position = new Vector3 (posRange * j, car.transform.position.y, offsetZ);
					}
				}
			}
		}

	// Use this for initialization
	void Start () {
		Unity = GameObject.Find("unitychan");
		float UPosZ = Unity.transform.position.z;

	}
		
	void Update () {
	}
}


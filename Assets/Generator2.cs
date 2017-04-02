using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator2 : MonoBehaviour {
	public GameObject FreeCarpreFab;
	public GameObject coinPrefab;
	public GameObject conePreFab;
	private GameObject unity;
	private float LastItem;
	private float posRange = -3.4f;
	private float GenItem;
	private GameObject items;
	private float run = 0;
	private float lastposition;
	//生成開始位置をUnityちゃん＋５０で設定する。書くのはタブナップデート
	//unityちゃんの位置を取得する。そこからプラス５０の位置でアイテムを作る
	//アイテム出現関数みたいなの必要？

	void ItemGenerator(){
		int num = Random.Range (0, 10);
		if (num <= 1) {
			for (float j = -1; j <= 1; j += 0.4f) {
				GameObject cone = Instantiate (conePreFab) as GameObject;
				cone.transform.position = new Vector3 (4 * j, cone.transform.position.y, lastposition+50);
				LastItem = cone.transform.position.z;
			}
		} else {
			for (int j = -1; j < 2; j++) {
				int item = Random.Range (1, 11);
				int offsetZ = Random.Range (-5, 6);
				if (1 <= item && item <= 6) {
					GameObject coin = Instantiate (coinPrefab) as GameObject;
					coin.transform.position = new Vector3 (posRange * j, coin.transform.position.y, lastposition+50);
					LastItem = coin.transform.position.z;
				} else if (7 <= item && item <= 9) {
					GameObject car = Instantiate (FreeCarpreFab) as GameObject;
					car.transform.position = new Vector3 (posRange * j, car.transform.position.y, lastposition+50);
					LastItem = car.transform.position.z;
				}
			}
		}
	}

	// Use this for initialization
	void Start () {
		unity = GameObject.Find("unitychan");
		LastItem = unity.transform.position.z;
		lastposition = unity.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		run += unity.transform.position.z - lastposition;
		lastposition = unity.transform.position.z;
		//Debug.Log (unity);


		//GenItem = unity.transform.position.z + ;
		if (run > 15) {
			ItemGenerator ();
			run = 0;
		}
	}
}


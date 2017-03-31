using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iten2 : MonoBehaviour {
	
	private GameObject Unity;

	//Unityちゃんの位置から−20くらいの位置でオブジェクトを破棄する。

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		Unity = GameObject.Find ("unitychan");
		float deadline = Unity.transform.position.z;

		if (gameObject.transform.position.z + 20 <  deadline) {
			Destroy (gameObject);
		}
	}
}



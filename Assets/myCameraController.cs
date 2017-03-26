using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCameraController : MonoBehaviour {
	private GameObject UnityChan;
	private float difference;
	// Use this for initialization
	void Start () {
		UnityChan = GameObject.Find ("unitychan"); //Unityちゃんえお見つけて
		difference = UnityChan.transform.position.z - transform.position.z;//距離＝Unityちゃんz軸の変化に伴いながらZ軸を変化させる
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (0, transform.position.y, UnityChan.transform.position.z - difference);
	}//毎フレームで位置を変化させて。y軸の変化、ユニティちゃんの変化に追従する
}


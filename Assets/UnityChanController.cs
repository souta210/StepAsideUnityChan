using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class UnityChanController : MonoBehaviour {

	private Animator myAnimator;
	private Rigidbody myRigidbody;
	private float forwardForce = 800.0f;
	private float turnForce = 500.0f;
	private float upForce = 500.0f;
	private float movableRange = 3.4f;
	private float coefficient = 0.95f;
	private bool isEnd = false;
	private GameObject stateText;
	private GameObject ScoreText;
	private int score = 0;
	private bool isLButtonDown = false;
	private bool isRButtonDown = false;

	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		myRigidbody = GetComponent<Rigidbody> ();

		myAnimator.SetFloat ("Speed", 1);
		stateText = GameObject.Find ("GameResultText");
		ScoreText = GameObject.Find ("ScoreText");
	}
	
	// Update is called once per frame
	void Update () {
		myRigidbody.AddForce (transform.forward * forwardForce);

		if ((Input.GetKey (KeyCode.LeftArrow)) && -movableRange < transform.position.x) {
			myRigidbody.AddForce (-turnForce, 0, 0);
		} else if ((Input.GetKey (KeyCode.RightArrow)) && transform.position.x < movableRange) {
			myRigidbody.AddForce (turnForce, 0, 0);
		}

		if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName ("Jump")) {
			this.myAnimator.SetBool ("Jump", false);
		}
		if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5f) {
			this.myAnimator.SetBool ("Jump", true);
			this.myRigidbody.AddForce (this.transform.up * this.upForce);
		}
		if (this.isEnd) {
			this.forwardForce *= this.coefficient;
			this.turnForce *= this.coefficient;
			this.upForce *= this.coefficient;
			this.myAnimator.speed *= this.coefficient;
		}
		if ((Input.GetKey (KeyCode.LeftArrow) || isLButtonDown) && -movableRange < transform.position.x) {
			myRigidbody.AddForce (-turnForce, 0, 0);
		} else if ((Input.GetKey (KeyCode.RightArrow) || isRButtonDown) && transform.position.x < movableRange) {
			myRigidbody.AddForce (turnForce, 0, 0);
		} 

		
	}
	//ぶつかった時
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficCornTag") {
			this.isEnd = true;
			stateText.GetComponent<Text> ().text = "GAME OVER";
		}
		if (other.gameObject.tag == "GoalTag") {
			this.isEnd = true;
			stateText.GetComponent<Text> ().text = "CLEAR";
		}
		if (other.gameObject.tag == "CoinTag") {
			score += 10;
			ScoreText.GetComponent<Text> ().text = "Score" + score + "pt";
			Destroy (other.gameObject);
			GetComponent<ParticleSystem> ().Play ();
		}
	}
	public void GetMyJumpButtonDown() {
			if (this.transform.position.y < 0.5f) {
				this.myAnimator.SetBool ("Jump", true);
				this.myRigidbody.AddForce (this.transform.up * this.upForce);
	}
}
		public void GetMyLeftButtonDown() {
			this.isLButtonDown = true;
		}
		public void GetMyLeftButtonUp() {
			this.isLButtonDown = false;
		}
		public void GetMyRightButtonDown() {
			this.isRButtonDown = true;
		}
		public void GetMyRightButtonUp() {
			this.isRButtonDown = false;
		}
	public void OnBecameInvisible(){
		Destroy (gameObject);
	}

	}

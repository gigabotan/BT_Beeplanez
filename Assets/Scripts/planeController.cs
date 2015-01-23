using UnityEngine;
using System.Collections;

public class planeController : MonoBehaviour {

	private float speed = 20;
	private float speeddecrease = .005f;
	private float turnspeed = 10f;
	private Vector3 daunV = new Vector3(0f,-5f,0f);
	float currSpeed = 0;
	private bool onGround = true;

	// Use this for initialization
	void Start () {
		this.transform.position = new Vector3 (-21f, -13f, 0f);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (!onGround) {
			this.transform.position = new Vector3 (-21f, -13f, 0f);
			this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
			currSpeed = 0;
			onGround = true;
		}
	}

	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f,(-Input.GetAxis("Horizontal")*turnspeed*(.2f + (currSpeed*2/5))));

		currSpeed += Input.GetAxis ("Vertical") * Time.deltaTime - speeddecrease;

		currSpeed = Mathf.Max (0, currSpeed);
		currSpeed = Mathf.Min (1, currSpeed);

		if (transform.position.y > -11f)
						onGround = false;


		transform.position += transform.right * currSpeed*.5f;

		if (transform.position.y > -12.5f) {
			transform.position += (daunV * Time.deltaTime) / (currSpeed * .9f + .9f);
		}

		//rigidbody2D.velocity = Vector2.MoveTowards(rigidbody2D.velocity,(transform.right*Input.GetAxis("Vertical")*speed*10) + ((daunV)/(currSpeed+.001f)),Time.fixedDeltaTime*2);


		if (Mathf.Abs (transform.position.x) > 40f) {
			transform.position = new Vector3(-(transform.position.x),transform.position.y,transform.position.z);		
		}
	}


	void FixedUpdate() {


	}
}

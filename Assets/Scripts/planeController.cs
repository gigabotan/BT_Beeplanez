using UnityEngine;
using System.Collections;

public class planeController : MonoBehaviour {

	private float speed = 20f;
	private float speeddecrease = -.005f;
	private float turnspeed = 10f;
	private Vector3 daunV = new Vector3(0f,-5f,0f);
	public float currSpeed = 0f;
	private bool onGround = true;
	public float health;
	public float death = -1f;
	public GameObject piu;
	private float attspeed = 1;
	private float atttime = 1;
	public GameObject spwn;
	// Use this for initialization
	void Start () {
		respawn();
	}

	void respawn() {
		death++;
		this.transform.position = new Vector3 (-21f, -13f, 0f);
		this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
		currSpeed = 0f;
		onGround = true;
		health = 5f;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (!onGround) {
			respawn();
		}
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "piu_piu") {
			health--;
			if(health < 1) {
				respawn();
			}
		} else {
			respawn();
		}
	}

	// Update is called once per frame
	void Update () {
		transform.rotation *= Quaternion.Euler(0f, 0f,(-Input.GetAxis("Horizontal")*turnspeed*(.2f + (currSpeed*2/5))));
		if (transform.position.y < 20f) {
			currSpeed += Input.GetAxis ("Vertical") * Time.deltaTime;
		}
			currSpeed += speeddecrease;
			currSpeed = Mathf.Max (0, currSpeed);
			currSpeed = Mathf.Min (1, currSpeed);
		


		if (transform.position.y > -12f)
						onGround = false;


		transform.position += transform.right * currSpeed* Time.deltaTime* 50f;

		if (!onGround) {
			transform.position += (daunV * Time.deltaTime) / (currSpeed * .9f + .9f);
		}

		//rigidbody2D.velocity = Vector2.MoveTowards(rigidbody2D.velocity,(transform.right*Input.GetAxis("Vertical")*speed*10) + ((daunV)/(currSpeed+.001f)),Time.fixedDeltaTime*2);


		if (Mathf.Abs (transform.position.x) > 40f) {
			transform.position = new Vector3(-(transform.position.x),transform.position.y,transform.position.z);		
		}



		if (!onGround && Input.GetKey (KeyCode.Space) && ((Time.time - atttime) * (attspeed + 3f)) > 2f) {
			Instantiate(piu, spwn.transform.position, this.transform.rotation);
			atttime = Time.time;
		}
	}


	void FixedUpdate() {


	}
}

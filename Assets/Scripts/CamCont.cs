using UnityEngine;
using System.Collections;

public class CamCont : MonoBehaviour {

	public GameObject plane;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// камера начинает двигаться за самолетиком игрока
		this.transform.position = new Vector3 ((plane.transform.position.x/3f),plane.transform.position.y/3f, -10f);
	}
}

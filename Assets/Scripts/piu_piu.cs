using UnityEngine;
using System.Collections;

public class piu_piu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f);
	}
	// Update is called once per frame
	void Update () {

		transform.position += transform.right * 80f * Time.deltaTime;

		if (transform.position.y < -13f || Mathf.Abs(transform.position.x) > 40f ) {
			Destroy(this.gameObject, 0.001f);
		}
	}
}

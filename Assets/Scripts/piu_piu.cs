using UnityEngine;
using System.Collections;

public class piu_piu : MonoBehaviour {
	private float speed = 80f;
	// Use this for initialization

	public void left(){
			speed = -80f;
	}

	void Start () {
		Destroy (this.gameObject, 2f); //уничтожает эту пульку, если она летит более двух секунд
	}
	// Update is called once per frame
	void Update () {
		// перемещение пульки вперед
		transform.position += transform.right * Time.deltaTime*speed;

		// если пулька врезалась в землю или улетела за пределы карты, то уничтожается почти мгновенно
		if (transform.position.y < -13f || Mathf.Abs(transform.position.x) > 40f ) {
			Destroy(this.gameObject, 0.001f);
		}
	}
}

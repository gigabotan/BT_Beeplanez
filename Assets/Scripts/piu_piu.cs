using UnityEngine;
using System.Collections;

public class piu_piu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, 2f); //уничтожает эту пульку, если она летит более двух секунд
	}
	// Update is called once per frame
	void Update () {
		// перемещение пульки вперед
		transform.position += transform.right * 80f * Time.deltaTime;

		// если пулька врезалась в землю или улетела за пределы карты, то уничтожается почти мгновенно
		if (transform.position.y < -13f || Mathf.Abs(transform.position.x) > 40f ) {
			Destroy(this.gameObject, 0.001f);
		}
	}
}

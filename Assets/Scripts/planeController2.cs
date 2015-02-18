using UnityEngine;
using System.Collections;

public class planeController2 : MonoBehaviour {
	
	private float maxspeed = 30f; // скорость
	private float speeddecrease = -.005f; // уменьшение скорость
	private float turnspeed = 10f; // скорость поворота
	private Vector3 daunV = new Vector3(0f,-2f,0f); // вектор гравитации
	public float currSpeed = 0f; // текущая скорость
	private bool onGround = true; // летает или нет
	public float health; // количество жизней
	public float death = -1f;// количество смертей, после старта произойдет респаун и количество смертей будет 0
	public GameObject piu; // сама пулька
	private float attspeed = 1; // скорострельность
	private float atttime = 1; // когда была выпущена последняя пулька
	public GameObject spwn; // точка, откуда вылетают пульки
	
	
	// Use this for initialization
	void Start () {
		respawn();
	}
	
	void respawn() {// респавнит самолетик
		death++; // увеличивает количество смертей
		this.transform.position = new Vector3 (21f, -13f, 0f); // начальная позиция
		this.transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, 0f)); // начальный угол
		currSpeed = 0f; // сбрасывает скорость
		onGround = true; // говорит, что самолетик на земле, чтоб он не взорвался снова
		health = 5f; // количество жизней пополняется до максимума
	}
	
	void OnCollisionEnter2D(Collision2D coll) { // если самелетик врезался в землю
		if (!onGround && coll.gameObject.tag != "plane") { // если уже взлетел, то true
			respawn();  // происходит респаун
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) { // если встретился с триггером (пульки, например)
		if (col.tag == "piu_piu") { // если это пулька
			health--; // отнимаем один хп
			if(health < 1) { // если хп меньше одного
				respawn(); //респауним
			}
		} else { // если это не пулька, то
			respawn(); // респаун
		}
	}
	
	// Update is called once per frame
	void Update () { 
		
		// тут прописан поворот самолетика, зависит от текущей скорости
		transform.rotation *= Quaternion.Euler(0f, 0f,(-Input.GetAxis("P2hor")*turnspeed*(.2f + (currSpeed*2/5))));
		
		
		if (transform.position.y < 20f) {  // если самолетик улетел слишком высоко, то мы теряем управление
			currSpeed += Input.GetAxis ("P2vert") * Time.deltaTime; // тут прописано увеличение скорости
		}
		currSpeed += speeddecrease; // тут постоянное уменьшение скорости
		currSpeed = Mathf.Max (0, currSpeed); // проверка на то, чтоб скорость не была слишком маленькой
		currSpeed = Mathf.Min (1, currSpeed); // проверка на то, чтоб скорость не была слишком высокой
		
		
		
		if (transform.position.y > -12f) // если самолетик взлетел, то говорим, что он уже не на земле.
			onGround = false;
		
		
		transform.position -= transform.right * currSpeed* Time.deltaTime* maxspeed; // тут перемещаем вамолетик вперед
		
		if (!onGround) { // если самолет уже взлетел, то на него начинает действовать гравитация
			transform.position += (daunV * Time.deltaTime) / (currSpeed * .9f + .9f);
			
		}
		
		
		if (Mathf.Abs (transform.position.x) > 40f) { //если самолетик вылетел за пределы карты, то он появится с другой стороны
			transform.position = new Vector3(-(transform.position.x),transform.position.y,transform.position.z);		
		}
		
		
		// тут прописана атака и скорострельность
		if (!onGround && Input.GetKey (KeyCode.RightControl) && ((Time.time - atttime) * (attspeed + 3f)) > 2f) {
			GameObject tmp = Instantiate(piu, spwn.transform.position, this.transform.rotation) as GameObject;
			tmp.SendMessage("left");
			atttime = Time.time;
		}
	}
	
	
	void FixedUpdate() {
		
		
	}
}

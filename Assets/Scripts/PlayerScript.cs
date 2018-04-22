using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float velocidade;
	public float impulso;
	Animator animator;
	public GameObject player;
	public Camera cam;
	public int vida;

	//Transform eh o unico  componente do Sensor (GameObject)
	public Transform chaoVerificador;
	bool estaoNoChao;

//	SpriteRenderer spriteRender;
	Rigidbody2D rb;
	Vector3 posicaoInicialCamera;

	float intervalo = 0.9f;
	// Use this for initialization
	void Start () {
		//Interface para os componentes
//		spriteRender = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D> ();
		animator = player.GetComponent<Animator> ();	
		posicaoInicialCamera = cam.transform.position;
	}

	// Update is called once per frame
	void Update () {

		//Mover
		float mover_x = Input.GetAxisRaw("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate (mover_x, 0.0f, 0.0f);

		//Verificar colisao com o chao
		estaoNoChao = Physics2D.Linecast(transform.position, 
			chaoVerificador.position, 
			1 << LayerMask.NameToLayer("Piso"));
		//print (estaoNoChao);

		//Pular
		if (Input.GetButtonDown ("Jump") && estaoNoChao == true) {
			pular();
//		 
		}

		//Orientacao
		if (Input.GetAxisRaw("Horizontal") > 0){
			player.transform.eulerAngles = new Vector2 (0.0f, 0.0f);
//			spriteRender.flipX = false;
		} else if (Input.GetAxisRaw("Horizontal") < 0){
			player.transform.eulerAngles = new Vector2 (0.0f, 180.0f);
//			spriteRender.flipX = true;
		}

//		//Reproduz animacao
		animator.SetFloat("pMover", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
		animator.SetBool("pPular", estaoNoChao);
		animator.SetBool ("pFire", Input.GetButton("Fire1"));

		//Camera
		cam.transform.position = new Vector3(transform.position.x, cam.transform.position.y, cam.transform.position.z);
	}

	/*
	void OnCollisionEnter2D(Collision2D c){
		//Subtrai vida quando for atingido pelo projetil
		if (c.gameObject.tag == "SubInimigo") {
			vida--;
			StartCoroutine (perdeSangue());
			//personagem morre quando encerrar suas vidas
			if (vida <= 0) {
				Destroy (gameObject);
			}
		}
	} */





	void pular(){
			rb.velocity = new Vector2 (0.0f, impulso);
		}



	IEnumerator perdeSangue(){


		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (intervalo);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (intervalo); 


	}

	

}
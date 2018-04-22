using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoScript : MonoBehaviour {

	public int vidas;
	public GameObject peixePrefab;
	public Transform gerarPeixes;
	public float intervalo;

	//Transformou o metodo start em uma corotine
	IEnumerator Start () {
		Instantiate (peixePrefab, gerarPeixes.position, gerarPeixes.rotation);
		yield return new WaitForSeconds (intervalo);
		StartCoroutine (Start ());
	}

	void OnCollisionEnter2D(Collision2D c){
		//Subtrai vida quando for atingido pelo projetil
		if (c.gameObject.tag == "projetil") {
			vidas--;
			//Destroi o inimigo quando encerrar as vidas
			if (vidas <= 0) {
				Destroy (gameObject);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubInimigoScript : MonoBehaviour {

    public GameObject alvo;
    public float velocidade;

	void Start () {
        // Atribui o alvo a ser perseguido
        alvo = GameObject.FindGameObjectWithTag("Player");         
	}
		
	void Update () {
		
        // Persegue o alvo
        transform.position = Vector2.Lerp(
            transform.position, alvo.transform.position, 
            velocidade * Time.deltaTime
            );

	}

	void OnCollisionEnter2D(Collision2D c){
		if (c.gameObject.tag == "projetil") {
			Destroy (gameObject);
			Destroy (c.gameObject);
			}
		}
	}


	/*
	void OnTriggerEnter2D(Collider2D c){
		
		//como o peixinho eh trigger nao precisa colocar c.gameobject.tag
		if (c.gameObject.tag == "projetil") {
			print ("passei aqui");
			Destroy (gameObject);
			Destroy(c.gameObject);

		}
	}*/


		


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mati : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D target){
		if (target.gameObject.tag == "musuh" || target.gameObject.tag == "Enemy") { 
			Die(); 
		}
	}

	void Die(){	
     
	GameObject jalan = GameObject.Find("Fungsi"); 
    FungsiGame spawn = (FungsiGame)jalan.GetComponent(typeof(FungsiGame));
	spawn.pindah(); 	    	
    Destroy (gameObject);

	}
}

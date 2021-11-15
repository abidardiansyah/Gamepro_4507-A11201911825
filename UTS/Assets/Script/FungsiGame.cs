using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FungsiGame : MonoBehaviour
{
    public int respawnTime=2;
    public void Respawning(){
        StartCoroutine(DelayedRespawn()); //menjalankan coroutine, yaitu untuk delay execution script
    }
    // Start is called before the first frame update
    IEnumerator DelayedRespawn(){
		yield return new WaitForSeconds(respawnTime); //delay bbrp second sesuai variabel
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //untuk load scene ulang, load pada scene yg active
	}
}

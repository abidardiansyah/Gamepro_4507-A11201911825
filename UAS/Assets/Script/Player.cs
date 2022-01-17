using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour {

	public float speed = 10f;
	public Vector2 maxVelocity = new Vector2(3, 5);
	public bool standing;
	public float jetSpeed = 15f;
	public float airSpeedMultiplier = .3f;
	
	public float attackSpeed = 0.5f;
	public float coolDown;
	public float bulletSpeed = 500;
    public float yValue = 1f; // perkiraan posisi muncul peluru pada y
    public float xValue = 0.2f; // perkiraan posisi muncul peluru pada x

	public float bulletPos; //posisi arah terbang peluru ada di kanan atau kiri
	public GameObject shootPos; //letak munculnya peluru terhadap gameobject

	public Rigidbody2D bulletPrefab; //objek peluru yg dimaksud
	
	private Animator animator; //untuk animasi

	void Start(){
		animator = GetComponent<Animator> ();
		bulletPos=1;
	} 

	// Update is called once per frame
	void Update () {
		var forceX = 0f;
		var forceY = 0f;

		var absVelX = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x); //mengambil posisi x karakter skrg
		var absVelY = Mathf.Abs (GetComponent<Rigidbody2D>().velocity.y);
		float h = CrossPlatformInputManager.GetAxis("Horizontal"); //ambil nilai kontrol untuk gerakan horizontal
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		bool shoot = CrossPlatformInputManager.GetButtonDown("Jump"); //ambil nilai kontrol untuk tombol jump

		 if(Time.time >= coolDown) //cooldown tembakan
         {
             if(shoot) //jika button ditekan
             {
                 Fire();
             }
         }
		
		if (absVelY < .2f) { //mengetahui sedang terbang atau tidak, untuk membatasi animasinya nanti
			standing = true;
		} else {
			standing = false;
		}

		if (v>0) {
			if(absVelY < maxVelocity.y) //agar terbangnya memiliki batas percepatan
				forceY = jetSpeed * v;
		}
		
		if (h>0) {

			if(absVelX < maxVelocity.x) //agar jalanny memiliki batas percepatan
				forceX = speed;

			transform.localScale = new Vector3(1, 1, 1);
			animator.SetInteger ("AnimState", 1); //animasikan jalan
			bulletPos = 1; //letak arah terbang peluru ke kanan

		} else if (h<0) {

			if(absVelX < maxVelocity.x)
				forceX = -speed;

			transform.localScale = new Vector3(-1, 1, 1); //flip gambar krn sdg jalan ke kiri
			animator.SetInteger ("AnimState", 1);
			bulletPos = -1; //letak arah terbang peluru ke kiri
		} else{
			animator.SetInteger ("AnimState", 0);
		}
		GetComponent<Rigidbody2D>().AddForce (new Vector2 (forceX, forceY)); //jalan & terbang terhadap kecepatan forceX & forceY
	}
	
	void Fire(){
		//memunculkan peluru pada posisi gameobject shootpos
        Rigidbody2D bPrefab = Instantiate(bulletPrefab, shootPos.transform.position, shootPos.transform.rotation) as Rigidbody2D;
		//memberikan dorongan peluru sebesar bulletSpeed dengan arah terbangnya bulletPos 
		bPrefab.GetComponent<Rigidbody2D>().AddForce(new Vector2 (bulletPos * bulletSpeed, 0));
		//counting cooldown, nanti dicek lagi
        coolDown = Time.time + attackSpeed;
     }
 }

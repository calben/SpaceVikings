using UnityEngine;
using System.Collections;

public class Mine : MonoBehaviour {
	public Transform explosionEffect;
	public int explosionForce;
	public int explosionRadius;
	void OnCollisionEnter()
  {
		print("Mine triggered!");

		// Create temporary sphere trigger for explosive force
		// Apply force and damage to all objects in range of explosion

		Collider[] hitColliders = Physics.OverlapSphere(Vector3.zero, 15.0f);
		int i = 0;
		while (i < hitColliders.Length) {
//			hitColliders[i].SendMessage("AddDamage");
			hitColliders[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce, this.transform.position, explosionRadius, 3.0F);
			//Debug.Log ("MINE HITTING: "+hitColliders[i].gameObject.name);
			i++;
		}

		Debug.Log ("YEP");
		// Trigger explosion animation
		//StartCoroutine(waitForExplosion()); //this will run your timer
		Instantiate(explosionEffect, this.transform.position,Quaternion.identity);

		// Delete mine object
		waitForExplosion ();
		//Debug.Log ("IM DYING");
		Destroy (gameObject);
	}
	
	IEnumerator waitForExplosion() {
		yield return new WaitForSeconds(5); //this will wait 5 seconds
	}
}

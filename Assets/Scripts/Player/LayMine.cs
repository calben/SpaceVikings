using UnityEngine;
using System.Collections;

public class LayMine : MonoBehaviour {
	public Transform mine;
	void Update() {
		if (Input.GetKeyDown(KeyCode.Space)) {
			print("space key was pressed");
			Instantiate(mine, transform.position, Quaternion.identity);

		}
	}
}
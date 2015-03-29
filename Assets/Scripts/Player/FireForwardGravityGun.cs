using UnityEngine;
using System.Collections;

public class FireForwardGravityGun : MonoBehaviour
{

  public float forwardGunCooldown = 10.0f;
  public float forwardGunCooldownTmp = 10.0f;
  public GameObject gravityGunProjectile;
  public float distanceFromPlayer = 50f;

  void FireGun()
  {
    GameObject sphere = (GameObject)Instantiate(gravityGunProjectile, this.transform.position + this.distanceFromPlayer * this.transform.forward, Quaternion.identity);
  }

  void Update()
  {
    this.forwardGunCooldownTmp += Time.deltaTime;
    if (Input.GetKey(KeyCode.F))
    {
      if (this.forwardGunCooldownTmp > this.forwardGunCooldown)
      {
        FireGun();
        this.forwardGunCooldownTmp = 0;
      }
    }
  }
}

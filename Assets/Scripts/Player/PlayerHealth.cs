using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

  public float health = 100.0f;
  public float damageMultiplier = 1.0f;
  public bool debug = true;


  public Texture2D bgImage;
  public Texture2D fgImage;

  public float healthBarLength;

  void Start()
  {
    healthBarLength = Screen.width / 3;
  }

  void OnGUI()
  {
    healthBarLength = (Screen.width / 3) * (this.health / (float)100);
    GUI.BeginGroup(new Rect(0, 0, healthBarLength, 32));
    GUI.Box(new Rect(0, 0, healthBarLength, 32), bgImage);
    GUI.BeginGroup(new Rect(0, 0, this.health / 100 * healthBarLength, 32));
    GUI.Box(new Rect(0, 0, healthBarLength, 32), fgImage);
    GUI.EndGroup();
    GUI.EndGroup();
  }
  void OnCollisionEnter(Collision collision)
  {
    if (debug)
    {
      Debug.Log("Player hit collider with magnitude of " + collision.relativeVelocity.magnitude);
    }
    this.health -= collision.relativeVelocity.magnitude;
  }

}

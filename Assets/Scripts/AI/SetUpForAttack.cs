using UnityEngine;
using System.Collections;

public class SetUpForAttack : MonoBehaviour
{

  public GameObject agent;
  public Vector3 goalPosition;
  public Quaternion goalRotation;
  public float preferredShootingDistanceFromPlayer = 10.0f;
  public float preferredShootAngleFromPlayer = 90.0f;

  void Start()
  {
    agent = this.gameObject.transform.parent.gameObject;
  }

  void Update()
  {

  }

  void OnCollisionStay(Collision collisionInfo)
  {
    foreach (Collision col in collisionInfo)
    {
      GameObject obj = col.collider.gameObject;
      if (obj.tag == "Player")
      {
        this.goalPosition = MakeGoalPositionFromPlayerPosition(obj.transform.position);
        break;
      }
    }
  }

  Vector3 MakeGoalPositionFromPlayerPosition(Vector3 playerPosition)
  {
    Vector3 v = Vector3.zero;
    return v;
  }

}

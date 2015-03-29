using UnityEngine;
using System.Collections;

public class SetUpForAttack : MonoBehaviour
{

  public GameObject agent;
  public Vector3 goalPosition;
  public Vector3 goalForward;
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
        this.goalForward = MakeGoalForwardFromPlayerPosition(obj.transform.position);
        break;
      }
    }
  }

  Vector3 MakeGoalPositionFromPlayerPosition(Vector3 playerPosition)
  {
    Vector3 diff = playerPosition - this.gameObject.transform.position;
    if (diff.magnitude < 25)
    {
      return this.gameObject.transform.position;
    }
    else
    {
      Vector3 goal = playerPosition + diff.normalized * (diff.magnitude - 25);
      return goal;
    }
  }

  Vector3 MakeGoalForwardFromPlayerPosition(Vector3 playerPosition)
  {
    float rotation_x = 0;
    float rotation_y = 0;
    float rotation_z = 0;
    Vector3 diff = playerPosition - this.goalPosition;
    float cosphi = Vector3.Dot(this.gameObject.transform.up, diff.normalized);
    float costheta = Vector3.Dot(this.gameObject.transform.forward, diff.normalized);
    if (Mathf.Abs(cosphi) > .5)
    {
      bool right = diff.z > 0;
      if (cosphi > 0)
      {
        rotation_x = Mathf.PI / 3 - Mathf.Acos(cosphi);
      }
      else
      {
        rotation_x = Mathf.PI / 3 * 2 - Mathf.Acos(cosphi);
      }
      if (right)
      {
        rotation_x = -rotation_x;
      }
    }
    if (Mathf.Abs(costheta) > .5)
    {
      bool right = diff.z > 0;
      if (costheta > 0)
      {
        rotation_y = Mathf.PI / 3 - Mathf.Acos(costheta);
      }
      else
      {
        rotation_y = Mathf.PI / 3 * 2 - Mathf.Acos(costheta);
      }
      if (!right)
      {
        rotation_y = -rotation_y;
      }
    }
    Vector3 v = new Vector3(rotation_x * 180 / Mathf.PI, rotation_y * 180 / Mathf.PI, rotation_z * 180 / Mathf.PI);
    return v;
  }

}

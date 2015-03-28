using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateRandomMapObjects : MonoBehaviour
{

  public GameObject a;
  public GameObject b;
  public GameObject c;
  public GameObject d;
  public int numberOfCubes;
  public int min, max;
  public string layer;
  public Color cubecolor;

  public void PlaceCubes()
  {
    for (int i = 0; i < numberOfCubes; i++)
    {
      GameObject aobj = (GameObject)Instantiate(a, GeneratePosition(), GenerateQuaternion());
      GameObject bobj = (GameObject)Instantiate(b, GeneratePosition(), GenerateQuaternion());
      GameObject cobj = (GameObject)Instantiate(c, GeneratePosition(), GenerateQuaternion());
      GameObject dobj = (GameObject)Instantiate(d, GeneratePosition(), GenerateQuaternion());
      GameObject[] objs = new GameObject[] { aobj, bobj, cobj, dobj };
      foreach (GameObject obj in objs)
      {
        obj.AddComponent<MeshCollider>();
        obj.GetComponent<MeshCollider>().convex = true;
        obj.AddComponent<Rigidbody>();
        obj.GetComponent<Rigidbody>().mass = 5;
      }
    }
  }

  Vector3 GeneratePosition()
  {
    int x, y, z;
    x = UnityEngine.Random.Range(min, max);
    y = UnityEngine.Random.Range(min, max);
    z = UnityEngine.Random.Range(min, max);
    return new Vector3(x, y, z);
  }

  Quaternion GenerateQuaternion()
  {
    Quaternion quat = new Quaternion();
    quat.w = UnityEngine.Random.Range(0, 180);
    quat.x = UnityEngine.Random.Range(0, 180);
    quat.y = UnityEngine.Random.Range(0, 180);
    quat.z = UnityEngine.Random.Range(0, 180);
    return quat;
  }

  void Awake()
  {
    PlaceCubes();
  }

}

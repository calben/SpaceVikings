using UnityEngine;
using System.Collections;
using GamepadInput;

public class FadeOutScreens : MonoBehaviour
{

  public GameObject current;
  GameObject next;

  GameObject start;
  GameObject goals;
  GameObject buttons;

  public float timer = 10.0f;

  void Start()
  {

  }

  void Update()
  {
    if(Time.time > timer)
    {
      this.gameObject.SetActive(false);
    }
  }
}

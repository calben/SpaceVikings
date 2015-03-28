using UnityEngine;
using System.Collections;
using GamepadInput;
using UnityEngine.UI;

public class ShowButtons : MonoBehaviour
{

  void Update()
  {
    if (GamePad.GetButtonDown(GamePad.Button.Back, GamePad.Index.One))
    {
      this.GetComponent<RawImage>().enabled = !this.GetComponent<RawImage>().enabled;
    }
  }
}

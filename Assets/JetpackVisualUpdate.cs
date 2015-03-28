using UnityEngine;
using System.Collections;

public class JetpackVisualUpdate : MonoBehaviour
{

    public float glowMultiplier = 1.0f;
    Shader jetpackShader;

    void Start()
    {
    }

    void Update()
    {
        float mod = this.transform.parent.gameObject.GetComponent<Thrusters>().thrusterTimeAvailable / this.transform.parent.gameObject.GetComponent<Thrusters>().maxThrusterTime;
        this.gameObject.GetComponent<Renderer>().material.color = new Color(mod, 0f, 0f, 0.6f);
    }

}

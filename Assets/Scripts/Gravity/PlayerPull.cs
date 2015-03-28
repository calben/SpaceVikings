using UnityEngine;
using System.Collections;

public class PlayerPull : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public float width = 0.2f;
    public float maxDistance = 50f;
    public float gravityStrengthMultiplier = 1.0f;
    public float triggerSensitivity = 0.20f;
    public Color color = Color.green;

    void Start()
    {
        this.lineRenderer = this.gameObject.GetComponent<LineRenderer>();
        this.lineRenderer.enabled = false;
        this.lineRenderer.SetWidth(this.width, this.width);
    }

    void FixedUpdate()
    {
        if (this.GetComponent<RigidbodyNetworkedPlayerController>().gamepadState.RightTrigger > this.triggerSensitivity)
        {
            RaycastHit hit;
            Ray rayFromCam = new Ray(this.GetComponent<RigidbodyNetworkedPlayerController>().myCamera.transform.position, this.GetComponent<RigidbodyNetworkedPlayerController>().myCamera.transform.forward);
            if (Physics.Raycast(rayFromCam, out hit, this.maxDistance))
            {
                Debug.Log("HIT!");
                this.lineRenderer.SetColors(color, color);
                this.lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, this.transform.position);
                lineRenderer.SetPosition(1, hit.point);
                this.GetComponent<Rigidbody>().AddForce((hit.collider.gameObject.transform.position - this.gameObject.transform.position).normalized * this.gravityStrengthMultiplier * Time.deltaTime, ForceMode.Impulse);
                hit.collider.gameObject.GetComponent<Rigidbody>().AddForce((this.gameObject.transform.position - hit.collider.gameObject.transform.position).normalized * this.gravityStrengthMultiplier * Time.deltaTime, ForceMode.Impulse);
            }
            else
            {
                this.lineRenderer.enabled = false;
            }
        }
    }
}

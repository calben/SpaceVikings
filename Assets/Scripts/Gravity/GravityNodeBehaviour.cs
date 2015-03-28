using UnityEngine;
using System.Collections;

public enum GravityNodeType { Push, Pull, Lift }
public enum DistanceRelationship { None, Linear }
public enum NodeColliderType { Radial, Box, Custom };

public class GravityNodeBehaviour : MonoBehaviour
{

    public float magnitudeBirth;
    public float magnitudeDeath;
    public float magnitudeRatio;
    public float radiusBirth;
    public float radiusDeath;
    public float radiusRatio;
    public GravityNodeType gravityType;
    public NodeColliderType colliderType;
    public DistanceRelationship distanceType;

    public bool timed;
    public bool affectEverything;
    public float duration;

    public float currentMagnitude;


    void Awake()
    {
        switch (colliderType)
        {
            case NodeColliderType.Radial:
                if (this.GetComponent<SphereCollider>() == null)
                    this.gameObject.AddComponent<SphereCollider>();
                this.GetComponent<SphereCollider>().radius = this.radiusBirth;
                this.GetComponent<SphereCollider>().isTrigger = true;
                break;
            case NodeColliderType.Box:
                this.gameObject.AddComponent<BoxCollider>();
                break;
            case NodeColliderType.Custom:
                break;
        }
        currentMagnitude = magnitudeBirth;
    }

    /// <summary>
    /// FOR NOW ONLY SPHERE COLLIDER WORKS, THIS IS PROBLEMATIC
    /// </summary>
    void FixedUpdate()
    {
        if (timed)
        {
            this.gameObject.GetComponent<SphereCollider>().radius = Mathf.Lerp(magnitudeBirth, magnitudeDeath, radiusRatio * Time.deltaTime);
            currentMagnitude = Mathf.Lerp(radiusBirth, radiusDeath, radiusRatio * Time.deltaTime);
            duration -= Time.deltaTime;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Rigidbody>().useGravity)
        {
            Vector3 direction = Vector3.Normalize(other.transform.position - this.transform.position);
            switch (gravityType)
            {
                case GravityNodeType.Lift:
                    switch (distanceType)
                    {
                        case DistanceRelationship.Linear:
                            other.GetComponent<Rigidbody>().AddForce(Vector3.up * (currentMagnitude / Vector3.Magnitude(other.transform.position - this.transform.position)), ForceMode.Impulse);
                            break;
                        case DistanceRelationship.None:
                            other.GetComponent<Rigidbody>().AddForce(Vector3.up * (currentMagnitude), ForceMode.Impulse);
                            break;
                    }
                    break;
                case GravityNodeType.Pull:
                    switch (distanceType)
                    {
                        case DistanceRelationship.Linear:
                            other.GetComponent<Rigidbody>().AddForce(direction * (-1 * currentMagnitude / Vector3.Magnitude(other.transform.position - this.transform.position)), ForceMode.Impulse);
                            break;
                        case DistanceRelationship.None:
                            other.GetComponent<Rigidbody>().AddForce(direction * (-1 * currentMagnitude), ForceMode.Impulse);
                            break;
                    }
                    break;
                case GravityNodeType.Push:
                    switch (distanceType)
                    {
                        case DistanceRelationship.Linear:
                            other.GetComponent<Rigidbody>().AddForce(direction * (currentMagnitude / Vector3.Magnitude(other.transform.position - this.transform.position)), ForceMode.Impulse);
                            break;
                        case DistanceRelationship.None:
                            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * (currentMagnitude), ForceMode.Impulse);
                            break;
                    }
                    break;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    private GameObject PathParentObject;
    private Transform targetPathNode;
    private int pathNodeIndex = 0;

    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        PathParentObject = GameObject.Find("Path");
    }

    // Update is called once per frame
    void Update()
    {
        if (targetPathNode == null)
        {
            GetNextPathNode();
            if (targetPathNode == null)
            {
                pathNodeIndex = 0;
                GetNextPathNode();
            }
        }

        Vector3 directionVector = targetPathNode.position - this.transform.localPosition;
        float distanceThisFrame = Speed * Time.deltaTime;

        if (directionVector.magnitude <= distanceThisFrame)
        {
            targetPathNode = null;
        }
        else
        {
            transform.Translate(directionVector.normalized * distanceThisFrame, Space.World);
            Quaternion rotation = Quaternion.LookRotation(directionVector, Vector3.forward);
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation, rotation, Time.deltaTime / 2);
        }
    }

    void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y ,0);
    }

    void GetNextPathNode()
    {
        targetPathNode = PathParentObject.transform.GetChild(pathNodeIndex);
        pathNodeIndex++;
    }
}

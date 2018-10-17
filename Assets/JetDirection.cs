using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetDirection : MonoBehaviour
{
    private GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Ship");
    }

    // Update is called once per frame
    void Update()
    {
        if (playerShip != null)
        {
            Vector3 directionVector = playerShip.transform.position - this.transform.localPosition;
            transform.rotation = Quaternion.LookRotation(directionVector, Vector3.forward);
        }
    }

    void LateUpdate()
    {
        transform.localEulerAngles = new Vector3(-70, transform.localEulerAngles.y, 0);
    }
}

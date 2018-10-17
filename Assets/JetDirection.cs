using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JetDirection : MonoBehaviour
{
    private float _RocketRespawn = 4;
    private GameObject playerShip;
    private List<RocketController> RocketControllers;

    // Start is called before the first frame update
    void Start()
    {
        playerShip = GameObject.FindGameObjectWithTag("Ship");
        RocketControllers = GetComponentsInChildren<RocketController>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        _RocketRespawn -= Time.deltaTime;
        if (RocketControllers != null && _RocketRespawn < 0)
        {
            ShootRocket();
            _RocketRespawn = 10;
        }


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

    void ShootRocket()
    {
        foreach (var rocket in RocketControllers)
        {
            rocket.Shoot(Random.Range(25, 60), Random.Range(0,5));
        }
    }
}

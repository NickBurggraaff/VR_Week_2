using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRwalk : MonoBehaviour
{
    public Transform Camera;
    public Transform Robot;
    public float toggelAngle = 30.0f;
    public float Speed = 3.0f;
    private bool _Moveforward;
    private CharacterController _CharacterController;

    // Start is called before the first frame update
    void Start()
    {
        _CharacterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Robot.transform.localEulerAngles = new Vector3(0, Camera.localEulerAngles.y, 0);
        //Angle walk
        if(Camera.eulerAngles.x >= toggelAngle && Camera.eulerAngles.x < 90.0f)
        {
            _Moveforward = true;
        }
        else
        {
            _Moveforward = false;
        }

        if (_Moveforward)
        {
            Vector3 forward = Camera.TransformDirection(Vector3.forward);
            _CharacterController.SimpleMove(forward * Speed);
        }
    }
}

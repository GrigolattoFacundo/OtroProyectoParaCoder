using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float vInput;
    private float hInput;
    private float steeringAngle;
    public float maxSteeringAngle = 20;
    public float EngineTorque = 100;

    public WheelCollider flwC;
    public WheelCollider frwC;
    public WheelCollider rlwC;
    public WheelCollider rrwC;

    public Transform flwT;
    public Transform frwT;
    public Transform rlwT;
    public Transform rrwT;

    private void FixedUpdate()
    {
        GetInput();
        Steering();
        Acceleration();
        WheelRotation();
    }

    void Steering()
    {
        steeringAngle = maxSteeringAngle * hInput;
        flwC.steerAngle = steeringAngle;
        frwC.steerAngle = steeringAngle;
    }

    void Acceleration()
    {
        rlwC.motorTorque = vInput * EngineTorque;
        rrwC.motorTorque = vInput * EngineTorque;
        //flwC.motorTorque = vInput * EngineTorque/2;
        //frwC.motorTorque = vInput * EngineTorque/2;
    }

    private void WheelRotation()
    {
        UpdateWheelTransform(flwC, flwT);
        UpdateWheelTransform(frwC, frwT); ;
        UpdateWheelTransform(rlwC, rlwT);
        UpdateWheelTransform(rrwC, rrwT);
    }

    private void UpdateWheelTransform(WheelCollider c, Transform t)
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        c.GetWorldPose(out pos, out rot);
        t.position = pos;
        t.rotation = rot;
    }
    void GetInput()
    {
        vInput = Input.GetAxis("Vertical");
        hInput = Input.GetAxis("Horizontal");
    }
 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;

    private float targetPressed;
    private float targetRelease;
    private HingeJoint hinge;
    
    private void Start()
    {
        hinge = GetComponent<HingeJoint>();

        targetPressed = hinge.limits.max;
        targetRelease = hinge.limits.min;
    }

    private void Update()
    {
       ReadInput();
    }

    private void ReadInput()
    {
        JointSpring jointspring = hinge.spring;

        if (Input.GetKey(input))
        {
            jointspring.targetPosition = targetPressed;
        }
        else
        {
            jointspring.targetPosition = targetRelease;
        }

        hinge.spring = jointspring;
    }
}

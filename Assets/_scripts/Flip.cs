using UnityEngine;
using UnityEngine.Assertions; // check if something is true or false 
public class Flip : MonoBehaviour
{
    public float flipperSpeed = 1000f;
    public float reverseMod = 1f;

    [System.NonSerialized] public bool isPressed = false;

    private HingeJoint2D hinge;
    private JointMotor2D motor;


    private void Awake()
    {
        hinge = GetComponent<HingeJoint2D>();
        Assert.IsNotNull(hinge, "couldnt find the hinge component");// this will only run in debug mode
        motor = hinge.motor;

    }

    private void FixedUpdate()
    {
        if (isPressed)
        {
            // todo add reverse mod
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * flipperSpeed;
            hinge.motor = motor;
        }
        else // if is pressed not true
        {
            // todo: add reverse mod.
            JointMotor2D motor = hinge.motor;
            motor.motorSpeed = reverseMod * -flipperSpeed;
            hinge.motor = motor;
        }
    }


    // bool myBool = true;
    //if (myBool == true)

    //Logical operators
    // == is it equal to
    //> morethan
    //< less than
    // >= more than or equal 
    // <= less than or equal 

    // conditional operators
    // && and 
    // bars or
    // if, else if or else

}



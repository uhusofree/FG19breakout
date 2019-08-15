using UnityEngine;
using UnityEngine.Assertions;

public class PlayerInput : MonoBehaviour
{
    #region Data types and variables
    // creating a variable
    //access modifer-data type-variable name

    // access modifier: public, private, protected
    // if no access modifer is indicated its auto private
    //public int myValue; //declaring a variable
    /*
     int = whole numbers
     bool = true or false (default false)
     float = decimals (indicated by f extension)~7 decimals 
     double = decimals(exclusion of f)
     string = text or character strings ("")
     char = one character ('')
     */
    #endregion Data types and variables
    private Camera playerCam; // Default value is null
    private Flip leftFlipper; // mmember variables of a player input
    private Flip rightFlipper;

    private string leftflipperName = "LeftFlipper";
    private string rightFlipperName = "RightFlipper";



    //functions/methids
    // access modifiers, return datatype, methodname, parameter
    private void Awake()
    {
        playerCam = Camera.main; //camera.main uses find objeect of tag interally.
        leftFlipper = GetFlipper(leftflipperName);
        Assert.IsNotNull(leftFlipper, "Child" + leftflipperName + "was not found");
        rightFlipper = GetFlipper(rightFlipperName);
        Assert.IsNotNull(leftFlipper, "Child" + leftflipperName + "was not found");

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #region
    private void Update()

    {
        float xPosition = playerCam.ScreenToWorldPoint(Input.mousePosition).x;
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

        leftFlipper.isPressed = Input.GetButton(leftflipperName);
        rightFlipper.isPressed = Input.GetButton(rightFlipperName);
    }
    #endregion 
    private Flip GetFlipper(string flipperName)
    {
        /*ransform flipperTransform = transform.Find(flipperName);
         Assert.IsNotNull(flipperTransform, "Child:" + flipperName
        was not found)
         Flip flipper = flipperTransform.GetComponent<Flip>();
         Assert.IsNotNull(flipper, "child" + flipperName + "missing flipper script");
         */

        return transform.Find(flipperName)?.GetComponent<Flip>();
    }
}


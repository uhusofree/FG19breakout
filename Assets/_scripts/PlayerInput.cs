using UnityEngine;

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

    //functions/methids
    // access modifiers, return datatype, methodname, parameter
    private void Awake()
    {
        playerCam = Camera.main; //camera.main uses find objeect of tag interally.
    }
}

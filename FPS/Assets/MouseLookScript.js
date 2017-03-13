#pragma strict

var lookSensitivity : float = 5;
var yRotation : float;
var xRotation : float;
var currentYRotation : float;
var currentXRotation : float;
var yRotationV : float;
var xRotationV : float;
var lookSmoothDamp : float = 0.1;

function Start () {
	
}

function Update () {
    yRotation += Input.GetAxis("Mouse X") * lookSensitivity;	
    xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

    currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, xRotationV, lookSmoothDamp);
    currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, yRotationV, lookSmoothDamp);

    transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
}

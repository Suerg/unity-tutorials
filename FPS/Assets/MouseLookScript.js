#pragma strict

var lookSensitivity : float = 5;
var lookSmoothDamp : float = 0.1;
@HideInInspector
var yRotation : float;
@HideInInspector
var xRotation : float;
@HideInInspector
var currentYRotation : float;
@HideInInspector
var currentXRotation : float;
@HideInInspector
var yRotationV : float;
@HideInInspector
var xRotationV : float;

function Start () {
	
}

function Update () {
    yRotation += Input.GetAxis("Mouse X") * lookSensitivity;	
    xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;

    xRotation = Mathf.Clamp(xRotation, -90, 90);

    currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, xRotationV, lookSmoothDamp);
    currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, yRotationV, lookSmoothDamp);

    transform.rotation = Quaternion.Euler(currentXRotation, currentYRotation, 0);
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public float mSens = 100f;
    public Transform player;

    float horizontalRot = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mSens * Time.deltaTime;
        horizontalRot -= mouseY;
        horizontalRot = Mathf.Clamp(horizontalRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(horizontalRot, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
    }
}

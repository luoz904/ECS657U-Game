using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public float panSpeed = 30f;

    public float borderPad = 10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - borderPad)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

          if (Input.GetKey("a") || Input.mousePosition.x <= borderPad)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

          if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - borderPad)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

          if (Input.GetKey("s") || Input.mousePosition.y <= borderPad)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }
    }
}

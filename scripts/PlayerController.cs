using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variables
    private float horizontalInput;
    private float verticalInput;
    [SerializeField]
    private float speed = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //set our input axis(keyboard arrows)
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //move when the user presses the arrow keys
        transform.Translate(-Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(-Vector3.forward * verticalInput * Time.deltaTime * speed);
    }
}

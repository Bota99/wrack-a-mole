using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour
{
    //show & hide variables
    public float visibleYHeight = 4.0f; //value y when showing
    public float hiddenYHeight = -3.5f; //value y when hiding
    private Vector3 myNewXYZPosition; //position to move current mole
    public float speed = 4f; //speed the mole moves
    public float hideMoleTimer = 3f; //timer to hide the mole after it shows

    //Sound Show mole
    private AudioSource sndEffectShowMole;

    //mole is created
    void Awake()
    {
        HideMole();

        //set our current position
        transform.localPosition = myNewXYZPosition;

        //get the audio source to play when show mole
        sndEffectShowMole = GetComponent<AudioSource>();

    }
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // move mole to new x y z position
        transform.localPosition = Vector3.Lerp(
                transform.localPosition,
                myNewXYZPosition,
                Time.deltaTime * speed
            );

        //hide mole if timer less than 0
        hideMoleTimer -= Time.deltaTime;
        if(hideMoleTimer < 0)
        {
            HideMole();
        }
    }

    //hide the mole
    public void HideMole()
    {
        //set the current position to hiddenYHeight
        myNewXYZPosition = new Vector3(
                transform.localPosition.x,
                hiddenYHeight,
                transform.localPosition.z
            );
    }

    //show mole
    public void ShowMole()
    {
        //set the current position to visibleYHeight
        myNewXYZPosition = new Vector3(
                transform.localPosition.x,
                visibleYHeight,
                transform.localPosition.z
            );

        //reset the hideMoleTimer to 1.5 sec before hiding
        hideMoleTimer = 3f;

        //play the show mole sound effect
        sndEffectShowMole.Play();
        Debug.Log("it's a mole!");

    }
}

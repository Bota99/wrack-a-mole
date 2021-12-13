using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Hammer : MonoBehaviour {
    //variables
    private bool hammerIsUp = true;
    private float hammerDownAngle = 0;
    private float hammerUpAngle = 90;
    private Quaternion hammerDownRotation; // x angle(s) when hammer is down
    private Quaternion hammerUpRotation; // x angle(s) when hummer is up
    private float hammerDownMaxTime = 0.25f; //max time to swing hammer before moving back up

    //Variables for the sound and score
    private AudioSource sndEffectScore; //hit mole sound
    public int score; //score in the game
    [SerializeField]
    private TextMesh scoreText; //reference to score text in unity

    // Start is called before the first frame update
    void Start()
    {
        hammerDownRotation = Quaternion.Euler(hammerDownAngle, transform.rotation.y, transform.rotation.z);
        hammerUpRotation = Quaternion.Euler(hammerUpAngle, transform.rotation.y, transform.rotation.z);

        //get the audio source
        sndEffectScore = GetComponent<AudioSource>();

        //Reset score when game starts
        score = 0;
    }

    // Update is called once per frame
    void Update() {
        //user presses space bar, swing the hammer
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //if hammer is up, call swing hammer with hammerrotationdown
            if (hammerIsUp)
            {
                SwingHammer(hammerUp: false, hammerRotation: hammerDownRotation);
            }

            //if hammer is doen, call swing hammer with hammerrotationup
            else
            {
                SwingHammer(hammerUp: true, hammerRotation: hammerUpRotation);
            }
        }

        //only have hammer down a max of 1/4 sec
        if (!hammerIsUp)
        {
            hammerDownMaxTime -= Time.deltaTime;
            if (hammerDownMaxTime <= 0f)
                SwingHammer(hammerUp: true, hammerRotation: hammerUpRotation);
        }

    }

    //swing hammer
    void SwingHammer(bool hammerUp, Quaternion hammerRotation) {
        //set the hammerIsUp using the hammerUp passed in
        hammerIsUp = hammerUp;

        //update hammer rotation
        transform.rotation = hammerRotation;

        //reset hammer max down timer if hammer is up
        if (hammerIsUp) {
                hammerDownMaxTime = 0.25f;
        }
    }
    
    //On collision enter - anytime hammer hits something else
    void OnTriggerEnter(Collider collision) {
        //get mole i hit using the tag Mole
        Debug.Log("Hit him now!!!");
        if (collision.gameObject.tag == "Mole")
        {

            Debug.Log("haha!");
            UpdateScore();

            //hide mole
            Mole moleIhit = collision.gameObject.transform.GetComponent<Mole>();
            moleIhit.HideMole();
        }
    }

    //Update score
    public void UpdateScore() {
        score++; //add 1 to the score
        scoreText.text = "SCORE: " + score;
        sndEffectScore.Play();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using System.Threading.Tasks;

public class Gamecontroller : MonoBehaviour
{
    //timer Variables
    public TextMesh timertext; //reference to our unity text
    public float gameTimer = 30f; //30 sec for game timer

    //mole variables
    public GameObject MoleContainer; //reference to our molecontainer in unity
    private Mole[] moles;
    public float showMoletimer = 1.5f; //show mole every 1.5 sec

    //restart variables
    [SerializeField]
    private TextMesh restartText;
    [SerializeField]
    public TextMesh gameoverText;

    // Start is called before the first frame update
    void Start()
    {
        //put all our moles from unity molecontainer into our list moles
        moles = MoleContainer.GetComponentsInChildren<Mole>();

        //hide restart text
        restartText.gameObject.SetActive(false);
        gameoverText.gameObject.SetActive(false);

        //Debug.Log("Number of Moles: " + moles.Length); //print the moles to the screen
    }

    // Update is called once per frame
    void Update()
    {
        //check game timer is greater than 0 sec
        if (gameTimer > 0f)
        {

            //update the game timer
            gameTimer -= Time.deltaTime; //substracts 1 sec from game timer

            //update text in unity
            timertext.text = "WHACK A MOLE: " + Mathf.Floor(gameTimer);

            //show mole if showMoleTimer is 0
            showMoletimer -= Time.deltaTime;
            if (showMoletimer < 0f)
            {
                //show the next mole randomly from our list of moles
                moles[Random.Range(0, moles.Length)].ShowMole();

                //reset the showmoletimer to 1.5 sec
                showMoletimer = 1.5f;
            }
        }
        //game timer less than 0 sec
        else
        {
            //update text in unity to game over
            timertext.text = "";
            
            gameoverText.gameObject.SetActive(true);
            
            //show restsrt text
            restartText.gameObject.SetActive(true);


            //if user press space restart game
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }

    }
    async Task UseDelay()
    {
        await Task.Delay(1000); // wait for 1 second
    }
    
     void blinkOn()
    {
        restartText.gameObject.SetActive(true);
    }
    
     void blinkOff()
    {
        restartText.gameObject.SetActive(false);
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

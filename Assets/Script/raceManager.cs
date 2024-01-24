using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class raceManager : MonoBehaviour
{

    public float speed = 0f;
    public TextMeshProUGUI speedText;
    public float timer = 10f; 
    public TextMeshProUGUI timerText;

    public ParticleSystem particleSystem;
    // Start is called before the first frame update
    void Start()
    {
         InvokeRepeating("timerDown", 1.0f, 1f);
    }

    // Update is called once per frame
    

    public void upgradeSpeed()
    {
        // Augmentez la valeur de la vitesse ou effectuez toute autre action que vous souhaitez.
        // Par exemple, vous pouvez stocker la vitesse dans une variable et l'augmenter ici.

        speed += 1f /*+ (whiteWheel * 2f) + (yellowWheel * 4f) + (RedWheel * 8f)*/;
        speedText.text = speed.ToString();


    }

    public void timerDown()
    {
        
        timer = timer - 1f;
        timerText.text = timer.ToString();

        if (timer <= 0f)
        {
            SceneManager.LoadScene("mainScene");
        }

        if(speed >= 300){
           SceneManager.LoadScene("mainScene");
           GameManager.trophyNumber += 1;
        }   
    }

}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Les texte en jeu
    public TextMeshProUGUI speedText; //texte de la vitesse
    public TextMeshProUGUI moneyText; 

    public TextMeshProUGUI textWhiteWheel;
    public TextMeshProUGUI textYellowWheel;
    public TextMeshProUGUI textRedWheel;

    public TextMeshProUGUI moneyForWhiteWheelsText;
    public TextMeshProUGUI moneyForYellowWheelsText;
    public TextMeshProUGUI moneyForRedWheelsText;

    public TextMeshProUGUI moneyForSpoilerText;
    public TextMeshProUGUI moneyForFinsText;

    public TextMeshProUGUI textSpoiler;
    public TextMeshProUGUI textFins;
    public TextMeshProUGUI textTrophy;

    //Valeurs des variables
    public float speed = 0f;
    public float money = 0f;
    private float moneySave = 0f;
   
   public float moneyForWhiteWheels = 1000f;
   public float moneyForYellowWheels = 10000f;
   public float moneyForRedWheels = 50000f;

   public float moneyForSpoiler = 100000;
   public float moneyForFins = 500000f;

    public float moneyForTrophy = 1000000;

    public float whiteWheel = 0f;
    public float yellowWheel = 0f;
    public float RedWheel = 0f;

    public float spoiler = 0f;
    public float fins = 0f;
    public static float trophyNumber = 0f;

    // Boutton
    public Button buttonWhiteWheel;
    public Button buttonYellowWheel;
    public Button buttonRedWheel;

    public Button buttonSpoiler;
    public Button buttonFins;

    public Button trophy;
    
    public ParticleSystem particleSystem;

    void Start()
    {

        InvokeRepeating("speedDown", 1.0f, 1f);
        //InvokeRepeating("timerDown", 1.0f, 1f);

        
        speedText.text = speed.ToString();
        moneyText.text = money.ToString();

        buttonWhiteWheel.interactable = false; // les boutons ne sont pas interactibles pour le moment
        buttonYellowWheel.interactable = false;
        buttonRedWheel.interactable = false;

        buttonSpoiler.interactable = false;
        buttonFins.interactable = false;

        trophy.onClick.AddListener(loadRaceScene); // chargement de la scene 

    }

    private void Update()
    {

        var mainModule = particleSystem.main; 
        mainModule.simulationSpeed = speed * 0.05f; // adaptation de la vitesse des particules en fonction de la variable speed

        if (money >= moneyForTrophy){
            trophy.gameObject.SetActive(true);
        } else {
            trophy.gameObject.SetActive(false);
        }

        textTrophy.text = trophyNumber.ToString();

        if (money >= moneyForWhiteWheels) // le bouton devien interactible la variable money atteint une certaine somme
        {
            buttonWhiteWheel.interactable = true;  
        }
        else
        {
            buttonWhiteWheel.interactable = false;  
        }

        if (money >= moneyForYellowWheels)
        {
            buttonYellowWheel.interactable = true;  
        }
        else
        {
            buttonYellowWheel.interactable = false;  
        }

        if (money >= moneyForRedWheels)
        {
            buttonRedWheel.interactable = true;  
        }
        else
        {
            buttonRedWheel.interactable = false; 
        }

        if (money >= moneyForSpoiler)
        {
            buttonSpoiler.interactable = true;  
        }
        else
        {
            buttonSpoiler.interactable = false;  
        }

        if (money >= moneyForFins)
        {
            buttonFins.interactable = true;  
        }
        else
        {
            buttonFins.interactable = false;  
        }

        
        moneyForWhiteWheelsText.text = moneyForWhiteWheels.ToString();  // le texte affiche la valeur de la variable
        moneyForYellowWheelsText.text = moneyForYellowWheels.ToString();   
        moneyForRedWheelsText.text = moneyForRedWheels.ToString();
        
        moneyForSpoilerText.text = moneyForSpoiler.ToString();   
        moneyForFinsText.text = moneyForFins.ToString();

    }

    
    public void loadRaceScene()
    {
        SceneManager.LoadScene("raceScene");
    } 
    
    public void upgradeWhiteWeels()
    {
        if (money >= moneyForWhiteWheels)
        {
            money = money - moneyForWhiteWheels;// perte d'argent 
            moneyText.text = money.ToString();// le texte prend la valeur de la variable
            whiteWheel += 1f;// la variable prend +1
            textWhiteWheel.text = whiteWheel.ToString(); // le texte prend la valeur de la variable
            moneyForWhiteWheels = moneyForWhiteWheels * 2 * whiteWheel; // le prix pour pouvoir acheter augmente
            moneyForWhiteWheelsText.text = moneyForWhiteWheels.ToString();            
        }
    }

    public void upgradeYellowWheels()
    {
        if (money >= moneyForYellowWheels)
        {
            money = money - moneyForYellowWheels;
            moneyText.text = money.ToString();
            yellowWheel += 1f;
            textYellowWheel.text = yellowWheel.ToString();
            moneyForYellowWheels = moneyForYellowWheels * 2 * yellowWheel;
            moneyForYellowWheelsText.text = moneyForYellowWheels.ToString();        
        }
    }

    public void UpgradeRedWheels()
    {
        if (money >= moneyForRedWheels)
        {
            money = money - moneyForRedWheels;
            moneyText.text = money.ToString();
            RedWheel += 1f;
            textRedWheel.text = RedWheel.ToString();
            moneyForRedWheels = moneyForRedWheels * 2 * RedWheel;
            moneyForRedWheelsText.text = moneyForRedWheels.ToString();        
        }
    }

    public void upgradeSpoiler()
    {
        if (money >= moneyForSpoiler)
        {
            spoiler += 1f;
            money = money - 100000f;
            moneyText.text = money.ToString();
            moneyForSpoiler = moneyForSpoiler * 2 * spoiler;
            textSpoiler.text = spoiler.ToString();
        }
    }

    public void upgradeFins()
    {
        if (money >= moneyForFins)
        {
            fins += 1f;
            money = money - 500000f;
            moneyText.text = money.ToString();
            moneyForFins = moneyForFins * 2 * fins;
            textFins.text = fins.ToString();
        }
    }

    public void upgradeSpeed()
    {
        

        speed += 1f + (whiteWheel * 2f) + (RedWheel * 8f);
        speedText.text = speed.ToString();

        

        moneySave = money;
        money = moneySave + speed + (yellowWheel * 4f);
        moneyText.text = money.ToString();

    }
    
    public void speedDown()
    {
        
        speed = speed - 10f;
        speedText.text = speed.ToString();

        if (speed <= 0f)
        {
            speed = 0f;
        }
    }

}
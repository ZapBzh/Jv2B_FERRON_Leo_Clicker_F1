using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManageur : MonoBehaviour
{
    // Start is called before the first frame update
    public Button trophy;
    
    public void Start()
    {
        trophy.onClick.AddListener(loadRaceScene);
    }
    
    public void loadRaceScene()
    {
        SceneManager.LoadScene("raceScene");
    } 
}

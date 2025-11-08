using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIOnClick : MonoBehaviour
{
    public Button actionButton;

    public string sceneToLoad = "Scene";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        actionButton.onClick.AddListener(clickAction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //place any code you need to run after button input here
    void clickAction()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}

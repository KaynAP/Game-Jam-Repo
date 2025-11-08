using UnityEngine;
using UnityEngine.UI;

public class radialTimer : MonoBehaviour
{
    public Slider timeBar;

    public float startTime;

    float timeLeft;

    public bool timerActive = false;

    //put this in another script later
    bool isDead = false;

    public GameObject deathScreen;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set death screen to inactive again
        deathScreen.SetActive(false);

        timerActive = true;

        timeLeft = startTime;

        //set slider min max
        timeBar.maxValue = startTime;
        timeBar.minValue = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive && timeLeft > 0){
            timeLeft -= Time.deltaTime;
            //update display
            timeBar.value = timeLeft;
        }
        else if (timerActive && timeLeft <= 0)
        {
            timerActive = false;
            //kill player here
            print("UR DEAD!");
            isDead = true;
            deathScreen.SetActive(true);
        }
    }
}

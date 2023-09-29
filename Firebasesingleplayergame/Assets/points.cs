using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class points : MonoBehaviour
{
    public BoxCollider foodSpawn;
    public float scorepoint;
    [SerializeField] ScoreManager score;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI time;
    [SerializeField] public GameObject lose;
    public float countdownDuration = 60.0f; // Set the duration of the countdown in seconds
    float timer;
    private void Start()
    {
        RandomPose();
    }

    private void Update()
    {
        ScoreText.text = "" + scorepoint;
        time.text = "" + timer;
    }

    private void RandomPose()
    {
        Bounds bounds = this.foodSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
        RandomLosePose();
    }
    private void RandomLosePose()
    {
        Bounds bounds = this.foodSpawn.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        lose.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    }
    void OnMouseDown()
    {
        RandomPose();
        scorepoint += 1;
        score.AddScore();
        if(timer==0)
        {

            StartCoroutine(StartCountdown());
        }
      
    }
    public void resetpoints()
    {
        scorepoint = 0;
    }
    

       
  

    IEnumerator StartCountdown()
    {
        timer = countdownDuration;
        Debug.Log("a");
        while (timer > 0)
        {
            Debug.Log("Time remaining: " + timer.ToString("F2")); // Print remaining time

            yield return new WaitForSeconds(1.0f); // Wait for 1 second
            timer -= 1.0f; // Decrease the timer by 1 second
            
        }

        Debug.Log("Countdown finished!"); // Do something when the countdown finishes
        resetpoints();
        lose.GetComponent<LoseManager>().ontimerend();
    }
}



    

   

    
    




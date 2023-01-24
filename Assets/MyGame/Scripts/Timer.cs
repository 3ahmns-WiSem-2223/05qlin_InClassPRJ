using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeLeft;

    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private GameObject timeOutPanel;


    private void Awake()
    {
        Time.timeScale = 1;
    }
    void UpdateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        time.text =  "Timer: " + string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    private void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime;
            UpdateTimer(timeLeft);
        }
        else
        {
            timeOutPanel.SetActive(true);
            timeLeft = 0;
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit(0);
    }

}

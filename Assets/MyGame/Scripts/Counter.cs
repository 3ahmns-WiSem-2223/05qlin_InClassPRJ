using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI yourScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int currentCount = 0;
    public static Counter instance;

    private Timer tm;

    public bool clickedOn;


    public void Count()
    {
        currentCount++;
        scoreText.text = "Counter: " + currentCount.ToString();
        
    }

    private void Start()
    {
        scoreText.text = "Counter: " + currentCount.ToString();
        tm = GetComponent<Timer>();
        highScoreText.text = "Your Highscore: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && tm.timeLeft > 0)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                hit.collider.gameObject.SetActive(false);
                Count();
                clickedOn = true;
            }
        }

        HighScore();
    }


    public void HighScore()
    {
        yourScoreText.text = "Your Score: " + currentCount.ToString();

        if (currentCount > PlayerPrefs.GetInt("HighScore", 0)) 
        {
            PlayerPrefs.SetInt("HighScore", currentCount);
            highScoreText.text = "Your Highscore: " + currentCount.ToString();
        }
        else if(currentCount == 0)
        {
            yourScoreText.text = "Your Score: 0";
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScoreText.text = "Your Highscore:" + "0";
    }

}

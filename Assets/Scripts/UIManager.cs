using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public Sprite[] lives;
    public Image livesImage;
    public Text scoreText;
    public  int score;

    private void Update()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level1" && score == 100)
        {
            SceneManager.LoadScene("Level3");
        }

        if (scene.name == "Level3" && score == 300)
        {
            SceneManager.LoadScene("Youwin");
        }
    }

    public void UpdateLives(int currentLives)
    {
        livesImage.sprite = lives[currentLives];
    }

    public void UpdateScore()
    {
        score += 10;

        scoreText.text = "Score: " + score;
    }
}

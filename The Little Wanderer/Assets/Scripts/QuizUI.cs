using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private QuizManager2 quizManager;
    [SerializeField] private TextMeshProUGUI questionText, scoreText, coinsText, imageText, buttonText;
    [SerializeField] private Image questionImage;
    [SerializeField] private GameObject resultsPanel, quizPanel;
    [SerializeField] private List<Button> options;
    [SerializeField] private Color correctCol, wrongCol, normalCol;






    private Question question;
    private bool answered;
    private int LevelAt;

  




    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < options.Count; i++)
        {
            Button localBtn = options[i];
            localBtn.onClick.AddListener(() => OnClick(localBtn));
        }
        
    }

    void Start()
    {
        
        resultsPanel.SetActive(false);
        LevelAt = SceneManager.GetActiveScene().buildIndex;

    }

    public void SetQuestion(Question question)
    {
        this.question = question;

        switch(question.questionType)
        {
            case QuestionType.TEXT:

                questionImage.transform.parent.gameObject.SetActive(false);

                break;
            case QuestionType.IMAGE:

                questionImage.transform.parent.gameObject.SetActive(true);    //activate image holder
                questionImage.transform.gameObject.SetActive(true);           //activate questionImg


                questionImage.sprite = question.questionImg;

                break;
        }

        questionText.text = question.questionInfo;
        imageText.text = question.imageText;

        List<string> answerList = ShuffleList.ShuffleListItems<string>(question.options);

        for (int i = 0; i < options.Count; i++)
        {
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = answerList[i];
            options[i].name = answerList[i];
            options[i].image.color = normalCol;
        }

        answered = false;

    }

    private void OnClick(Button btn)
    {
        if(!answered)
        {
            answered = true;
            bool val = quizManager.Answer(btn.name);

            if (val)
            {
                btn.image.color = correctCol;
            }
            else
            {
                btn.image.color = wrongCol;
            }
        }
    }

    public void GameOver()
    {
        quizPanel.SetActive(false);
        resultsPanel.SetActive(true);
        scoreText.text = "You've scored " + quizManager.score + "/" + quizManager.totalquestions;
        
        if (quizManager.score == quizManager.totalquestions)
        {
            buttonText.text = "Next Level";
            if (LevelAt > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", LevelAt);
                CoinsManager.coins += quizManager.score * 10;
                coinsText.text = "+" + quizManager.score * 10 + " coins";
                CoinsManager.UpdateCoins();
            }

            
            else
            {
                CoinsManager.coins += quizManager.score;
                coinsText.text = "+" + quizManager.score + " coins";
                CoinsManager.UpdateCoins();
            }
            

        }
        else
        {
            buttonText.text = "Retry Level";
            CoinsManager.coins += quizManager.score;
            coinsText.text = "+" + quizManager.score + " coins";
            CoinsManager.UpdateCoins();
        }
        
        


    }

    public void retrybutton()
    {
        if (quizManager.score == quizManager.totalquestions)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

            

    }

}

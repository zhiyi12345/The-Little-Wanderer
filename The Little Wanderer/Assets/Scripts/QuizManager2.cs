using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager2 : MonoBehaviour
{
    [SerializeField] private QuizUI quizUI;
    [SerializeField]
    private List<Question> questions;
    [SerializeField]
    private Animator animator;


    private Question selectedQuestion;
    
    public int score;
    public int totalquestions;

    

    // Start is called before the first frame update
    void Start()
    {
        SelectQuestion();
        totalquestions = questions.Count + 1;
        score = 0;
    }

    void SelectQuestion()
    {
        animator.Play("NoAnswer", -1, 0f);
        if (questions.Count > 0)
        {
            int val = Random.Range(0, questions.Count);
            selectedQuestion = questions[val];

            quizUI.SetQuestion(selectedQuestion);

            questions.RemoveAt(val);
        }
        else
        {
            Debug.Log("Out of Questions");
            quizUI.GameOver();
        }
    }

    

    public bool Answer(string answered)
    {
        bool correctAns = false;

        if(answered == selectedQuestion.correctAns)
        {
            //Yes
            correctAns = true;
            score += 1;
            animator.SetTrigger("True");
        }
        else
        {
            //No
            animator.SetTrigger("False");
        }

        Invoke("SelectQuestion", 1f);

        return correctAns;
    }

    

}

[System.Serializable]

public class Question
{
    public string questionInfo;
    public QuestionType questionType;
    public string imageText;
    public Sprite questionImg;
    public List<string> options;
    public string correctAns;
}

[System.Serializable]

public enum QuestionType
{
    TEXT,
    IMAGE
}



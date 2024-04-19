
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

[System.Serializable]

public class QuestionAndAnswers
{
    public string QuestionText;
    public Sprite QuestionSprite;
    public string[] Answers;
    public int CorrectAnswer;
}

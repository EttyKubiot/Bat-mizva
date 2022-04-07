using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public UnityAction OnWrongClick;
    public UnityAction OnCorrectClick;
    public UnityAction SelectClass;
    public UnityAction<ClassData> ClassSelected;
    public UnityAction<int> OnGift;
    public UnityAction Movilclass;
    public UnityAction TextsetActive;
    public UnityAction ViewClass;
    public UnityAction Leadingclass;

    [SerializeField] private GameObject movilllll;
    [SerializeField] private Text classs;
    [SerializeField] private Text scoree;
    [SerializeField] private Text classs2;
    [SerializeField] private Text scoree2;

    [SerializeField] private Text classText;

    [SerializeField] private Text feedback1;
    [SerializeField] private Text feedback2;
   
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    [SerializeField] private int correctScene;
    [SerializeField] private GameObject laddingCircle;

    public int CorrectScene
    {
        get { return correctScene; }
        set
        {
            correctScene = value;
        }
    }

    private bool setActiveText;
    private int correctClicks = 0;
    public bool SetActiveText
    {
        get { return setActiveText; }
        set
        {
            setActiveText = value;
        }
    }

   
    private ClassData classDataSelected;
    public ClassData ClassDataSelected
    {
        get { return classDataSelected; }
        set
        {
            classDataSelected = value;
        }

    }


    public Text Feedback1
    {
        get { return feedback1; }
        set
        {
            feedback1 = value;
        }

    }

    public Text Feedback2
    {
        get { return feedback2; }
        set
        {
            feedback2 = value;
        }

    }

    
    public int CorrectClicks
    {
        get { return correctClicks; }
        set
        {
            correctClicks = value;
          
            if (correctClicks >= 8)
            {
               
                Movilclass?.Invoke();

            }

        }
    }
    
  
    public void Movil(string class1, int score1, string class2, int score2)
    {
        scoree.text = score1.ToString();
        classs.text = class1;

        if (score2 == 100)
        {
            scoree2.text = null;
            classs2.text = null;

        }
        else
        {
            scoree2.text = score2.ToString();
            classs2.text = class2;
        }

        if (correctScene == 4)
        {
            //movilllll.gameObject.SetActive(true);
            Leadingclass?.Invoke();
            //laddingCircle.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        }
        else
        {
            movilllll.gameObject.SetActive(true);
            //movilllll.GetComponent<Animator>().SetInteger("end", 1);
        }

    }

    public void SetMovil()
    {
        movilllll.gameObject.SetActive(true);
    }
   
   public void NextScene()
   {
        //movilllll.GetComponent<Animator>().SetInteger("end", 0);

        SceneManager.LoadScene(correctScene + 2);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

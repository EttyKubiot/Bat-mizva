using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class Animations : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
  
  
    [SerializeField] private Animator imageAnim;
    //[SerializeField] private Animator littleCircleAnim;
    [SerializeField] private Animator giftAnim;
   
    [SerializeField] private Image circleAnim;
   
    [SerializeField] private Animator movilAnim;

    [SerializeField] private GameObject backroundBlue;
    [SerializeField] private GameObject classbuttons;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject movilllll;
    [SerializeField] private GameObject laddingCircle;
    [SerializeField] private GameObject textTittle;
    [SerializeField] private Text textClass;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textClass2;
    [SerializeField] private Text textScore2;
    //[SerializeField] private GameObject classScore;
    private IEnumerator Start()
    {

        gameManager.OnCorrectClick += Correct2;
        gameManager.ClassSelected += EndSelectClass2;
        gameManager.OnWrongClick += NotCorrect2;
        gameManager.OnGift += GetGift;
        //gameManager.ViewClass += CallCoroutine;
        //gameManager.OnWrongClick += NotCorrect2;
        gameManager.Leadingclass += Leading;
        imageAnim.SetInteger("onImage", 6);
        imageAnim.SetInteger("onImage", gameManager.CorrectScene);
        //littleCircleAnim.SetInteger("onCircle", 1);
        backroundBlue.gameObject.SetActive(false);
        scoreText.GetComponent<DOTweenAnimation>().DOPause();
        yield return new WaitForSeconds(2f);
        StartCoroutine(viewClasses());
        StartCoroutine(StopAnim1());
    }

   
    public void Correct2()
    {
       
       
        scoreText.GetComponent<DOTweenAnimation>().DOPlay();
        //littleCircleAnim.SetInteger("onCircle", 1);
        classbuttons.GetComponent<DOTweenAnimation>().DORewindAllById("downButton");
        circleAnim.GetComponent<DOTweenAnimation>().DORewind();
        scoreText.GetComponent<DOTweenAnimation>().DORewind();
        StartCoroutine(StopAnim());
    }

    public void NotCorrect2()
    {
        classbuttons.GetComponent<DOTweenAnimation>().DORewindAllById("downButton");
        circleAnim.GetComponent<DOTweenAnimation>().DORewind();
        StartCoroutine(StopAnim());
    }

    //private void NotCorrect2()
    //{

    //    StartCoroutine(StopAnim());
    //    StartCoroutine(viewClasses());
    //}

    public void Leading()
    {
        movilllll.gameObject.SetActive(true);

        laddingCircle.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        textTittle.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        textClass.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        textScore.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        textClass2.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
        textScore2.GetComponent<DOTweenAnimation>().DOPlayById("Circledown");
    }

    public void EndSelectClass2(ClassData classData)
    {

        //StartCoroutine(StopAnim());
        classbuttons.GetComponent<DOTweenAnimation>().DORewindAllById("up");
        circleAnim.GetComponent<DOTweenAnimation>().DORewindAllById("up");
        classbuttons.GetComponent<DOTweenAnimation>().DOPlayById("up");
        circleAnim.GetComponent<DOTweenAnimation>().DOPlayById("up");
        StartCoroutine(HideClasses());
    }

    private void GetGift(int index)
    {
        if(gameManager.CorrectScene == 0)
        {
            giftAnim.SetInteger("onBonus", index);
        }
        else if (gameManager.CorrectScene == 1)
        {
            giftAnim.SetInteger("onBonus", index+2);
        }
        else if (gameManager.CorrectScene == 2)
        {
            giftAnim.SetInteger("onBonus", index+4);
        }
        else if (gameManager.CorrectScene == 3)
        {
            giftAnim.SetInteger("onBonus", index + 6);
        }

        StartCoroutine(StopAnim1());
    }

    //private void CallCoroutine()
    //{
    //    StartCoroutine(viewClasses());
    //}

    public IEnumerator viewClasses()
    {
       
        yield return new WaitForSeconds(1f);
        backroundBlue.gameObject.SetActive(true);
        Debug.Log("eeeeeeeeeeeeeeeee");

        yield return new WaitForSeconds(1f);
        circleAnim.GetComponent<DOTweenAnimation>().DOPlayById("down");
        classbuttons.GetComponent<DOTweenAnimation>().DOPlayById("downButton");
      
      
        yield return new WaitForSeconds(2.5f);
        //StartCoroutine(HideClasses());
        //classButtonAnim.SetBool("chooseClass", true);
        //classbuttons.gameObject.SetActive(true);


    }
    private IEnumerator HideClasses()
    {
        

        //classButtonAnim.SetBool("chooseClass", false);
        yield return new WaitForSeconds(2f);
        backroundBlue.gameObject.SetActive(false);
        
    }


    private IEnumerator StopAnim()
    {
        //yield return new WaitForSeconds(1f);

        

        //littleCircleAnim.SetInteger("onCircle", 0);
        //yield return new WaitForSeconds(2f);
      
        //classScore.SetActive(false);
        //scoreAnim.SetInteger("onScore", 0);
        yield return new WaitForSeconds(1.5f);
        //scoreText.GetComponent<DOTweenAnimation>().DOPause();
        StartCoroutine(viewClasses());
    }
    private IEnumerator StopAnim1()
    {
        
        yield return new WaitForSeconds(2f);
        //littleCircleAnim.SetInteger("onCircle", 0);
        yield return new WaitForSeconds(2f);
        giftAnim.SetInteger("onBonus", 0);
    }

    
}

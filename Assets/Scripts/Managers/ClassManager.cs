using UnityEngine;
using UnityEngine.UI;


public class ClassManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ClassData[] allclassData;
    public bool selectClass = false;
  
   
    private void Start()
    {
        //Resets the data 
        //for (int i = 0; i < allclassData.Length; i++)
        //{
        //    allclassData[i].Score = 0;
        //}
    }


    //Identifies which grade clicked on
    public void OnClickClass(ClassData classData)
    {
        selectClass = true;
        //Send Data to EndSelectClass function
        gameManager.ClassSelected?.Invoke(classData);
    }


    //Function of the leading class
    public void LeadingClass()
    {
        //Turn off the Feedback
        gameManager.Feedback1.gameObject.SetActive(false);
        gameManager.Feedback2.gameObject.SetActive(false);

        //A loop that goes over the score of all classes and identifies what is the highest score
        int max = allclassData[0].Score;
        string maxName = allclassData[0].ClassName;

        int less = allclassData[0].Score;
        string lessName = allclassData[0].ClassName;

        for (int i = 0; i < allclassData.Length; i++)
        {

            if (allclassData[0].Score == allclassData[1].Score)
            {
                Debug.Log("2 WINNERS");
                
                //Send Data of LeadingClass to Movil function
                gameManager.Movil("2ט 1ט", allclassData[0].Score, "", 100);
                return;
            }
           
            else if (allclassData[i].Score >= max)
            {
                max = allclassData[i].Score;
                maxName = allclassData[i].ClassName;
            }

            else 
            {
                less = allclassData[i].Score;
                lessName = allclassData[i].ClassName;
            }
        }
        
     
        Debug.Log(maxName + " score" + max);
        Debug.Log(lessName + " score" + less);
        //Send Data of LeadingClass to Movil function
        gameManager.Movil(maxName, max, lessName, less );
    }

}

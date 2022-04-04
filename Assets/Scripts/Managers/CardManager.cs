using System.Collections;
using UnityEngine.UI;
using UnityEngine;



public class CardManager : MonoBehaviour
{
    private bool firstImageSelected = false;
    private bool currectClick = false;

    [SerializeField] private Image[] sprite1;
    [SerializeField] private Image[] sprite2;

    private Image currectImg;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private ClassManager classManager;
    [SerializeField] private PairData[] pairData2;

    [SerializeField] private ParticleSystem particles;

    private int indexButtonClicked1;
    private int indexButtonClicked2;

    private int groopSelected;

    public int IndexButtonClicked1 => indexButtonClicked1;
    public int IndexButtonClicked2 => indexButtonClicked2;

    public void Start()
    {
        for (int i = 0; i < pairData2.Length; i++)
        {
            pairData2[i].Sprite2[gameManager.CorrectScene] = null;

        }
        for (int i = 0; i < pairData2.Length; i++)

        {
            if (i % 2 == 0)
            {
                pairData2[i].Sprite2[gameManager.CorrectScene] = sprite1[i].sprite;

            }
            else
            {
                pairData2[i].Sprite2[gameManager.CorrectScene] = sprite2[i].sprite;

            }

        }
    }
   

    public void OnClickCard(PairData pairData)
    {
        //if (groopSelected == )

        if (classManager.selectClass == true && firstImageSelected == false)
        {
            groopSelected = pairData.Group;

            currectClick = false;
            firstImageSelected = true;
            
            indexButtonClicked1 = pairData.IndexPair;


            if (pairData.Group == 1)
            {
                currectImg = sprite1[pairData.IndexPair];
            }
            else 
            {
                currectImg = sprite2[pairData.IndexPair];
                
            }

            currectImg.sprite = pairData.Sprite2[gameManager.CorrectScene];
            //currectImg.sprite = pairData.Sprite;

            StartCoroutine(Flickering(pairData.IndexPair , currectImg));
            
        }

        else if (firstImageSelected == true && pairData.Group != groopSelected)
        {
            Debug.Log(pairData.IndexPair);
            indexButtonClicked2 = pairData.IndexPair;

            firstImageSelected = false;
            classManager.selectClass = false;

            if (pairData.Group == 2)
            {
                sprite2[pairData.IndexPair].sprite = pairData.Sprite2[gameManager.CorrectScene];
                //sprite2[pairData.IndexPair].sprite = pairData.Sprite;

            }
            else 
            {
                sprite1[pairData.IndexPair].sprite = pairData.Sprite2[gameManager.CorrectScene];
                //sprite1[pairData.IndexPair].sprite = pairData.Sprite;
            }
         

            if (indexButtonClicked1 == indexButtonClicked2 )
            {
                Debug.Log("correct");
                gameManager. CorrectClicks++;
                currectClick = true;

                gameManager.OnCorrectClick?.Invoke();
                gameManager.ViewClass?.Invoke();


                Color tmp2 = sprite1[pairData.IndexPair].GetComponent<Image>().color;
                tmp2.a = 0.3f;
                sprite1[pairData.IndexPair].GetComponent<Image>().color = tmp2;
                Color tmp3 = sprite2[pairData.IndexPair].GetComponent<Image>().color;
                tmp3.a = 0.3f;
                sprite2[pairData.IndexPair].GetComponent<Image>().color = tmp3;
                AddBonus();
                

            }
           
           
            else
            {

                gameManager.OnWrongClick?.Invoke();
                currectClick = false;
                Debug.Log("notCorrect");
            }

        }
        else if (firstImageSelected == true && pairData.Group == groopSelected)
        {
                gameManager.OnWrongClick?.Invoke();
                currectClick = false;
                Debug.Log("notCorrect");
                firstImageSelected = false;
                }
        else
        {
            return;
        }

    }

   


   
    public void  AddBonus()
    {

        if (indexButtonClicked1 == 1 && gameManager.CorrectScene != 4)
        {
            particles.Play();
           
            gameManager.OnGift?.Invoke(indexButtonClicked1);
            //gameManager.OnCorrectClick?.Invoke();
        }
    }
   
    private IEnumerator Flickering(int currentIndex, Image image)
    {

        while (firstImageSelected == true)
        {
            yield return new WaitForSeconds(0.2f);

            Color tmp1 = image.GetComponent<Image>().color;
            tmp1.a = 0.5f;
            image.GetComponent<Image>().color = tmp1;

            yield return new WaitForSeconds(0.2f);

            tmp1 = image.GetComponent<Image>().color;
            tmp1.a = 1;
            image.GetComponent<Image>().color = tmp1;
        }

        if (currectClick == true)
        {
            Color tmp2 = image.GetComponent<Image>().color;
            tmp2.a = 0.3f;
            image.GetComponent<Image>().color = tmp2;
        }

        else
        {
            Color tmp2 = image.GetComponent<Image>().color;
            tmp2.a = 1;
            image.GetComponent<Image>().color = tmp2;
        }
    }

    



}






























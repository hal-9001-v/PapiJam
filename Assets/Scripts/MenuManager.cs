using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject fondo;
    public bool play;
    public int selectedButton;

    public AudioClip[] sonidos;
    public AudioSource audioPlay;

    public GameObject [] botonesMain;
    public GameObject flechita;
    bool charactersMenuOn;

    public int playersNum;
    public GameObject playersNumSelector;
    public Sprite[] numsSprites;
    public GameObject numberGO;

    public GameObject columnas;
    public GameObject[] columnasArray;
    public Text playerNumTx;
    public bool isNumSelected;
    
    //Cosa de la seleccion de personajes
    public MenuPrefs menuPrefs;

    public GameObject Visor;

    //Selectores
    public GameObject[] selectors;
    public GameObject selectorGO;

    //public Image
    private void Awake() {
    menuPrefs = FindObjectOfType<MenuPrefs>();
    }
    public GameObject casillasPersonajes;

    void TESTSELECCIONPERS(){
        int furro = 0;
        int darsay = 1;
        int monja = 2;
        int naruto = 3;
        //Así es como tendría que verse
        menuPrefs.p0 = furro;
        menuPrefs.p1 = darsay;
        menuPrefs.p2 = monja;
        menuPrefs.p3 = naruto;

        // (evidentemente p4 debería poder elegir al furro por ejemplo etc...);
        // Con que asignes los numeros bien, cuando cargues la escena "Sample", se pondrán bien los modelos
    }
    void Start()
    {
        selectedButton = 0;
        playersNum = 2;

        for(int i = 0; i< columnasArray.Length; i++)
        {
            columnasArray[i].SetActive(false);
        }
}
    
    // Update is called once per frame
    void Update()
    {
        MainMenu();       
    }

    private void MainMenu()
    {
        if (!play)
        {
            flechita.SetActive(true);
            selectMain();
            buttonsEdit();
        }
        else {
            flechita.SetActive(false);
            if (!isNumSelected)
            {
                playerNumSelect();
            }
            else
            {
  
                SubirPersonajes();
            }
            
            //SubirFondo();
        }
    }

    private void playerNumSelect()
    {

        iTween.MoveTo(playersNumSelector, iTween.Hash("y",  -7.2, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[0], iTween.Hash("x", 45, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[1], iTween.Hash("x", -45, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[2], iTween.Hash("x", 45, "time", 1.5f, "easetype", "easeOutQuint"));

        numberGO.GetComponent<SpriteRenderer>().sprite = numsSprites[playersNum-2];
        //setNumber();
        //botonesMain[0].transform.Translate(Vector3.right * 700 * Time.deltaTime);
        //botonesMain[1].transform.Translate(Vector3.left * 700 * Time.deltaTime);
    }

    private void setNumber()
    {
        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playersNum = Mathf.Clamp(playersNum + 1, 2, 4);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }*/

        /*if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playersNum = Mathf.Clamp(playersNum -1, 2, 4);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }*/

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
           isNumSelected = true;
            audioPlay.clip = sonidos[0];
            audioPlay.Play();
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -75, "time", 1.5f, "easetype", "easeOutQuint")); 
        }*/

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            play = !play;
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -75, "time", 1.5f, "easetype", "easeOutQuint"));
            for(int i = 0; i<botonesMain.Length; i++)
            {
                iTween.MoveTo(botonesMain[i], iTween.Hash("x", 350, "time", 1.5f, "easetype", "easeOutQuint"));
            }
        }*/
    }

    private void buttonsEdit()
    {
        for(int i = 0; i<botonesMain.Length; i++)
        {
            if(selectedButton == i)
            {
                botonesMain[i].transform.localScale = new Vector2(1.2f, 1.2f);
                flechita.transform.position = botonesMain[i].transform.position;
            }

            else
            {
                botonesMain[i].transform.localScale = new Vector2(1f, 1f);
            }
        }

    }

    void selectMain()
    {     
        /*if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedButton = Mathf.Clamp(selectedButton + 1, 0, botonesMain.Length - 1);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }*/

       /* if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedButton = Mathf.Clamp(selectedButton - 1, 0, botonesMain.Length - 1);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }*/
    }

    void SubirPersonajes()
    {
        iTween.MoveTo(fondo, iTween.Hash("y", -10f, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(casillasPersonajes, iTween.Hash("y", -15.7f, "time", 1.5f, "easetype", "easeOutQuint"));
        columnasArray[0].SetActive(true);
        columnasArray[1].SetActive(true);
        if (playersNum > 2)
        {
            columnasArray[2].SetActive(true);
            if(playersNum > 3)
            {
                columnasArray[3].SetActive(true);
            }
        }
        if (playersNum < 4)
        {
            columnasArray[3].SetActive(false);
            if (playersNum < 3)
            {
                columnasArray[2].SetActive(false);
            }
        }
        iTween.MoveTo(columnas, iTween.Hash("y", -35, "time", 3f, "easetype", "easeOutQuint"));

        MenuPersonajes();
    }

    private void MenuPersonajes()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            isNumSelected = !isNumSelected;
            iTween.MoveTo(fondo, iTween.Hash("y", -700, "time", 1.5f, "easetype", "easeOutQuint"));
            iTween.MoveTo(casillasPersonajes, iTween.Hash("y", -200, "time", 1.5f, "easetype", "easeOutQuint"));
            iTween.MoveTo(columnas, iTween.Hash("y", -200, "time", 3f, "easetype", "easeOutQuint"));
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -75, "time", 1.5f, "easetype", "easeOutQuint"));
            
        }*/
    }

    private void OnUp()
    {
        if (!play)
        {
            selectedButton = Mathf.Clamp(selectedButton - 1, 0, botonesMain.Length - 1);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }
    }

    private void OnDown()
    {
        if (!play)
        {
            selectedButton = Mathf.Clamp(selectedButton + 1, 0, botonesMain.Length - 1);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }
        
    }

    private void OnLeft()
    {
        if(play && !isNumSelected)
        {
            playersNum = Mathf.Clamp(playersNum - 1, 2, 4);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }
        
    }

    private void OnRight()
    {
        if (play && !isNumSelected)
        {
            playersNum = Mathf.Clamp(playersNum + 1, 2, 4);
            audioPlay.clip = sonidos[1];
            audioPlay.Play();
        }
    }

    private void OnSelect()
    {

        if (!play){
            switch (selectedButton)
            {
                case 0:
                    audioPlay.clip = sonidos[0];
                    audioPlay.Play();
                    play = true;
                    break;
                case 1:
                    audioPlay.clip = sonidos[0];
                    audioPlay.Play();

                    break;
                case 2:
                    audioPlay.clip = sonidos[0];
                    audioPlay.Play();
                    SceneManager.LoadScene("Sample");
                    Application.Quit();
                    break;
            }
        } else if(!isNumSelected)
        {
            isNumSelected = true;
            audioPlay.clip = sonidos[0];
            audioPlay.Play();
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -26, "time", 1.5f, "easetype", "easeOutQuint"));

            selectors = new GameObject[playersNum];

            for(int i=0; i<selectors.Length; i++)
            {
                selectors[i]=Instantiate(selectorGO);
            }
        }
    }

    private void OnBack()
    {
        if (play && !isNumSelected)
        {
            play = !play;
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -26, "time", 1.5f, "easetype", "easeOutQuint"));
            for (int i = 0; i < botonesMain.Length; i++)
            {
                iTween.MoveTo(botonesMain[i], iTween.Hash("x", 0, "time", 1.5f, "easetype", "easeOutQuint"));
            }
        }

        if (isNumSelected)
        {
            isNumSelected = !isNumSelected;
            iTween.MoveTo(fondo, iTween.Hash("y", -162.6, "time", 1.5f, "easetype", "easeOutQuint"));
            iTween.MoveTo(casillasPersonajes, iTween.Hash("y", -34, "time", 1.5f, "easetype", "easeOutQuint"));
            iTween.MoveTo(columnas, iTween.Hash("y", -70, "time", 3f, "easetype", "easeOutQuint"));
            iTween.MoveTo(playersNumSelector, iTween.Hash("y", -7.2, "time", 1.5f, "easetype", "easeOutQuint"));

            

            for (int i = 0; i < selectors.Length; i++)
            {
                Destroy(selectors[i]);
            }
            Array.Clear(selectors, 0, selectors.Length);

        }

        
    }

    void ButtonDelay(bool button)
    {
        button = true;
        StartCoroutine(WaitSecs(2f));
        button = false;
    }

    IEnumerator WaitSecs(float time)
    {
        yield return new WaitForSeconds(time);
    }

}

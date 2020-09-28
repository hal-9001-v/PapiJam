using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{   


    public GameObject fondo;

    public AudioClip[] sonidos;
    public AudioSource audioPlay;

    public GameObject[] botonesMain;
    public GameObject flechita;

    public int numberOfPlayers;
    public GameObject playersNumSelector;
    public Sprite[] numsSprites;
    public GameObject numberGO;

    public GameObject columnas;
    public GameObject[] columnasArray;
    public Text playerNumTx;
    public DisconnectedScript[] Disconnected;
    public PlayerInputManagerScript myInputManager;

    //Cosa de la seleccion de personajes

    public GameObject casillasPersonajes;

    public MenuLayer myIntroLayer;

    public MenuLayer myNumberLayer;
    public MenuLayer myTutorialLayer;
    public MenuLayer mySelectionLayer;

    private MenuLayer currentLayer;

    private MenuButton currentButton;
    public int currentPlayer;
    //public Image
    private void Awake()
    {        
        
        Disconnected = GetComponentsInChildren<DisconnectedScript>();
        audioPlay.volume = 0.05f;
        currentLayer = myIntroLayer;
    }

  /*  void TESTSELECCIONPERS()
    {
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
    }*/

    private void hideMainMenu()
    {

        iTween.MoveTo(botonesMain[0], iTween.Hash("x", 45, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[1], iTween.Hash("x", -45, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[2], iTween.Hash("x", 45, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(botonesMain[3], iTween.Hash("x", 45, "time", 1.5f, "easetype", "easeOutQuint"));


    }

    private void selectButton(GameObject button, bool followArrow)
    {
        if (followArrow)
        {
            button.transform.localScale = new Vector2(1.2f, 1.2f);
            flechita.transform.position = button.transform.position;

            flechita.transform.parent = button.transform;
            flechita.transform.localScale = new Vector2(0.4f, 0.4f);
        }
        else
        {
            button.transform.localScale = new Vector2(1.0f, 1.0f);
            flechita.transform.localScale = new Vector2(0.4f, 0.4f);
        }
    }


    public void showStartMenu()
    {
        iTween.MoveTo(botonesMain[3], iTween.Hash("x", -20, "time", 1.5f, "easetype", "easeOutQuint"));
        for (int i = 0; i < 3; i++)
        {
            iTween.MoveTo(botonesMain[i], iTween.Hash("x", 0, "time", 1.5f, "easetype", "easeOutQuint"));
        }
    }

    void showPlayerNumberSelector()
    {
        iTween.MoveTo(playersNumSelector, iTween.Hash("y", -7.2, "time", 1.5f, "easetype", "easeOutQuint"));

    }

    public void hidePlayerNumberSelector()
    {

        iTween.MoveTo(playersNumSelector, iTween.Hash("y", -26, "time", 1.5f, "easetype", "easeOutQuint"));

    }

    public void hideCharacterSelection()
    {
        iTween.MoveTo(fondo, iTween.Hash("y", -162.6, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(casillasPersonajes, iTween.Hash("y", -34, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(columnas, iTween.Hash("y", -70, "time", 3f, "easetype", "easeOutQuint"));
        iTween.MoveTo(playersNumSelector, iTween.Hash("y", -7.2, "time", 1.5f, "easetype", "easeOutQuint"));

    }

    public void showCharacterSelection()
    {
        iTween.MoveTo(fondo, iTween.Hash("y", -10f, "time", 1.5f, "easetype", "easeOutQuint"));
        iTween.MoveTo(casillasPersonajes, iTween.Hash("y", -15.7f, "time", 1.5f, "easetype", "easeOutQuint"));
        columnasArray[0].SetActive(true);
        columnasArray[1].SetActive(true);

        //Number of players
        if (myInputManager.playerNum > 2)
        {
            columnasArray[2].SetActive(true);
            if (myInputManager.playerNum > 3)
            {
                columnasArray[3].SetActive(true);
            }
        }
        if (myInputManager.playerNum < 4)
        {
            columnasArray[3].SetActive(false);
            if (myInputManager.playerNum < 3)
            {
                columnasArray[2].SetActive(false);
            }
        }
        iTween.MoveTo(columnas, iTween.Hash("y", -35, "time", 3f, "easetype", "easeOutQuint"));

    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void goToNextLayer()
    {
        //GO TO NUMBER LAYER
        if (currentLayer == myIntroLayer)
        {
            hideMainMenu();
            showPlayerNumberSelector();

            currentLayer = myNumberLayer;

            currentButton = currentLayer.startButton();

            flechita.SetActive(false);


        }
        //GO TO SELECTION LAYER
        else if (currentLayer == myNumberLayer)
        {


            hidePlayerNumberSelector();

            showCharacterSelection();

            currentLayer = mySelectionLayer;

            currentButton = currentLayer.startButton();

            foreach (CharacterSelector cs in FindObjectsOfType<CharacterSelector>())
            {
                cs.GetComponent<SpriteRenderer>().enabled = true;

            }


            startSelectingCharacter();



        }

    }

    public void GoToTutorialLayer(){
            hideMainMenu();
             iTween.MoveTo(botonesMain[6], iTween.Hash("x", 0, "time", 1.5f, "easetype", "easeOutQuint"));
            currentLayer = myTutorialLayer;
    }

        


    public void goToPreviousLayer()
    {
        //GO TO MENU LAYER
        if (currentLayer == myNumberLayer)
        {
            hidePlayerNumberSelector();
            showStartMenu();

            currentLayer = myIntroLayer;

            currentButton = currentLayer.startButton();

            flechita.SetActive(true);
            selectButton(currentButton.gameObject, true);

        }
        //GO TO MENU LAYER
           if (currentLayer == myTutorialLayer)
        {
            showStartMenu();

            currentLayer = myIntroLayer;

            currentButton = currentLayer.startButton();
             iTween.MoveTo(botonesMain[6], iTween.Hash("x", -75, "time", 1.5f, "easetype", "easeOutQuint"));
            flechita.SetActive(true);
            selectButton(currentButton.gameObject, true);

        }
        // GO TO NUMBER LAYER
        else if (currentLayer == mySelectionLayer)
        {
            hideCharacterSelection();
            showPlayerNumberSelector();

            currentLayer = myNumberLayer;
            currentButton = currentLayer.startButton();

            foreach (CharacterSelector cs in FindObjectsOfType<CharacterSelector>())
            {
                cs.GetComponent<SpriteRenderer>().enabled = false;

            }
        }
    }

    public void OnUp(CharacterSelector cs)
    {
        audioPlay.clip = sonidos[0];
        audioPlay.Play();
        

        if (currentLayer != mySelectionLayer)
        {

            if (currentButton == null)
            {
                currentButton = currentLayer.startButton();
            }
            else
            {
                if (currentButton.selectionEffect)
                    selectButton(currentButton.gameObject, false);

                currentButton = currentLayer.getUp();

            }

            if (currentButton.selectionEffect)
                selectButton(currentButton.gameObject, true);

        }

        //CUTRE
        else
        {
            if (cs.myPosition.y == 1)
                cs.myPosition.y = 0;
            else
                cs.myPosition.y = 1;

            cs.setCharacter(mySelectionLayer.xArray[cs.myPosition.x].yArray[cs.myPosition.y].GetComponent<CharacterHolder>());
        }

    }

    public void OnDown(CharacterSelector cs)
    {
        audioPlay.clip = sonidos[0];
        audioPlay.Play();

        if (currentLayer != mySelectionLayer)
        {

            if (currentButton == null)
            {
                currentButton = currentLayer.startButton();
            }
            else
            {
                if (currentButton.selectionEffect)
                    selectButton(currentButton.gameObject, false);
                currentButton = currentLayer.getDown();
            }
            if (currentButton.selectionEffect)
                selectButton(currentButton.gameObject, true);


        }

        //CUTRE
        else
        {
            if (cs.myPosition.y == 1)
                cs.myPosition.y = 0;
            else
                cs.myPosition.y = 1;

            cs.setCharacter(mySelectionLayer.xArray[cs.myPosition.x].yArray[cs.myPosition.y].GetComponent<CharacterHolder>());
        }

    }

    public void OnLeft(CharacterSelector cs)
    {
        audioPlay.clip = sonidos[0];
        audioPlay.Play();

        if (currentLayer != mySelectionLayer)
        {

            if (currentButton == null)
            {
                currentButton = currentLayer.startButton();
            }
            else
            {
                if (currentButton.selectionEffect)
                    selectButton(currentButton.gameObject, false);

                currentButton = currentLayer.getLeft();

            }

            if (currentButton.selectionEffect)
                selectButton(currentButton.gameObject, true);


        }
        else
        {
            if (cs.myPosition.x == 1)
                cs.myPosition.x = 0;
            else
                cs.myPosition.x = 1;

            cs.setCharacter(mySelectionLayer.xArray[cs.myPosition.x].yArray[cs.myPosition.y].GetComponent<CharacterHolder>());
        }
    }

    public void OnRight(CharacterSelector cs)

    {
        audioPlay.clip = sonidos[0];
        audioPlay.Play();


        if (currentLayer != mySelectionLayer)
        {
            if (currentButton == null)
            {
                currentButton = currentLayer.startButton();
            }
            else
            {
                if (currentButton.selectionEffect)
                    selectButton(currentButton.gameObject, false);

                currentButton = currentLayer.getRight();

            }

            if (currentButton.selectionEffect)
                selectButton(currentButton.gameObject, true);

        }
        //CUTRE
        else
        {
            if (cs.myPosition.x == 1)
                cs.myPosition.x = 0;
            else
                cs.myPosition.x = 1;

            cs.setCharacter(mySelectionLayer.xArray[cs.myPosition.x].yArray[cs.myPosition.y].GetComponent<CharacterHolder>());
        }

    }

    public void retakeCharacterSelectors() {
        foreach (CharacterSelector cs in FindObjectsOfType<CharacterSelector>()) {
            cs.transform.parent = cs.myPlayerController.transform;
        
        }
    }

    public void startSelectingCharacter()
    {

        foreach (CharacterSelector cs in FindObjectsOfType<CharacterSelector>())
        {
            cs.myPosition.x = 0;
            cs.myPosition.y = 0;

            cs.setCharacter(mySelectionLayer.xArray[0].yArray[0].GetComponent<CharacterHolder>());

            cs.gameObject.SetActive(true);
        }

    }

    public void OnSelect(CharacterSelector cs)
    {
        audioPlay.clip = sonidos[0];
        audioPlay.Play();

        if (currentLayer != mySelectionLayer)
        {
            if (currentButton != null)
                currentButton.selectionEvent.Invoke();
            else
            {
                currentButton = myIntroLayer.xArray[0].yArray[0];
                selectButton(currentButton.gameObject, true);
                
            }
        }
        else
        {
            Debug.Log("Start Playing");

            retakeCharacterSelectors();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


        }


    }


    public void OnJoin(){

        
        
        myInputManager.setCanJoin(false);
        myInputManager.playersCanQuit(false);
        currentPlayer = myInputManager.playerJoined.PlayerID;
    
    
        switch (currentPlayer){
            case 1:
            foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(255,255,255,255);
            }
            break;
            case 2:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(255,0,0,255);
            }
            break;
            case 3:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(102,52,0,255);
            }
            break;
            case 4:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(0,255,0,255);
            }
            break;
        }

          iTween.MoveTo(botonesMain[5], iTween.Hash("x", 15, "time", 1.5f, "easetype", "easeOutQuint"));
        audioPlay.clip = sonidos[0];
        audioPlay.Play();
        StartCoroutine(EaseButton(botonesMain[5]));
    }

    public IEnumerator EaseButton(GameObject go){
       yield return new WaitForSeconds(1.5f);
        iTween.MoveTo(go, iTween.Hash("x", 50, "time", 1.5f, "easetype", "easeOutQuint"));
        yield return new WaitForSeconds(1f);
        myInputManager.setCanJoin(true);
        myInputManager.playersCanQuit(true);
    }
    public void OnDisconnect(){
            myInputManager.setCanJoin(false);
            myInputManager.playersCanQuit(false);
            currentPlayer = myInputManager.playerRemoved.PlayerID;
          switch (currentPlayer){
            case 1:
            foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(255,255,255,255);
            }
            break;
            case 2:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(255,0,0,255);
            }
            break;
            case 3:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(102,52,0,255);
            }
            break;
            case 4:
             foreach(DisconnectedScript d in Disconnected) {        
                d.mySpriteRenderer.color = new Color32(0,255,0,255);
            }
            break;
        }
        iTween.MoveTo(botonesMain[4], iTween.Hash("x", 15, "time", 1.5f, "easetype", "easeOutQuint"));
        audioPlay.clip = sonidos[2];
        audioPlay.Play();
        StartCoroutine(EaseButton(botonesMain[4]));
    }

    public void OnBack()
    {

        if (currentLayer != null)
        {
            audioPlay.clip = sonidos[0];
            audioPlay.Play();
            currentLayer.backAction.Invoke();
        }

    }

    [System.Serializable]
    public class MenuLayer
    {
        [SerializeField]
        public GOArray[] xArray;
        Vector2Int currentPosition;

        public UnityEvent backAction;

        public MenuLayer()
        {
            currentPosition = new Vector2Int(0, 0);
        }

        public MenuButton startButton()
        {
            currentPosition = Vector2Int.zero;

            return xArray[0].yArray[0];
        }

        public MenuButton getRight()
        {
            if (xArray.Length > (currentPosition.x + 1))
            {
                currentPosition.x += 1;

            }
            else
            {
                currentPosition.x = 0;
            }

            return xArray[currentPosition.x].yArray[currentPosition.y];
        }

        public MenuButton getLeft()
        {
            if (0 <= (currentPosition.x - 1))
            {
                currentPosition.x -= 1;

            }
            else
            {
                currentPosition.x = xArray.Length - 1;
            }

            return xArray[currentPosition.x].yArray[currentPosition.y];

        }


        public MenuButton getDown()
        {
            if (xArray[currentPosition.x].yArray.Length > (currentPosition.y + 1))
            {
                currentPosition.y += 1;

            }
            else
            {
                currentPosition.y = 0;
            }

            return xArray[currentPosition.x].yArray[currentPosition.y];

        }

        public MenuButton getUp()
        {
            if (0 <= (currentPosition.y - 1))
            {
                currentPosition.y -= 1;
            }
            else
            {
                currentPosition.y = xArray[currentPosition.x].yArray.Length - 1;
            }
            return xArray[currentPosition.x].yArray[currentPosition.y];

        }

        [Serializable]
        public class GOArray
        {

            public MenuButton[] yArray;
        }

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroyStuff : MonoBehaviour
{
   private void Awake() {
       foreach (GameObject go in FindObjectsOfType<GameObject>()){
           
           Destroy(go);

       } SceneManager.LoadScene(0);

   }
}

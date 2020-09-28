using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterContainer : MonoBehaviour
{
    public GameObject[] skins;

    public GameObject finalSkin;

    public void selectSkin(int index) {
        if (index >= 0 || index < skins.Length) {
            finalSkin = skins[index];

            for (int i = 0; i < skins.Length; i++) {
                if (i == index) continue;
                
                Destroy(skins[i]);
            }
        }
    
    }

    


}

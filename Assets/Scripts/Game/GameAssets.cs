using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
public class GameAssets : MonoBehaviour
{

    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null)
            {
                _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            }
                return _i;
        }
    }


    public SoundAudioClip[] soundAudioClipArryay;
    public Material[] mArray;
    public Mesh[] meshArray;
    public Material[] mOArray;
    public Mesh[] meshOArray;
    public GameObject[] particles;
    public Sprite[] healthArray;
    public GameObject pauseImage;
    
    //public Sprite[] hpArray;

    //public ParticleSystem[] ps;
    [System.Serializable]
    public class SoundAudioClip {

        public SoundManager.Sound sound;
        public AudioClip audioClip;


    } 


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
    public Mesh cloudSwordModel;
    public Material cloudSwordMaterial;
    public Material[] mArray;
    public Mesh[] meshArray;
    public Material[] mOArray;
    public Mesh[] meshOArray;
    
    
    //public Sprite[] hpArray;

    //public ParticleSystem[] ps;
    [System.Serializable]
    public class SoundAudioClip {

        public SoundManager.Sound sound;
        public AudioClip audioClip;


    } 


}

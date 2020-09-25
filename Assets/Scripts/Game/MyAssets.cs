using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AssetScript", order = 1)]
public class MyAssets: ScriptableObject
{
    public Mesh cloudSwordModel;
    public Material cloudSwordMaterial;

    public Material[] characterMaterialArray = new Material[4];
    public Mesh[] characterMeshArray;
    public Material[] orbitalMaterialArray;
    public Mesh[] orbitalMeshArray;

    

    //public ParticleSystem[] ps;
    [System.Serializable]
    public class SoundAudioClip
    {

        public SoundManager.Sound sound;
        public AudioClip audioClip;


    }

    [System.Serializable]
    public class container {
        public Material[] mArray;
        public Mesh[] meshArray;
        public Material[] mOArray;
        public Mesh[] meshOArray;

    }

}

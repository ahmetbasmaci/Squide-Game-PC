using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [HideInInspector] public AudioSource sorce;

    public AudioClip clip;

    [Range(.1f, 1)] public float pitch = 1;

    [Range(0, 1)] public float spatialBlend = 1;

    [Range(0, 1)] public float volume = 1;

    public bool loob = false;

    public SoundsNames name;

}
public enum SoundsNames
{
    rifleFire,
    enemyGirl_bokuva,
    enemyGirl_robot,
    footStep,
    level1Start,
    die
}

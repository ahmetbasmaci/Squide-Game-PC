using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singelton
    public static SoundManager instance;
    private void Awake()
    {
        audioParent = new GameObject();

        if (instance == null)
            instance = this;
    }
    #endregion

    public GameObject pooledObject;
    public int pooledAmound = 10;
    public bool willGrow;
    List<GameObject> pooledObjects = new List<GameObject>();
    GameObject audioParent ;


    public List<Sound> sounds=new List<Sound>();

    
    private void Start()
    {

        CreateSoundsObjects();
    }
    void CreateSoundsObjects()
    {

        audioParent.name = "Audio Parnt";

        for (int i = 0; i < pooledAmound; i++)
        {
            GameObject newObj = Instantiate(pooledObject);
            newObj.transform.SetParent(audioParent.transform);
            newObj.SetActive(false);

            pooledObjects.Add(newObj);
        }
    }
    public GameObject GetPooledObject()
    {
        foreach (var newObj in pooledObjects)
            if (!newObj.activeInHierarchy)
                return newObj;

        if (willGrow)
        {
            GameObject newObj = Instantiate(pooledObject);
            newObj.transform.SetParent(audioParent.transform);
            newObj.SetActive(false);
            pooledObjects.Add(newObj);

            return newObj;
        }
        else
        {
            return null;
        }
    }

    public void Play(Vector3 newPos, SoundsNames newSoundName)
    {
        GameObject currentObj = GetPooledObject();
        AudioSource currentSorce = currentObj.GetComponent<AudioSource>();

        foreach (var sound in sounds)
        {
            if (sound.name == newSoundName)
            {
                Sound currentSound = sound;

                if (newSoundName == SoundsNames.footStep  || newSoundName==SoundsNames.die)
                    currentSound=GetRandomSound(newSoundName);

                currentSorce.clip = currentSound.clip;
                currentSorce.pitch = currentSound.pitch;
                currentSorce.volume = currentSound.volume;
                currentSorce.loop = currentSound.loob;
                currentSorce.spatialBlend = currentSound.spatialBlend;

                break;
            }
        }

        currentObj.transform.position = newPos;
        currentObj.SetActive(true);

        StartCoroutine(DesableAudio(currentObj));

    }
    public void Play(Vector3 newPos, SoundsNames newSoundName, float newPitch)
    {
        GameObject currentObj = GetPooledObject();
        AudioSource currentSorce = currentObj.GetComponent<AudioSource>();

        foreach (var sound in sounds)
        {
            if (sound.name == newSoundName)
            {
                sound.pitch = newPitch;

                currentSorce.clip = sound.clip;
                currentSorce.pitch = sound.pitch;
                currentSorce.loop = sound.loob;
                currentSorce.spatialBlend = sound.spatialBlend;
                currentSorce.volume = sound.volume;
                break;
            }
        }

        currentObj.transform.position = newPos;
        currentObj.SetActive(true);
        StartCoroutine(DesableAudio(currentObj));

    }
    
    public Sound GetRandomSound(SoundsNames newSoundName)
    {
        List<Sound> footStepsSounds = new List<Sound>();
        foreach (var sound in sounds)
            if (sound.name == newSoundName)
                footStepsSounds.Add(sound);

        Sound randomSound = footStepsSounds[Random.Range(0, footStepsSounds.Count - 1)];
        randomSound.pitch = Random.Range(.7f, 1.2f);
        randomSound.volume = Random.Range(.7f, 1.2f);

        return randomSound;
    }
    IEnumerator DesableAudio(GameObject currentObj)
    {
        while (currentObj.GetComponent<AudioSource>().isPlaying)
        {
            yield return new WaitForSeconds(.2f);
        }

        currentObj.SetActive(false);

    }

}

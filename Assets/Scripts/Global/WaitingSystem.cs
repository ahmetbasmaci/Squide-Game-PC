using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class WaitingSystem : MonoBehaviour
{

    public GameObject txt_1;
    public GameObject txt_2;
    public GameObject txt_3;

    void Awake()
    {
        
    }
	
    void Start()
    {
        StartCoroutine(StartWaiting());
    }
    
    IEnumerator StartWaiting()
    {
        txt_3.SetActive(true);
        yield return new WaitForSeconds(1);
        txt_3.SetActive(false);


        txt_2.SetActive(true);
        yield return new WaitForSeconds(1);
        txt_2.SetActive(false);


        txt_1.SetActive(true);
        yield return new WaitForSeconds(1);
        txt_1.SetActive(false);
    }
}

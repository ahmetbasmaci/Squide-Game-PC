using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl2_Btn_Press : MonoBehaviour
{
    public int toFront = 1;
    private void Start()
    {
        Destroy(gameObject, 1.5f);


    }
    public void ApplyPress()
    {

        Vector3 newPos = Lvl2_Manager.instance.transform.position + (-Lvl2_Manager.instance.transform.forward *toFront* Lvl2_Manager.instance.pressSpeed);


        Lvl2_Manager.instance.transform.position = Vector3.MoveTowards(Lvl2_Manager.instance.transform.position, newPos, 1f);


        Destroy(gameObject);
    }
}

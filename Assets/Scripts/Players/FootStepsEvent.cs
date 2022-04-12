using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStepsEvent : MonoBehaviour
{
    public void PlayFootStepSound()
    {
         SoundManager.instance.Play(transform.position, SoundsNames.footStep);
    }
}

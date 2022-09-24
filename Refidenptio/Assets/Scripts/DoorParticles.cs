using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorParticles : MonoBehaviour
{
    public ParticleSystem particleOpen;
    public ParticleSystem particleClose;


    public void PlayParticleOpen()
    {
        particleOpen.Play();
    }

    public void StopParticleOpen()
    {
        particleOpen.Stop();
    }

    public void PlayParticleClose()
    {
        particleClose.Play();
    }

    public void StopParticleClose()
    {
        particleClose.Stop();
    }
}

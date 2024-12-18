using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingwinChirpScript : MonoBehaviour
{
    AudioSource chirp;

    private void Start()
    {
        chirp = GetComponent<AudioSource>();
    }

    public void PlayChirp()
    {
        chirp.Play();
    }
}

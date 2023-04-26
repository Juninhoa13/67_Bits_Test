using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXAudio : MonoBehaviour
{
    public AudioSource sfxAudio;

    Animator audioAnim;

    [Header("Punch")]
    [SerializeField] AudioClip PunchClip;
    [SerializeField] [Range(0f, 1f)] float PunchVolume = 1f;

    [Header("Moedas")]
    [SerializeField] AudioClip MoedasClip;
    [SerializeField] [Range(0f, 1f)] float MoedasVolume = 1f;

    public void PlayPunchClip()
    {
        sfxAudio.PlayOneShot(PunchClip, PunchVolume);
    }

    public void PlayMoedasClip()
    {
        sfxAudio.PlayOneShot(MoedasClip, MoedasVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}

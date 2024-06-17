using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance;

    public Transform Camera;
    public AudioClip ShootSFX;
    public AudioClip SheepHitSFX;
    public AudioClip SheepDropSFX;
    public AudioSource audioSource;

    private void Awake()
    {
        Instance = this;

    }
        public void PlayShootSound()
        {
            audioSource.PlayOneShot(ShootSFX);
        }

        public void PlaySheepHitSound()
        {
            audioSource.PlayOneShot(SheepHitSFX);
        }

        public void PlaySheepDroppedSound()
        {
            audioSource.PlayOneShot(SheepDropSFX);
        }

    
}
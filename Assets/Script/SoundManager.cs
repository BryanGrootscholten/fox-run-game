using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip pJump;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        pJump = Resources.Load<AudioClip> ("Player_Jump");
        audioSource = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string sound)
    {
        switch (sound)
        {
            case "pJump":
                audioSource.PlayOneShot(pJump);
                break;
            default:
                break;
        }
    }
}

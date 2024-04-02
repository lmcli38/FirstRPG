using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] float sfxMinmumDistance;
    [SerializeField] AudioSource[] sfx;
    [SerializeField] AudioSource[] bgm;

    public bool playBGM;
    private int bgmIndex;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy the new instance
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager across scenes
        }
    }

    private void Update()
    {
        if(!playBGM) 
            StopALLBGM();
        else
        {
            if (!bgm[bgmIndex].isPlaying)
                PlayBGM(bgmIndex);
        }
    }
    public void PlaySFX(int _sfxIndex, Transform _source)
    {
        if (sfx[_sfxIndex].isPlaying)
            return;

        if(_source != null && Vector2.Distance(PlayerManager.instance.player.transform.position,_source.position)>sfxMinmumDistance)
            return;

        if(_sfxIndex < sfx.Length)
            sfx[_sfxIndex].Play();
    }

    public void StopSFX(int _index) => sfx[_index].Stop();

    public void PlayRandomBGM()
    {
        bgmIndex = Random.Range(0, bgm.Length);
        PlayBGM(bgmIndex);
    }

    public void PlayBGM(int _bgmIndex)
    {
        bgmIndex = _bgmIndex;

        StopALLBGM();
        bgm[bgmIndex].Play();
    }

    public void StopALLBGM()
    {
        for (int i = 0; i < bgm.Length; i++)
        {
            bgm[i].Stop();
        }
    }
}

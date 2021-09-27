using System.Collections;

using System.Collections.Generic;

using UnityEngine;


[System.Serializable]

public class AudioStruct
{

    public AudioClip audioClip;

    public float delayTime;

    public bool loop = false;

    [Range(0.0f, 1.0f)]

    public float volume = 1.0f;

}

public class AudioPlayList : MonoBehaviour
{

    public AudioStruct[] audioStructList;

    private List<AudioSource> audioList = new List<AudioSource>();

    // 脚本使能的时候，开始播放 AudioStruct[] 队列

    void OnEnable()
    {

        foreach (var item in audioStructList)

        {

            StartCoroutine(PlayAudioClip(item));

        }

    }

    // 脚本失能的时候，停止所有的协程，并销毁添加的音频源组件

    void OnDisable()
    {

        StopAllCoroutines();

        foreach (var item in audioList)

        {

            Destroy(item);

        }

    }

    // 使用协程播放的音频队列

    IEnumerator PlayAudioClip(AudioStruct audioStructItem)
    {

        //等待播放的延时时间

        yield return new WaitForSeconds(audioStructItem.delayTime);

        // 添加音频播放源，并且把设置的相关数据添加到音频播放源中，然后播放

        AudioSource audio = gameObject.AddComponent<AudioSource>();

        audioList.Add(audio);

        audio.clip = audioStructItem.audioClip;

        audio.loop = audioStructItem.loop;

        audio.volume = audioStructItem.volume;

        audio.Play();

    }

}
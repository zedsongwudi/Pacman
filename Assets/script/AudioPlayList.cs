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

    // �ű�ʹ�ܵ�ʱ�򣬿�ʼ���� AudioStruct[] ����

    void OnEnable()
    {

        foreach (var item in audioStructList)

        {

            StartCoroutine(PlayAudioClip(item));

        }

    }

    // �ű�ʧ�ܵ�ʱ��ֹͣ���е�Э�̣���������ӵ���ƵԴ���

    void OnDisable()
    {

        StopAllCoroutines();

        foreach (var item in audioList)

        {

            Destroy(item);

        }

    }

    // ʹ��Э�̲��ŵ���Ƶ����

    IEnumerator PlayAudioClip(AudioStruct audioStructItem)
    {

        //�ȴ����ŵ���ʱʱ��

        yield return new WaitForSeconds(audioStructItem.delayTime);

        // �����Ƶ����Դ�����Ұ����õ����������ӵ���Ƶ����Դ�У�Ȼ�󲥷�

        AudioSource audio = gameObject.AddComponent<AudioSource>();

        audioList.Add(audio);

        audio.clip = audioStructItem.audioClip;

        audio.loop = audioStructItem.loop;

        audio.volume = audioStructItem.volume;

        audio.Play();

    }

}
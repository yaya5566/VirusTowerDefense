using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class audioItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioClip clip, UnityAction callback = null, bool isLoop = false)
    {
        AudioSource _audio = GetComponent<AudioSource>();
        _audio.clip = clip;
        _audio.loop = isLoop;
        _audio.Play();
        StartCoroutine(AudioPlayFinished(_audio.clip.length, callback));
    }

    private IEnumerator AudioPlayFinished(float time, UnityAction callback)
    {
   

    yield return new WaitForSeconds(time);
    //声音播放完毕后之下往下的代码  

    # region   声音播放完成后执行的代码
    Destroy(gameObject, 0);
    print("声音播放完毕，继续向下执行");
 
    #endregion
    }
}

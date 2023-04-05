using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioList : MonoBehaviour
{
    public AudioClip [] tracks;
    private float musicVolume = 0.2f;
    private AudioSource source;
    public TMP_Text musicTitle;

    void Start ( )
    {
        source = GetComponent<AudioSource> ( );
        PlayRandomTrack ( );

    }
    void PlayRandomTrack ( )
    {
        int trackIndex = Random.Range ( 0, tracks.Length );
        AudioClip clip = tracks [trackIndex];
        source.clip = clip;
        source.Play ( );
        StartCoroutine ( DisplayMusicTitleForSeconds ( source.clip.name, 5.0f ) );
    }

    void Update ( )
    {
        
        if ( !source.isPlaying )
        {
            PlayRandomTrack ( );
        }

    }
    IEnumerator DisplayMusicTitleForSeconds ( string title, float seconds )
    {
        // Отображение названия трека
        musicTitle.text = "Music: " + title;

        // Плавное появление текста
        float fadeInDuration = 1.0f;
        float fadeInStartTime = Time.time;
        while ( Time.time < fadeInStartTime + fadeInDuration )
        {
            float alpha = Mathf.Lerp ( 0.0f, 1.0f, ( Time.time - fadeInStartTime ) / fadeInDuration );
            musicTitle.color = new Color ( musicTitle.color.r, musicTitle.color.g, musicTitle.color.b, alpha );
            yield return null;
        }

        // Ожидание указанного времени
        yield return new WaitForSeconds ( seconds );

        // Плавное исчезновение текста
        float fadeOutDuration = 1.0f;
        float fadeOutStartTime = Time.time;
        while ( Time.time < fadeOutStartTime + fadeOutDuration )
        {
            float alpha = Mathf.Lerp ( 1.0f, 0.0f, ( Time.time - fadeOutStartTime ) / fadeOutDuration );
            musicTitle.color = new Color ( musicTitle.color.r, musicTitle.color.g, musicTitle.color.b, alpha );
            yield return null;
        }

        // Скрытие названия трека
        musicTitle.text = "";
    }
    public void SetVolume ( float vol )
    {
        musicVolume = vol;
        source.volume = musicVolume;
    }

}

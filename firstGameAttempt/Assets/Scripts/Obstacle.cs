using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{
    AudioSource _crashAudioSource;
    AudioSource _dieAudioSource;
    private PlayerInfo _playerInfo;


    private void Awake()
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();

        // Farklý AudioSource'larý doðru sýralama ile ata
        _crashAudioSource = audioSources[1]; 
        _dieAudioSource = audioSources[0];   


        _playerInfo = FindObjectOfType<PlayerInfo>(); // PlayerInfo referansýný bul
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(PlayerInfo.PlayerHP > 20)
            {

                PlayerInfo.ChangeHP(-20, _playerInfo);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                _crashAudioSource.Play();
            }
            else
            {
                StartCoroutine(HandleDeath());
            }
        }
    }
    private IEnumerator HandleDeath()
    {
        Time.timeScale = 0f;
        _dieAudioSource.Play();
        yield return new WaitForSecondsRealtime(_dieAudioSource.clip.length);
        Time.timeScale = 1f;
        PlayerInfo.ChangeHP(100 - PlayerInfo.PlayerHP, _playerInfo);
        SceneManager.LoadScene(0); 
    }
}

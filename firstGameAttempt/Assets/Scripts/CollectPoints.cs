using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectPoints : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Diamond"))
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: "+ score.ToString();
            _audioSource.Play();
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] private AudioClip _collectedSound;
    [Range(0, 1)] [SerializeField] private float _soundVolume;

    private AudioSource _audioSource;

    [SerializeField] public float powerUpTime = 5f;

    void Start()
    {
        _audioSource = GameManager.instance.GetComponent<AudioSource>();
    }

    public abstract void AddPowerUp(Collider2D playerCollision);

    public abstract void RemovePowerUp();

    private void EndPowerUpTime()
    {
        RemovePowerUp();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(_collectedSound, _soundVolume);
            gameObject.SetActive(false);
            AddPowerUp(collision);
            Invoke("EndPowerUpTime", powerUpTime);
        }
    }
}

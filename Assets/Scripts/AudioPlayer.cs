using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer: MonoBehaviour
{
   [Header("Shooting")] 
   [SerializeField] private AudioClip shootingClip;

   [SerializeField] [Range(0, 1)] private float shootingVolume = 1f;
   
   [Header("Damage")]
   [SerializeField] private AudioClip damageClip;
   [SerializeField] [Range(0, 1)] private float damageVolume = 1f;
   
   static AudioPlayer instance; // if you have more audio sounds, it might affect the game

   void Awake()
   {
      ManageSingleton();
   }
   void ManageSingleton()
   {
      if (instance != null)
      {
         gameObject.SetActive(false);
         Destroy(gameObject);
         
      }
      else
      {
         instance = this;
         DontDestroyOnLoad(gameObject);
      }
      
   }
   public void PlayShootingClip()
   {
      PlayClip(shootingClip, shootingVolume);
   }

   public void PlayDamageClip()
   {
      PlayClip(damageClip, damageVolume);
   }

   void PlayClip(AudioClip clip, float volume)
   {
      if (clip != null)
      {
         Vector3 cameraPosition = Camera.main.transform.position;
         AudioSource.PlayClipAtPoint(clip, cameraPosition, volume);
      }
   }
   
}

using System;
using UnityEngine;

public class GlobalEvents : MonoBehaviour
{
    public static GlobalEvents Instance;
     private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

     public event Action onProjectileHit;

     public void OnProjectileHit()
     {
         if (onProjectileHit != null)
         {
             onProjectileHit();
         }
     }
}

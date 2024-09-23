using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
   [SerializeField] private Slider slider;
   [SerializeField] Camera camera;
   [SerializeField] Transform target;

   public void UpdateHealthBar(float currentValue, float maxValue)
   {
    slider.value = currentValue / maxValue;
   }

   void Update()
    {
        transform.rotation = GetComponent<Camera>().transform.rotation;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntos : MonoBehaviour
{
   public int piezas;
   public Text textoPiezas;

   private void Update()
   {
      Contador();
   }

   public void Contador()
   {
      textoPiezas.text = "Piezas: " + piezas.ToString() + " de 5";
   }
}

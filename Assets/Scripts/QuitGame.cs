using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGame : MonoBehaviour
{

 public void ExitGame()
 {
    Application.Quit();
 }
 void start()
 {
   Cursor.visible = true;
 }
}

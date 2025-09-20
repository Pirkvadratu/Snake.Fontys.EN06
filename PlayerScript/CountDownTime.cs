using System.Collections.Generic; 

using UnityEngine; 

using UnityEngine.SceneManagement; 

using TMPro; 

 

public class CountDownTimer : MonoBehaviour 

{ 

public float countdown = 60f; // starting time in seconds 

public TMP_Text text; 

void Update() 

{ 

if (countdown > 0f) 

{ 

countdown -= Time.deltaTime; 

 

if (countdown < 0f) 

countdown = 0f; 

 

// Format MM:SS 

int minutes = Mathf.FloorToInt(countdown / 60f); 

int seconds = Mathf.FloorToInt(countdown % 60f); 

text.text = string.Format("{0:00}:{1:00}", minutes, seconds); 

} 

 if (text != null)
    {
    if (countdown > Tags.pinkThreshold)
    text.color = Tags.pinkColor;
    else if (countdown > Tags.redThreshold)
    text.color = Tags.orangeColor;
    else
    text.color = Tags.redColor;

} 

} 
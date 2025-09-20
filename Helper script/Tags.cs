using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Tag

{
    public static string wall;
    public static string SnakeHeadController;
    public static string Floor;
    public static string FirstObject;
    public static string SecondObject;

}
public static class Tags
{
    public const string FOOD = "Food";
    public const string Walll = "Wall";
    public const string Trap = "Trap";

     // ["Ui timer settings"]
    internal static Color pinkColor;
    internal static Color orangeColor;
    internal static Color redColor;

    // timer threshold
    public const float pinkTreshold = 20f;
    public const float orangeTreshold = 30f;
    public const float redTreshold = 10f;

    // // timer colours
    // public static readonly Color pinkColor   = new Color(1f, 0.75f, 0.8f);
    // public static readonly Color orangeColor = new Color(1f, 0.5f, 0f);
    // public static readonly Color redColor    = Color.red;
    
}
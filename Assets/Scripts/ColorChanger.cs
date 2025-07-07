using UnityEngine;

public static class ColorChanger
{
    public static Color GetRandomColor() =>
        Random.ColorHSV();
}
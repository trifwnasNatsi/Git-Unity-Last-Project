using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzlePieceScript : Interactable
{
    public Material mat;

    public enum Type
    {
        Blue = 0,
        Green,
        Red,
        Yellow
    };

    public Type type;

    public MeshRenderer mesh;

    public void ToggleOff()
    {
        mesh.enabled = false;
    }

    public void ToggleOn()
    {
        mesh.enabled = true;
    }
}

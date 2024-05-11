using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketScript : Interactable
{
    public bool isPuzzleCorrect = false;

    public bool isItColored = false;

    public MeshRenderer cube;
    public Material material;

    public Material matCheck = null;

    PuzzlePieceScript currentColor;

    [SerializeField] PuzzlePieceScript.Type targetType;

    //public int socketID;

    public static int socketCount;


    void Start()
    {
        //socketCount++;

        //socketID = socketCount;

        cube.enabled = false;
    }

    public bool TryConnect(PuzzlePieceScript piece)
    {
        /*if (matCheck != null)
        {
            piece.mesh.enabled = true;
        }*/
            //if (piece.type != targetType) return false;

        cube.enabled = true;
        isItColored = true;
        matCheck = piece.mat;
        cube.material = piece.mat;
        if (piece.type == targetType) {
            socketCount++;
        }

        if (piece.type != targetType) isPuzzleCorrect = true;

        return true;
    }

    // Start is called before the first frame update

    private void Update()
    {
        //Debug.Log(socketID);
    }

}

/*[SerializedField] private Color _color;
public Color color => _color;

public Color color { get { return _color; } }*/

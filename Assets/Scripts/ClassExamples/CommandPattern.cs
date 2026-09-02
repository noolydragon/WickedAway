using System;
using UnityEngine;

[DisallowMultipleComponent]

public class CommandPattern : MonoBehaviour
{
    public float moveDistance = 1.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public interface ICommand
{
    void Execute();
    void Undo();
}

public class MoveCommand : ICommand
{
    private readonly Action executeAction; //basically is a void pointer, like function pointer, can set executeAction to be any function
    public void Execute()
    {
        
    }

    public void Undo()
    {
        
    }
}

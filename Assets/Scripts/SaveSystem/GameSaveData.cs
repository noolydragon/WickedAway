using UnityEngine;
using System;
using System.Collections.Generic;

public class SerializableVector3
{
    public float x, y, z;
    public SerializableVector3(Vector3 v) { x = v.x; y = v.y; z = v.z; }
    public Vector3 ToVector3() => new Vector3(x, y, z);
}

public class ObjectSaveData
{
    public string objectID;
    public bool isUnfrozen;
    public int currentPatrolPoint;
    public SerializableVector3 position;
}
[Serializable]
public class GameSaveData
{
    public int currentLevel;
    public List<ObjectSaveData> savedObjects = new List<ObjectSaveData>();
}

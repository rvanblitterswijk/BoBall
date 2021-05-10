using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/CheckpointSave")]
public class CheckpointSave : ScriptableObject
{
    public Vector3 checkpoint;
    public bool checkpointIsSet = false;
}

using UnityEngine;
using System.Collections;

public class MemoryArrayTask : MonoBehaviour 
{
    public TaskPhase[] phases;
    private TaskPhase _currentPhase;

    public MemoryArray memoryArrayPrefab;

    public Transform stage;
    //public Arrow arrow;

    private float _timer;

	void Start () 
    {
        CreateMemoryArrays();
	}
    
    private void CreateMemoryArrays()
    {
        int itemCount = Random.Range( 1, 11 );
        
        MemoryArray newMemoryArray = Instantiate( memoryArrayPrefab ) as MemoryArray; 
        newMemoryArray.transform.position += Vector3.right * memoryArrayPrefab.unitSize * 3f; 
        newMemoryArray.Initialize( itemCount );

        newMemoryArray = Instantiate( memoryArrayPrefab ) as MemoryArray; 
        newMemoryArray.transform.position += Vector3.left * memoryArrayPrefab.unitSize * 3f; 
        newMemoryArray.Initialize( itemCount );
    }
}

[System.Serializable]
public class TaskPhase
{
    public string name;
    public float duration;
}

using UnityEngine;
using System.Collections;

public class MemoryArrayTask : MonoBehaviour 
{
	void Start () 
    {
        StartCoroutine( BeginMemoryTask() );	
	}
    
    private IEnumerator BeginMemoryTask()
    {
        yield return 0;
    }
}

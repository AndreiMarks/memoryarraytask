using UnityEngine;
using System.Collections;

public class PuppyArray : MonoBehaviour 
{
    public Puppy puppyPrefab;
    public int xPuppies;
    public int yPuppies;
    public float xSpacing;
    public float ySpacing;

    void Start()
    {
        FillPuppyArray();
    }

    private void FillPuppyArray()
    {
        Vector3 spawnPosition = Vector3.zero;
        for( int x = 0; x < xPuppies; x++ )
        {
            for ( int y = 0; y < yPuppies; y++ )
            {
                spawnPosition = new Vector3( x * xSpacing, y * ySpacing, 0f );
                Puppy newPuppy = Instantiate( puppyPrefab, spawnPosition, Quaternion.identity ) as Puppy; 
                newPuppy.transform.SetParent( this.transform );
                newPuppy.transform.localPosition = spawnPosition;
            }
        }
    }
}

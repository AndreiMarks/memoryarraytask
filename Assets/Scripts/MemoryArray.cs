using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MemoryArray : MonoBehaviour 
{
    public Square squarePrefab;
    public Color[] squareColors;
    public Bounds arrayBounds;

    private Square[] _squares;

    public void Initialize( int squareCount )
    {
        arrayBounds = new Bounds( transform.position, new Vector3( unitSize * 3f , unitSize * 6.3f, 0f ) );
        squareProximityLimit = _squareProximityLimit;
        GenerateSquares( squareCount );
    }

    private void GenerateSquares( int squareCount )
    {
	    Debug.Log( squareCount );
        
        _squares = new Square[squareCount];
        List<Color> availableColors = GetAvailableColors();
        for( int i = 0; i < squareCount; i++ )
        {
            Vector3 randomPosition = GetRandomPosition();
            Square newSquare = Instantiate( squarePrefab, randomPosition, Quaternion.identity ) as Square;

            Color randomColor = availableColors[ Random.Range( 0, availableColors.Count ) ];
            availableColors.Remove( randomColor );
            
            newSquare.Initialize( randomColor );
            _squares[i] = newSquare;
        }
    }

    private List<Color> GetAvailableColors()
    {
        List<Color> availableColors = new List<Color>();

        foreach( Color c in squareColors )
        {
            availableColors.Add( c );
            availableColors.Add( c );
        }

        return availableColors;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 newPos = GetRandomPositionWithinBounds();

        int check = 0;
        while ( CheckProximityViolation( newPos ) ) 
        {
            newPos = GetRandomPositionWithinBounds(); 
            check++;
            if ( check > 100 ) break;
        }

        return newPos;
    }

    private Vector3 GetRandomPositionWithinBounds()
    {
        Vector3 min = arrayBounds.min;
        Vector3 max = arrayBounds.max;

        return new Vector3( Random.Range( min.x, max.x ), Random.Range( min.y, max.y ), 0f ); 
    }

    private bool CheckProximityViolation( Vector3 posToCheck )
    {
        for( int i = 0; i < _squares.Length; i++ )
        {
            if ( _squares[i] == null ) continue;
            float distance = Vector3.Distance( posToCheck, _squares[i].transform.position );
            if ( distance < squareProximityLimit ) return true;
        }

        return false;
    }

    private float squareProximityLimit;
    private float _squareProximityLimit { get { return unitSize * 2f; } }
    public float unitSize { get { return squarePrefab.size / .65f; } }

    // Debug ==================================================
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube( arrayBounds.center, arrayBounds.size );
    }
}

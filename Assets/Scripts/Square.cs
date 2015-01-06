using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour 
{
    public SpriteRenderer sprite;

    public void Initialize( Color color )
    {
        sprite.color = color;
    }

    public float size { get { return sprite.bounds.size.x; } }
}

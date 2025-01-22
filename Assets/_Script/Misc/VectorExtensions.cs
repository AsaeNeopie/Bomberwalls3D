using System.Runtime.CompilerServices;
using UnityEngine;

public static class VectorExtensions
{

    //rounding
    public static Vector3Int round(this Vector3 v)
    {
        return new Vector3Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y), Mathf.RoundToInt(v.z));
    }

    public static Vector2Int round(this Vector2 v)
    {
        return new Vector2Int(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.y));
    }

    public static Vector2Int ceil(this Vector2 v)
    {
        return new Vector2Int(Mathf.CeilToInt(v.x), Mathf.CeilToInt(v.y));
    }

    public static Vector2Int floor(this Vector2 v)
    {
        return new Vector2Int(Mathf.FloorToInt(v.x), Mathf.FloorToInt(v.y));
    }

    //Distance
    public static float SqrDistanceTo(this Vector3 u,Vector3 v)
    {
        return (u - v).sqrMagnitude;
    }

    public static float SqrDistanceTo(this Vector2 u, Vector2 v)
    {
        return (u - v).sqrMagnitude;
    }


    //Swizzle
    public static Vector2 XZ(this Vector3 v)
    {
        return new Vector2(Mathf.RoundToInt(v.x), Mathf.RoundToInt(v.z));
    }

    public static Vector3 X0Y(this Vector2 v)
    {
        return new Vector3(v.x,0,v.y);
    }

    public static Vector3Int X0Y(this Vector2Int v)
    {
        return new Vector3Int(v.x, 0, v.y);
    }
}

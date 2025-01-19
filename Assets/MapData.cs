using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName ="newMapData", menuName = "MapData")]
public class MapData : ScriptableObject
{
    public SerializedDictionary<Vector2Int, Tile?> Tiles = new();


    public RectInt Bounds;//custom inspector avec bouton "edit" qui ouvre une window comme pour les couleurs
}

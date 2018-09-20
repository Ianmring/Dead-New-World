using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;
namespace D3D
{
    //public enum TileType { Floor, Grave }

    public class Tile : MonoBehaviour
    {
        public int xPos;
        public int yPos;
        public bool isActive = true;
        public bool isOccupied = false;
        public Building building;
    }

}

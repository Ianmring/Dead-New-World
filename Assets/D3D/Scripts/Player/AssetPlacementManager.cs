using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using D3D;


public class AssetPlacementManager : MonoBehaviour
{
    public enum InputMode { selectMode, buildMode, modifyMode, tileMode }

    Ray camRay;
    RaycastHit hitInfo;

    Tile selectedTile;
    AttachNode selectedNode;
    PlaceableAsset currentObject;
    InputMode currentInputMode;

    public bool canPlaceObject;

    public void InitializeManager()
    {
        currentInputMode = InputMode.selectMode;
    }

    public void SelectionHandler()
    {
        switch(currentInputMode)
        {
            case InputMode.selectMode:
                GetTileUnderCursor();
                break;

            case InputMode.buildMode:
                if (CheckIfObjectSelected())
                {
                    GetTileUnderCursor();
                    MoveObjectToCursor();
                    canPlaceObject = CheckBuildingPlacement();
                    PlaceBuilding();
                }
                break;

            case InputMode.modifyMode:
                if (CheckIfObjectSelected())
                {
                    GetTileUnderCursor();
                    MoveModToBuilding();
                    //canPlaceObject = CheckModPlacement();
                    AttachMod();
                }
                break;

            case InputMode.tileMode:
                break;
        }
        
    }

    public bool CheckIfObjectSelected()
    {
        if (currentObject != null) return true;
        else return false;
    }

    public void GetTileUnderCursor()
    {
        camRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(camRay, out hitInfo) && hitInfo.transform.gameObject.GetComponent<Tile>() != null)
        {
            selectedTile = hitInfo.transform.gameObject.GetComponent<Tile>();
        }
    }

    public void MoveObjectToCursor()
    {
        if (selectedTile != null)
        {
            currentObject.transform.position = selectedTile.transform.position;
        }
        else return;
    }

    public void MoveModToBuilding()
    {
        //needs to check if mod CAN be placed on building according to mod's type
        //THEN needs to find node on building specifically for the type of mod being placed
        //therefore, buildings should have a list of nodes with keys that the mod can be compared to
        //then, currentObject is moved to position of that node
        //IMPORTANT: any mods need to fit a building's node perfectly, otherwise it looks funky
        //ALSO IMPORTANT: once a mod is placed, the mod needs to know it's owning building
        if (selectedTile != null && selectedTile.isOccupied)
        {
            Building selectedBuilding = selectedTile.building;
            Mod currentMod = currentObject as Mod;

            for(int n = 0; n < selectedBuilding.attNodeList.Count; n++)
            {
                if(currentMod.nodeTag == selectedBuilding.attNodeList[n].nodeTag)
                {
                    selectedNode = selectedBuilding.attNodeList[n];
                }
            }

            if(selectedNode != null)
            {
                currentMod.transform.position = selectedNode.transform.position;
            }
        }
        else return;
    }

    public bool CheckBuildingPlacement()
    {
        //first check if tiles are occupied
        Building currentBuilding = currentObject as Building;

        for(int w = selectedTile.xPos; w < currentBuilding.tileSize.x + selectedTile.xPos; w++)
        {
            for(int h = selectedTile.yPos; h < currentBuilding.tileSize.y + selectedTile.yPos; h++)
            {
                //if (PlayerController.Player.boardManager.GetTileAt(w, h) == null) return false;
                //else if (PlayerController.Player.boardManager.GetTileAt(w, h).isOccupied) return false;
            }
        }
        //TO ADD: then check if tile heights are contiguous
        return true;
    }

    /*
    public bool CheckModPlacement()
    {
        //first check if nodes are occupied
        /*Tile tileBeingChecked = PlayerController.Player.boardManager.GetTileAt(selectedTile.xPos, selectedTile.yPos);

        if (tileBeingChecked.isOccupied)
        {
            //AttachNode selectedNode = null;
            Building currentBuilding = selectedTile.building;
            Mod currentMod = currentObject as Mod;

            for (int n = 0; n < tileBeingChecked.building.attNodeList.Count; n++)
            {
                if (currentMod.nodeTag == currentBuilding.attNodeList[n].nodeTag)
                {
                    if (currentBuilding.attNodeList[n].isAttached) return false;
                    else
                    {
                        selectedNode = currentBuilding.attNodeList[n];
                        return true;
                    }
                }
            }
        }
        return false;
    }*/

    public void PlaceBuilding()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (canPlaceObject)
            {
                Building currentBuilding = currentObject as Building;

                for (int w = selectedTile.xPos; w < currentBuilding.tileSize.x + selectedTile.xPos; w++)
                {
                    for (int h = selectedTile.yPos; h < currentBuilding.tileSize.y + selectedTile.yPos; h++)
                    {
                        //PlayerController.Player.boardManager.GetTileAt(w, h).isOccupied = true;
                        //PlayerController.Player.boardManager.GetTileAt(w, h).building = currentBuilding;
                    }
                }

                currentObject = null;
                currentInputMode = InputMode.selectMode;
            }
        }
    }
    
    public void AttachMod()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canPlaceObject)
            {
                currentObject.transform.SetParent(selectedNode.transform);
                selectedNode.isAttached = true;
                currentObject = null;
                currentInputMode = InputMode.selectMode;
            }
        }
    }

    public void SetNewBuilding(PlaceableAsset newObject)
    {
        currentObject = Instantiate(newObject);
        currentInputMode = InputMode.buildMode;
    }

    public Mod SetNewMod(PlaceableAsset newObject)
    {
        currentObject = Instantiate(newObject);
        currentInputMode = InputMode.modifyMode;
        return newObject as Mod;
    }

    public void SetInputMode(InputMode newMode)
    {
        currentInputMode = InputMode.selectMode;
    }

}

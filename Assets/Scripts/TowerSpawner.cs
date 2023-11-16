using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSpawner : MonoBehaviour

{
    //Towers
    
    
    
    
    [SerializeField] Tower defaultTower;
    
    [SerializeField] LayerMask groundLayers;
    [SerializeField] Tilemap tilemap;

    private Vector3Int cellPosition;
    private Tower towerMarker;
    private Vector3 mousePosition;
    private bool spawnerIsActive;


    private void Awake()
    {
        //initial setup

        spawnerIsActive = false;
        towerMarker = null;


    }


    private void Update()
    {
        //Activate the spawner if T is pressed and spawner is NOT active
        if (Input.GetKeyDown(KeyCode.T) && !spawnerIsActive)

        {
            StartTowerPlacement(defaultTower);
        }
        
        
        if (spawnerIsActive)

        { 
        mousePosition = GetMousePosition(); //update mouse position
        towerMarker.transform.position = mousePosition; //move the indicator



        //Drop the tower
        if(Input.GetMouseButton(0)) 
            
         {
                towerMarker.ActivateTower();
                towerMarker = null;
                spawnerIsActive=false;
            
         }

        //Cancel tower placement
        else if(Input.GetMouseButton(1)) 
            { 
                Destroy(towerMarker.gameObject);
                spawnerIsActive = false;
            }



        }
    }





    private Vector3 GetMousePosition()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 200f, groundLayers))
        {
            Debug.DrawLine(Camera.main.transform.position,
            hit.point, Color.red);
            
           
            //Get cell position
            cellPosition = tilemap.LocalToCell(hit.point);

           
            //Return snapped position
            return new Vector3(
                cellPosition.x + tilemap.cellSize.x / 2f, 
                0, 
                cellPosition.y + tilemap.cellSize.y / 2f);
            
            //Non-snapping old method
            //return hit.point;
            
        }

        return Vector3.zero; //Hit nothing
        



    }


    private void StartTowerPlacement(Tower newTower)
    {
        towerMarker = Instantiate(newTower, mousePosition, Quaternion.identity);
        spawnerIsActive = true;
    }





}

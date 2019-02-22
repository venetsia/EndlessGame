﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour {

    /*public float speed;

    public float endX;
    public float startX;

    public void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }*/
    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    private float screenWidthInPoints;

    private void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoints = height * Camera.main.aspect;
        StartCoroutine(GeneratorCheck());
    }
    void AddRoom(float farthestRoomEndX)
    {
        //1
        int randomRoomIndex = Random.Range(0, availableRooms.Length);
        //2
        GameObject room = (GameObject)Instantiate(availableRooms[randomRoomIndex]);
        //3
        float roomWidth = room.transform.Find("floor").localScale.x;
        //4
        float roomCenter = farthestRoomEndX + roomWidth * 0.5f;
        //5
        room.transform.position = new Vector3(roomCenter, 0, 0);
        //6
        currentRooms.Add(room);
    }
    private void GenerateRoomIfRequired()
    {
        //1
        List<GameObject> roomsToRemove = new List<GameObject>();
        //2
        bool addRooms = true;
        //3
        float playerX = transform.position.x;
        //4
        float removeRoomX = playerX - screenWidthInPoints;
        //5
        float addRoomX = playerX + screenWidthInPoints;
        //6
        float farthestRoomEndX = 0;
        foreach (var room in currentRooms)
        {
            //7
            float roomWidth = room.transform.Find("1rstGround").localScale.x;
            float roomStartX = room.transform.position.x - (roomWidth * 0.5f);
            float roomEndX = roomStartX + roomWidth;
            //8
            if (roomStartX > addRoomX)
            {
                addRooms = false;
            }
            //9
            if (roomEndX < removeRoomX)
            {
                roomsToRemove.Add(room);
            }
            //10
            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
        }
        //11
        foreach (var room in roomsToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }
        //12
        if (addRooms)
        {
            AddRoom(farthestRoomEndX);
        }
    }
    private IEnumerator GeneratorCheck()
    {
        while (true)
        {
            GenerateRoomIfRequired();
            yield return new WaitForSeconds(0.25f);
        }
    }

}

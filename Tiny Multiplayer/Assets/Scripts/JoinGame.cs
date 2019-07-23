using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using System;

public class JoinGame : MonoBehaviour
{

    [SerializeField]
    private Text status;
    private NetworkManager networkManager;
    public GameObject roomListItemPrefab;
    public Transform roomListParent;


    // Start is called before the first frame update
    void Start()
    {
        networkManager = NetworkManager.singleton;

        if(networkManager == null)
        {
            networkManager.StartMatchMaker();
        }

        RefreshRoomList();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshRoomList()
    {
        networkManager.matchMaker.ListMatches(0, 20, "", true, 0,0, OnMatchList);
        status.text = "Loading...";
    }

    public void OnMatchList(bool success, string extendedInfo, List<MatchInfoSnapshot> matchList)
    {
        status.text = "";
        if (!success || matchList == null)
        {
            status.text = "Couldn't get room list!";
            return;
        }

        foreach(MatchInfoSnapshot match in matchList)
        {
            GameObject _roomListItemGO = Instantiate(roomListItemPrefab);
            _roomListItemGO.transform.SetParent(roomListParent);
        }

    }

}

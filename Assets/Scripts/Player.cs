﻿using UnityEngine;
using System.Collections;

public class Player : Singleton<Player>
{
	Behaviour _controller;
	public Behaviour Controller
	{
		get
		{
			if (_controller == null)
				_controller = GetComponent("PlayerMoveController") as Behaviour;
			return _controller;
		}
	}

	public PlayerTool MainTool;

	public Tile CurrentTile;

	void Update()
	{
		var hits = Physics.RaycastAll(transform.position, -transform.up);
		CurrentTile = null;
		foreach(var hit in hits)
		{
			var tile = hit.transform.GetComponentInParents<Tile>();
			if(tile != null)
			{
				CurrentTile = tile;
				break;
			}
		}

		if (CurrentTile != null)
		{
			if (CurrentTile.Room == null)
			{
				RoomManager.Instance.SetRoom(RoomManager.RoomType.None, CurrentTile);
			}

			if (Input.GetKeyDown(KeyCode.Z))
			{
				RoomManager.Instance.SetRoom(RoomManager.RoomType.Bedroom, CurrentTile);
			}
			if (Input.GetKeyDown(KeyCode.X))
			{
				RoomManager.Instance.SetRoom(RoomManager.RoomType.None, CurrentTile);
			}
		}
	}
}

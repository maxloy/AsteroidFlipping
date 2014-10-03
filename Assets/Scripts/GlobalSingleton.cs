﻿using UnityEngine;
using System.Collections;

public class GlobalSingleton<T> : Singleton<T> where T : MonoBehaviour
{
	protected override void Awake()
	{
		base.Awake();
		DontDestroyOnLoad(this);
	}
}

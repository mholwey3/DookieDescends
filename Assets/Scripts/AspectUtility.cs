// ***********************************************************************
// File: AspectUtility.cs"
//
// Created By: Chad Watson
//
// Date: 9/30/2015 3:44 PM
//
// Copyright (c) 2015 All Rights Reserved, Sjögren's Game.
//
// Description:
// Forces a 16:9 ratio on the screen.
//// ***********************************************************************

using UnityEngine;
using System.Collections;

public class AspectUtility : MonoBehaviour
{

    #region Variables
    //[SerializeField]
    private float targetAspect;
    private float windowAspect;
    private float scaleHeight;
    private float scaleWidth;
    private Camera camera;
    private Rect rect;
    

    #endregion

    #region Unity Event Functions

    #endregion

    #region Public Functions
    void Awake()
    {
        // set the desired aspect ratio
        targetAspect = 16.0f / 9.0f;
        // determine the game window's current aspect ratio
        windowAspect = (float)Screen.width / (float)Screen.height;
        // current viewport height should be scaled by this amount
        scaleHeight = windowAspect / targetAspect;
        camera = GetComponent<Camera>();

        checkHeightWidth();
    }

    #endregion
    //empty
    #region Private Functions

    private void checkHeightWidth()
    {
        // if scaled height is less than current height, add letterbox
        if (scaleHeight < 1.0f)
        {
            rect = camera.rect;
            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // add pillarbox
        {
            scaleWidth = 1.0f / scaleHeight;
            rect = camera.rect;
            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;

        }

    }

    #endregion
    //empty
}


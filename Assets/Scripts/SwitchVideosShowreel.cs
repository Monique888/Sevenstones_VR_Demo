// Copyright (C) 2016 Google Inc. All Rights Reserved.
//
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//    limitations under the License.

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SwitchVideosShowreel : MonoBehaviour {
  public GameObject Video0;
  public GameObject Video1;
  public GameObject Video2;
  public GameObject Video3;
  public GameObject Video4;
  public GameObject Video5;

    private GameObject[] videoSamples;

  public Text missingLibText;

  public void Awake() {
    videoSamples = new GameObject[6];
    videoSamples[0] = Video0;
    videoSamples[1] = Video1;
    videoSamples[2] = Video2;
    videoSamples[3] = Video3;
    videoSamples[4] = Video4;
    videoSamples[5] = Video5;

        string NATIVE_LIBS_MISSING_MESSAGE = "Video Support libraries not found or could not be loaded!\n" +
          "Please add the <b>GVRVideoPlayer.unitypackage</b>\n to this project";

    if (missingLibText != null) {
      try {
        IntPtr ptr = GvrVideoPlayerTexture.CreateVideoPlayer();
        if (ptr != IntPtr.Zero) {
          GvrVideoPlayerTexture.DestroyVideoPlayer(ptr);
          missingLibText.enabled = false;
        } else {
          missingLibText.text = NATIVE_LIBS_MISSING_MESSAGE;
          missingLibText.enabled = true;
        }
      } catch (Exception e) {
        Debug.LogError(e);
        missingLibText.text = NATIVE_LIBS_MISSING_MESSAGE;
        missingLibText.enabled = true;
      }
    }
  }

  public void ShowMainMenu() {
    ShowSample(-1);
  }

  public void OnVideo0() {
    ShowSample(0);
  }

  public void OnVideo1() {
    ShowSample(1);
  }

  public void OnVideo2() {
    ShowSample(2);
  }

  public void OnVideo3() {
     ShowSample(3);
    }

    public void OnVideo4()
    {
        ShowSample(4);
    }

    public void OnVideo5()
    {
        ShowSample(5);
    }

    private void ShowSample(int index) {
    // If the libs are missing, always show the main menu.
    if (missingLibText != null && missingLibText.enabled) {
      index = -1;
    }

    for (int i = 0; i < videoSamples.Length; i++) {
      if (videoSamples[i] != null) {

        if (i != index) {
          if (videoSamples[i].activeSelf) {
            videoSamples[i].GetComponentInChildren<GvrVideoPlayerTexture>().CleanupVideo();
          }
        } else {
            videoSamples[i].GetComponentInChildren<GvrVideoPlayerTexture>().ReInitializeVideo();
        }
        // GvrVideoPlayerTexture needs an additional frame after CleanupVideo() to finish
        // cleanup and allow its coroutine to exit, otherwise it gets permenantly stuck
        // if it is deactivated too soon.
        StartCoroutine(SetActiveDelayed(videoSamples[i], i == index));
      }
    }
    GetComponent<Canvas>().enabled = index == -1;
  }

  private IEnumerator SetActiveDelayed(GameObject go, bool state) {
    yield return new WaitForEndOfFrame();
    go.SetActive(state);
  }
}

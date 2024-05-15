using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using TMPro;

public class VoiceManager : MonoBehaviour
{
    private bool isListening;
    private const string LANG_CODE = "en-US";
    private string message;

    #region text to speech
    public void StartSpeaking(string message)
    {
        TextToSpeech.Instance.StartSpeak(message);
    }

    public void StopSpeaking()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    public void OnSpeakStart()
    {
        Debug.Log("Speaking");
    }

    public void OnSpeakStop()
    {
        Debug.Log("Stop Speaking");
    }

    #endregion

    #region speech to text
    public void StartListening()
    {
        SpeechToText.Instance.StartRecording();
    }

    public void StopListening()
    {
        SpeechToText.Instance.StopRecording();
    }

    public void OnFinalResult(string _data)
    {
        message = _data;
        isListening = false;
    }

    public void OnPartialResult(string _data)
    {
        message = _data;
    }

    #endregion

    public void Start()
    {
        Setup(LANG_CODE);
    }

    public void Ask()
    {
        StartSpeaking("Hello, how can I help you?");
        StartListening();
        isListening = true;
    }

    public void Stop()
    {
        StopSpeaking();
        StopListening();
        isListening = false;
    }

    public bool IsListening()
    {
        return isListening;
    }

    public string GetMessage()
    {
        return message;
    }

    public void Setup(string code)
    {
        TextToSpeech.Instance.Setting(code, 1, 1);
        SpeechToText.Instance.Setting(code);
        SpeechToText.Instance.onResultCallback = OnFinalResult;
#if UNITY_ANDROID
        SpeechToText.Instance.onPartialResultsCallback = OnPartialResult;
#endif
        TextToSpeech.Instance.onStartCallBack = OnSpeakStart;
        TextToSpeech.Instance.onDoneCallback = Stop;
        CheckPermission();
    }

    void CheckPermission()
    {
#if UNITY_ANDROID
        if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
        {
            Permission.RequestUserPermission(Permission.Microphone);
        }
#endif
    }
}

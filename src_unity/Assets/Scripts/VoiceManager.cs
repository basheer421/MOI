using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TextSpeech;
using UnityEngine.Android;
using TMPro;

public class VoiceManager : MonoBehaviour
{
    private const string LANG_CODE = "en-US";
    public TextMeshProUGUI uiText;

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
        uiText.text = _data;
        Debug.Log(_data);
    }

    public void OnPartialResult(string _data)
    {
        uiText.text = _data;
        Debug.Log(_data);
    }

    #endregion

    public void Start()
    {
        Setup(LANG_CODE);
        StartSpeaking("Hello, how can I help you?");
        StartListening();
    }

    public void Stop()
    {
        StopSpeaking();
        StopListening();
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
        TextToSpeech.Instance.onDoneCallback = OnSpeakStop;
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

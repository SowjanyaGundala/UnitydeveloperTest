using UnityEngine;
using System;
using UnityEngine.Windows.Speech;
using System.Collections.Generic;
using System.Linq;
public class VoiceController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody cube;

    private Dictionary<string, Action> keywordActions = new Dictionary<string, Action>();
    private KeywordRecognizer keywordRecognizer;

    void Start() {
        keywordActions.Add("turn right",TurnRight);
        keywordActions.Add("turn left", TurnLeft);
        keywordRecognizer = new KeywordRecognizer(keywordActions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized+= OnkeywordsRecognized;
        keywordRecognizer.Start();
    }

    private void TurnRight() {
        transform.Rotate(0f, 10f, 0f);
        transform.localPosition = new Vector3(transform.position.x + 8f, transform.position.y, transform.position.z);
    }

    private void TurnLeft() {
        transform.Rotate(0f, -10f, 0f);
        transform.localPosition = new Vector3(transform.position.x - 8f, transform.position.y, transform.position.z);

    }

    private void OnkeywordsRecognized(PhraseRecognizedEventArgs args) {
        keywordActions[args.text].Invoke();
    }
}

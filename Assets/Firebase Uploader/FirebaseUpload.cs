using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Proyecto26;

[Serializable]
public class TestLogObject {
    public string timestamp;
    public string info;

    public TestLogObject(string timestamp, string info)
    {
        this.timestamp = timestamp;
        this.info = info;
    }
}



public class FirebaseUpload : MonoBehaviour
{

    public string TimestampUnixMilliseconds
    {
        get { return new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds().ToString(); }
    }

    public delegate void UploadCallback(string s);
 

    [SerializeField]
    [Tooltip("Your Firebase project id.")]
    private string projectId = "test-project-id";

    [SerializeField]
    [Tooltip("Enable me to print more detailed messages.")]
    private bool verbose = false;

    UploadCallback callback;

    private void Awake()
    {
        callback = (string str) => { if (verbose) print(str); };
    }
    private string databaseURL
    {
        get { return $"https://{projectId}.firebaseio.com"; }
    }


    public void WriteTestMessage()
    {
        TestLogObject logObj = new TestLogObject(TimestampUnixMilliseconds, "Hello World!");
        postTestLog(logObj, callback, callback);
    }

   

    void postTestLog(TestLogObject log, UploadCallback successCallback = null, UploadCallback failureCallback = null)
    {
            if (verbose) print("posting test log");
            RestClient.Put<TestLogObject>($"{databaseURL}/test/{log.timestamp}.json", log)
            .Then(response =>
                {
                    if (successCallback != null) successCallback("Uploaded successfully");
                }
            ).Catch(err =>
                {
                    if (failureCallback != null) failureCallback(err.Message);
                }
            );
            

      
    }
}

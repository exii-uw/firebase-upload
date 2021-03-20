# Unity Firebase Uploader

Based on these instructions: https://medium.com/@rotolonico/firebase-database-in-unity-with-rest-api-42f2cf6a2bbf

1. Create a new Firebase project, with the realtime database in TEST mode for unauthenticated access.
2. Get your project id (`<id>.firebaseio.com`), and paste it into the appropriate field in the Firebase Upload script.
3. Define a serializable log object class that stores your data. TestLogObject in FirebaseUpload.cs is an example.
4. Define a few custom callbacks for success and failure if you so need. Right now it's just a generic success/failure message.
5. Upload the object using `RestClient.Put<YourLogObjectClass>()` similarly to in the FirebaseUpload example.  

Note that you can change your data model's structure by simply modifying classes and URL endpoints. **It's all JSON, baby!** 😎

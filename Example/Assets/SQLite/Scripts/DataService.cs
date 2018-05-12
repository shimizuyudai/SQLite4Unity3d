using SQLite4Unity3d;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class DataService
{
    public SQLiteConnection Connection
    {
        get;
        private set;
    }

    public DataService(string DatabaseName)
    {
        var dbPath = Path.Combine(Application.streamingAssetsPath, DatabaseName);
        var filePath = Path.Combine(Application.persistentDataPath, DatabaseName);

//		if (!File.Exists (filePath)) {
//			Debug.Log ("Database not in Persistent path");
//			// if it doesn't ->
//			// open StreamingAssets directory and load the db ->
//
//#if UNITY_ANDROID
//            var loadDb = new WWW("jar:file://" + Application.dataPath + "!/assets/" + DatabaseName);  // this is the path to your StreamingAssets in android
//            while (!loadDb.isDone) { }  // CAREFUL here, for safety reasons you shouldn't let this while loop unattended, place a timer and error check
//            // then save to Application.persistentDataPath
//            File.WriteAllBytes(filepath, loadDb.bytes);
//#elif UNITY_IOS
//				file
//                File.Copy(loadDb, filepath);

//			Debug.Log ("Database written");
//		}

#if UNITY_ANDROID || UNITY_IOS
		if (!File.Exists (filePath)) {
			File.Copy(dbPath, filePath);
		}
    dbPath = filepath;
#endif

		Connection = new SQLiteConnection (dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);

	}
}

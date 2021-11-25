using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class LoadAssetBundles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Application.streamingAssetsPath => streaming folder
        // Application.persistentDataPath => save/load

        //StartCoroutine(LoadManifestWWW("C:\Users\Student\Desktop\Yong'sTemp\SchoolLearning\SchoolLearning\AssetBundles\StandaloneWindows"));
        //LoadManifestFile("C:\Users\Student\Desktop\Yong'sTemp\SchoolLearning\SchoolLearning\AssetBundles\StandaloneWindows");
        //StartCoroutine(LoadManifestRequest("C:\Users\Student\Desktop\Yong'sTemp\SchoolLearning\SchoolLearning\AssetBundles\StandaloneWindows"));

        StartCoroutine(LoadSceneRequest("ABC"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(LoadDataRequest("new material", "myobject"));
        }
    }

    IEnumerator LoadSceneRequest(string sName)
    {
        string sURL = "file:///" + Application.streamingAssetsPath + "/" + sName;
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(sURL);
        if (uwr == null)
        {
            yield break;
        }
        UnityWebRequestAsyncOperation ao = uwr.SendWebRequest();
        if (ao == null)
        {
            yield break;
        }
        yield return ao;

        if (ao.isDone && uwr.result != UnityWebRequest.Result.ProtocolError && uwr.result != UnityWebRequest.Result.ConnectionError)
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(uwr);
            if (ab != null)
            {
                SceneManager.LoadScene("ABC");
                //yield return 0;
                //AssetBundleRequest abr = ab.LoadAssetAsync("Cube");
                // yield return abr;
                // Debug.Log(abr.asset.GetType());
                // Instantiate(abr.asset);

                ab.Unload(false);
            }

        }
    }

    IEnumerator LoadDataRequest(string sName1, string sName2)
    {
        string sURLm = "file:///" + Application.streamingAssetsPath + "/" + sName1;
        UnityWebRequest uwrm = UnityWebRequestAssetBundle.GetAssetBundle(sURLm);
        if (uwrm == null)
        {
            yield break;
        }
        UnityWebRequestAsyncOperation aom = uwrm.SendWebRequest();
        if (aom == null)
        {
            yield break;
        }
        yield return aom;
        AssetBundle abm = null;
        if (aom.isDone && uwrm.result != UnityWebRequest.Result.ProtocolError && uwrm.result != UnityWebRequest.Result.ConnectionError)
        {
            abm = DownloadHandlerAssetBundle.GetContent(uwrm);
            if (abm != null)
            {
                //AssetBundleRequest abr = ab.LoadAssetAsync("");
                // yield return abr;
                // Debug.Log(abr.asset.GetType());
                //  Instantiate(abr.asset);

                // ab.Unload(false);
            }

        }

        string sURL = "file:///" + Application.streamingAssetsPath + "/" + sName2;
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(sURL);
        if (uwr == null)
        {
            yield break;
        }
        UnityWebRequestAsyncOperation ao = uwr.SendWebRequest();
        if (ao == null)
        {
            yield break;
        }
        yield return ao;

        if (ao.isDone && uwr.result != UnityWebRequest.Result.ProtocolError && uwr.result != UnityWebRequest.Result.ConnectionError)
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(uwr);
            if (ab != null)
            {
                AssetBundleRequest abr = ab.LoadAssetAsync("Cube");
                yield return abr;
                Debug.Log(abr.asset.GetType());
                Instantiate(abr.asset);

                ab.Unload(false);
            }

        }
        if (abm != null)
        {
            abm.Unload(false);

        }
    }

    IEnumerator LoadStreamingManifestRequest(string sName)
    {
        string sURL = "file:///" + Application.streamingAssetsPath + "/" + sName;
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(sURL);
        if (uwr == null)
        {
            yield break;
        }
        UnityWebRequestAsyncOperation ao = uwr.SendWebRequest();
        if (ao == null)
        {
            yield break;
        }
        yield return ao;

        if (ao.isDone && uwr.result != UnityWebRequest.Result.ProtocolError && uwr.result != UnityWebRequest.Result.ConnectionError)
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(uwr);
            if (ab != null)
            {
                AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                string[] sBundlesName = abm.GetAllAssetBundles();
                foreach (string sBundle in sBundlesName)
                {
                    Debug.Log(sBundle);
                    string[] sDeps = abm.GetAllDependencies(sBundle);
                    if (sDeps != null && sDeps.Length > 0)
                    {
                        foreach (string s in sDeps)
                        {
                            Debug.Log("Dep " + s);
                        }
                    }
                }
                ab.Unload(false);
            }

        }

    }

    IEnumerator LoadManifestRequest(string sLocalPath)
    {
        string sURL = "file:///" + sLocalPath;
        UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(sURL);
        if (uwr == null)
        {
            yield break;
        }
        UnityWebRequestAsyncOperation ao = uwr.SendWebRequest();
        if (ao == null)
        {
            yield break;
        }
        yield return ao;

        if (ao.isDone && uwr.result != UnityWebRequest.Result.ProtocolError && uwr.result != UnityWebRequest.Result.ConnectionError)
        {
            AssetBundle ab = DownloadHandlerAssetBundle.GetContent(uwr);
            if (ab != null)
            {
                AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
                string[] sBundlesName = abm.GetAllAssetBundles();
                foreach (string sBundle in sBundlesName)
                {
                    Debug.Log(sBundle);
                    string[] sDeps = abm.GetAllDependencies(sBundle);
                    if (sDeps != null && sDeps.Length > 0)
                    {
                        foreach (string s in sDeps)
                        {
                            Debug.Log("Dep " + s);
                        }
                    }
                }
                ab.Unload(false);
            }

        }


    }

    void LoadManifestFile(string sLocalPath)
    {
        AssetBundle ab = AssetBundle.LoadFromFile(sLocalPath);
        if (ab != null)
        {
            AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            string[] sBundlesName = abm.GetAllAssetBundles();
            foreach (string sBundle in sBundlesName)
            {
                Debug.Log(sBundle);
                string[] sDeps = abm.GetAllDependencies(sBundle);
                if (sDeps != null && sDeps.Length > 0)
                {
                    foreach (string s in sDeps)
                    {
                        Debug.Log("Dep " + s);
                    }
                }
            }
        }


        ab.Unload(false);
    }

    IEnumerator LoadManifestFileAsync(string sLocalPath)
    {
        AssetBundleCreateRequest abcr = AssetBundle.LoadFromFileAsync(sLocalPath);
        if (abcr == null)
        {
            yield break;
        }
        yield return abcr;
        AssetBundle ab = abcr.assetBundle;
        if (ab != null)
        {
            AssetBundleManifest abm = ab.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            string[] sBundlesName = abm.GetAllAssetBundles();
            foreach (string sBundle in sBundlesName)
            {
                Debug.Log(sBundle);
                string[] sDeps = abm.GetAllDependencies(sBundle);
                if (sDeps != null && sDeps.Length > 0)
                {
                    foreach (string s in sDeps)
                    {
                        Debug.Log("Dep " + s);
                    }
                }
            }

            ab.Unload(false);
        }


    }

    IEnumerator LoadManifestWWW(string sLocalPath)
    {
        string sURL = "file:///" + sLocalPath;
        Debug.Log(sURL);
        //WWW w = new WWW(sURL);
        WWW w = WWW.LoadFromCacheOrDownload(sURL, 0);
        if (w == null)
        {
            yield break;
        }
        yield return w;

        if (w.isDone && w.assetBundle != null)
        {
            AssetBundleManifest abm = w.assetBundle.LoadAsset<AssetBundleManifest>("AssetBundleManifest");
            string[] sBundlesName = abm.GetAllAssetBundles();
            foreach (string sBundle in sBundlesName)
            {
                Debug.Log(sBundle);
                string[] sDeps = abm.GetAllDependencies(sBundle);
                if (sDeps != null && sDeps.Length > 0)
                {
                    foreach (string s in sDeps)
                    {
                        Debug.Log("Dep " + s);
                    }
                }
            }


            w.assetBundle.Unload(false);
        }
    }
}

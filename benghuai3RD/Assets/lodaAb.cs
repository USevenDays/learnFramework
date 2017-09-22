using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class lodaAb : MonoBehaviour {

    public string url;
    public string assertName;
    public RawImage testTexture;
    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;
            if (www.error != null)
            {
                Debug.LogError("错误" + www.error);
            }
            else
            {
                print(www.progress * 100);
                AssetBundle assertBundle = www.assetBundle;
                Object obj = assertBundle.LoadAsset(assertName);
                //Instantiate(obj);
                Texture image = (obj)as Texture;
                testTexture.texture = image;
                print(obj.name);
                assertBundle.Unload(false);//true释放所有，否则只释放用过的
            }
        }
        //www.Dispose();//释放资源,或按上方使用USING
    }
}

using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateAB {

    [MenuItem("Tool/creatALLAssertBundle")]
    static void creatALLAB() {
        BuildPipeline.BuildAssetBundles("ABundle");//将所有选为需要打包的对象打包成ASSERTBUNDLE
    }
}

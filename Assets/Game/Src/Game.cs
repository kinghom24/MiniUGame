using UnityEngine;
using XLua;
using System.IO;
using LuaAPI = XLua.LuaDLL.Lua;
public class Game : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv luaenv = new LuaEnv();
        luaenv.AddLoader((ref string filename) =>
        {
            filename = filename.Replace('.', '/') + ".lua";
            var fileAddress = Path.Combine(Application.dataPath, "Game/Resources/" + filename);
            FileInfo fInfo0 = new FileInfo(fileAddress);
            string s = "";
            if (fInfo0.Exists)
            {
                StreamReader r = new StreamReader(fileAddress);
                s = r.ReadToEnd();
                return System.Text.Encoding.UTF8.GetBytes(s);
            }
            return null;
        });
        luaenv.DoString("require 'game'");
        luaenv.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

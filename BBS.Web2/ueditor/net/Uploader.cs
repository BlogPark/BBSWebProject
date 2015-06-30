using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Collections;
using dna.media.WebClass;


/// <summary>
/// UEditor缂栬緫鍣ㄩ�氱敤涓婁紶绫?
/// </summary>
public class Uploader
{
    string state = "SUCCESS";

    string URL = null;
    string currentType = null;
    string uploadpath = null;
    string filename = null;
    string originalName = null;
    HttpPostedFile uploadFile = null;
    string webstr = AppConf.dna_picUrl+"media/";
    /**
  * 涓婁紶鏂囦欢鐨勪富澶勭悊鏂规硶
  * @param HttpContext
  * @param string
  * @param  string[]
  *@param int
  * @return Hashtable 
  */
    public Hashtable upFile(HttpContext cxt, string pathbase, string[] filetype, int size)
    {
        var account = AccountHelper.getInstance().LoginUser();
        //pathbase = pathbase + DateTime.Now.ToString("yyyyMMdd")+ "/";//生成网站下的路径
        pathbase = (pathbase + account.aYOKAId.ToString() + "/").TrimStart('/');//生成网站下的路径
        string upload_picture_path = System.Configuration.ConfigurationManager.AppSettings["UPLOAD_PICTURE_PATH"];//配置文件中配置的文件上传地址
        //uploadpath = cxt.Server.MapPath(pathbase);//鑾峰彇鏂囦欢涓婁紶璺緞//系统原来的存放文件位置
        uploadpath = (upload_picture_path + pathbase.Replace("/", "\\")).Replace("\\", @"\");//组装后的具体存放位置
        //CreateFolder(DateTime.Now)
        try
        {
            uploadFile = cxt.Request.Files[0];
            originalName = uploadFile.FileName;

            //鐩綍鍒涘缓
            createFolder();

            //鏍煎紡楠岃瘉
            if (checkType(filetype))
            {
                //涓嶅厑璁哥殑鏂囦欢绫诲瀷
                state = "\u4e0d\u5141\u8bb8\u7684\u6587\u4ef6\u7c7b\u578b";
            }
            //澶у皬楠岃瘉
            if (checkSize(size))
            {
                //鏂囦欢澶у皬瓒呭嚭缃戠珯闄愬埗
                state = "\u6587\u4ef6\u5927\u5c0f\u8d85\u51fa\u7f51\u7ad9\u9650\u5236";
            }
            //淇濆瓨鍥剧墖
            if (state == "SUCCESS")
            {
                filename = reName();
                uploadFile.SaveAs(uploadpath + filename);
                URL =webstr+ pathbase + filename;
            }
        }
        catch (Exception e)
        {
            // 鏈煡閿欒
            state = "\u672a\u77e5\u9519\u8bef";
            URL = "";
        }
        return getUploadInfo();
    }

    /**
 * 涓婁紶娑傞甫鐨勪富澶勭悊鏂规硶
  * @param HttpContext
  * @param string
  * @param  string[]
  *@param string
  * @return Hashtable
 */
    public Hashtable upScrawl(HttpContext cxt, string pathbase, string tmppath, string base64Data)
    {
        pathbase = pathbase + DateTime.Now.ToString("yyyy-MM-dd") + "/";
        uploadpath = cxt.Server.MapPath(pathbase);//鑾峰彇鏂囦欢涓婁紶璺緞
        FileStream fs = null;
        try
        {
            //鍒涘缓鐩綍
            createFolder();
            //鐢熸垚鍥剧墖
            filename = System.Guid.NewGuid() + ".png";
            fs = File.Create(uploadpath + filename);
            byte[] bytes = Convert.FromBase64String(base64Data);
            fs.Write(bytes, 0, bytes.Length);

            URL = pathbase + filename;
        }
        catch (Exception e)
        {
            state = "鏈煡閿欒";
            URL = "";
        }
        finally
        {
            fs.Close();
            deleteFolder(cxt.Server.MapPath(tmppath));
        }
        return getUploadInfo();
    }

    /**
* 鑾峰彇鏂囦欢淇℃伅
* @param context
* @param string
* @return string
*/
    public string getOtherInfo(HttpContext cxt, string field)
    {
        string info = null;
        if (cxt.Request.Form[field] != null && !String.IsNullOrEmpty(cxt.Request.Form[field]))
        {
            info = field == "fileName" ? cxt.Request.Form[field].Split(',')[1] : cxt.Request.Form[field];
        }
        return info;
    }

    /**
     * 鑾峰彇涓婁紶淇℃伅
     * @return Hashtable
     */
    private Hashtable getUploadInfo()
    {
        Hashtable infoList = new Hashtable();

        infoList.Add("state", state);
        infoList.Add("url", URL);

        if (currentType != null)
            infoList.Add("currentType", currentType);
        if (originalName != null)
            infoList.Add("originalName", originalName);
        return infoList;
    }

    /**
     * 生成文件名称
     * @return string
     */
    private string reName()
    {
        //return System.Guid.NewGuid() + getFileExt();
        return CreateImageFileName() + getFileExt();
    }

    /**
     * 鏂囦欢绫诲瀷妫�娴?
     * @return bool
     */
    private bool checkType(string[] filetype)
    {
        currentType = getFileExt();
        return Array.IndexOf(filetype, currentType) == -1;
    }

    /**
     * 鏂囦欢澶у皬妫�娴?
     * @param int
     * @return bool
     */
    private bool checkSize(int size)
    {
        return uploadFile.ContentLength >= (size * 1024 * 1024);
    }

    /**
     * 鑾峰彇鏂囦欢鎵╁睍鍚?
     * @return string
     */
    private string getFileExt()
    {
        string[] temp = uploadFile.FileName.Split('.');
        return "." + temp[temp.Length - 1].ToLower();
    }

    /**
     * 鎸夌収鏃ユ湡鑷姩鍒涘缓瀛樺偍鏂囦欢澶?
     */
    private void createFolder()
    {
        if (!Directory.Exists(uploadpath))
        {
            Directory.CreateDirectory(uploadpath);
        }
    }

    /**
     * 鍒犻櫎瀛樺偍鏂囦欢澶?
     * @param string
     */
    public void deleteFolder(string path)
    {
        //if (Directory.Exists(path))
        //{
        //    Directory.Delete(path, true);
        //}
    }

    public string CreateFolder(DateTime dt)
    {
        string folder = dt.ToString("yyyyMMdd");
        Dictionary<string, string> numericDict = NumericDict();
        foreach (var kv in numericDict)
            folder = folder.Replace(kv.Key, kv.Value);
        return folder;
    }
    /// <summary>
    /// 生成文件名称
    /// </summary>
    /// <returns></returns>
    public string CreateImageFileName()
    {
        string treadName = System.Threading.Thread.CurrentThread.Name;
        string fix = "";
        if (!string.IsNullOrEmpty(treadName) && treadName.IndexOf("?") != -1)
        {
            fix = treadName.Split('?')[1];
        }
        string ticks = DateTime.Now.Ticks.ToString();
        Dictionary<string, string> numericDict = NumericDict();
        foreach (var kv in numericDict)
            ticks = ticks.Replace(kv.Key, kv.Value);
        return string.Format("{0}{1}", ticks, fix);
    }
    private Dictionary<string, string> NumericDict()
    {
        var dict = new Dictionary<string, string>();
        dict.Add("0", "a");
        dict.Add("1", "1");
        dict.Add("2", "b");
        dict.Add("3", "3");
        dict.Add("4", "c");
        dict.Add("5", "5");
        dict.Add("6", "d");
        dict.Add("7", "7");
        dict.Add("8", "e");
        dict.Add("9", "9");

        return dict;
    }
}
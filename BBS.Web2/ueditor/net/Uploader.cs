using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Collections;
using dna.media.WebClass;


/// <summary>
/// UEditor编辑器通用上传�?
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
  * 上传文件的主处理方法
  * @param HttpContext
  * @param string
  * @param  string[]
  *@param int
  * @return Hashtable 
  */
    public Hashtable upFile(HttpContext cxt, string pathbase, string[] filetype, int size)
    {
        var account = AccountHelper.getInstance().LoginUser();
        //pathbase = pathbase + DateTime.Now.ToString("yyyyMMdd")+ "/";//������վ�µ�·��
        pathbase = (pathbase + account.aYOKAId.ToString() + "/").TrimStart('/');//������վ�µ�·��
        string upload_picture_path = System.Configuration.ConfigurationManager.AppSettings["UPLOAD_PICTURE_PATH"];//�����ļ������õ��ļ��ϴ���ַ
        //uploadpath = cxt.Server.MapPath(pathbase);//获取文件上传路径//ϵͳԭ���Ĵ���ļ�λ��
        uploadpath = (upload_picture_path + pathbase.Replace("/", "\\")).Replace("\\", @"\");//��װ��ľ�����λ��
        //CreateFolder(DateTime.Now)
        try
        {
            uploadFile = cxt.Request.Files[0];
            originalName = uploadFile.FileName;

            //目录创建
            createFolder();

            //格式验证
            if (checkType(filetype))
            {
                //不允许的文件类型
                state = "\u4e0d\u5141\u8bb8\u7684\u6587\u4ef6\u7c7b\u578b";
            }
            //大小验证
            if (checkSize(size))
            {
                //文件大小超出网站限制
                state = "\u6587\u4ef6\u5927\u5c0f\u8d85\u51fa\u7f51\u7ad9\u9650\u5236";
            }
            //保存图片
            if (state == "SUCCESS")
            {
                filename = reName();
                uploadFile.SaveAs(uploadpath + filename);
                URL =webstr+ pathbase + filename;
            }
        }
        catch (Exception e)
        {
            // 未知错误
            state = "\u672a\u77e5\u9519\u8bef";
            URL = "";
        }
        return getUploadInfo();
    }

    /**
 * 上传涂鸦的主处理方法
  * @param HttpContext
  * @param string
  * @param  string[]
  *@param string
  * @return Hashtable
 */
    public Hashtable upScrawl(HttpContext cxt, string pathbase, string tmppath, string base64Data)
    {
        pathbase = pathbase + DateTime.Now.ToString("yyyy-MM-dd") + "/";
        uploadpath = cxt.Server.MapPath(pathbase);//获取文件上传路径
        FileStream fs = null;
        try
        {
            //创建目录
            createFolder();
            //生成图片
            filename = System.Guid.NewGuid() + ".png";
            fs = File.Create(uploadpath + filename);
            byte[] bytes = Convert.FromBase64String(base64Data);
            fs.Write(bytes, 0, bytes.Length);

            URL = pathbase + filename;
        }
        catch (Exception e)
        {
            state = "未知错误";
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
* 获取文件信息
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
     * 获取上传信息
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
     * �����ļ�����
     * @return string
     */
    private string reName()
    {
        //return System.Guid.NewGuid() + getFileExt();
        return CreateImageFileName() + getFileExt();
    }

    /**
     * 文件类型检�?
     * @return bool
     */
    private bool checkType(string[] filetype)
    {
        currentType = getFileExt();
        return Array.IndexOf(filetype, currentType) == -1;
    }

    /**
     * 文件大小检�?
     * @param int
     * @return bool
     */
    private bool checkSize(int size)
    {
        return uploadFile.ContentLength >= (size * 1024 * 1024);
    }

    /**
     * 获取文件扩展�?
     * @return string
     */
    private string getFileExt()
    {
        string[] temp = uploadFile.FileName.Split('.');
        return "." + temp[temp.Length - 1].ToLower();
    }

    /**
     * 按照日期自动创建存储文件�?
     */
    private void createFolder()
    {
        if (!Directory.Exists(uploadpath))
        {
            Directory.CreateDirectory(uploadpath);
        }
    }

    /**
     * 删除存储文件�?
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
    /// �����ļ�����
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
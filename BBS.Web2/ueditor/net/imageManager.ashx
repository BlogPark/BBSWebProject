<%@ WebHandler Language="C#" Class="imageManager" %>
/**
 * Created by visual studio2010
 * User: xuheng
 * Date: 12-3-7
 * Time: 涓嬪崍16:29
 * To change this template use File | Settings | File Templates.
 */
using System;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
using dna.media.WebClass;

public class imageManager : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        var account = AccountHelper.getInstance().LoginUser();
        string[] paths = { "upload", "upload1" }; //需要遍历的目录列表，最好使用缩略图地址，否则当网速慢时可能会造成严重的延时
        string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };                //鏂囦欢鍏佽鏍煎紡

        string action = context.Server.HtmlEncode(context.Request["action"]);

        if (action == "get")
        {
            String str = String.Empty;

            //foreach (string path in paths)
            //{
            string path = AppConf.dna_picUploadPath + @"\" + account.aYOKAId;
            string webpath = AppConf.dna_picUrl + @"media/" + account.aYOKAId;
            //DirectoryInfo info = new DirectoryInfo(context.Server.MapPath(path));
            DirectoryInfo info = new DirectoryInfo(path);
            //鐩綍楠岃瘉
            if (info.Exists)
            {
                //DirectoryInfo[] infoArr = info.GetDirectories();
                //foreach (DirectoryInfo tmpInfo in infoArr)
                //{
                //foreach (FileInfo fi in tmpInfo.GetFiles())
                foreach (FileInfo fi in info.GetFiles())
                {
                    if (Array.IndexOf(filetype, fi.Extension) != -1)
                    {
                        str += webpath + "/" + fi.Name + "ue_separate_ue";
                    }
                }
                //}
            }
            //}

            context.Response.Write(str);
        }
    }


    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
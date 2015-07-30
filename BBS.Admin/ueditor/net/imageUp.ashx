<%@ WebHandler Language="C#" Class="imageUp" %>

using System;
using System.Web;
using System.IO;
using System.Collections;
using System.Linq;

public class imageUp : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        if (!String.IsNullOrEmpty(context.Request.QueryString["fetch"]))
        {
            context.Response.AddHeader("Content-Type", "text/javascript;charset=utf-8");
            context.Response.Write(String.Format("updateSavePath([{0}]);", String.Join(", ", Config.ImageSavePath.Select(x => "\"" + x + "\""))));
            return;
        }

        context.Response.ContentType = "text/plain";

        //上传配置
        int size = 2;           //文件大小限制,单位MB                             //文件大小限制，单位MB
        string[] filetype = { ".gif", ".png", ".jpg", ".jpeg", ".bmp" };         //文件允许格式


        //上传图片
        Hashtable info = new Hashtable();
        Uploader up = new Uploader();

        string path = up.getOtherInfo(context, "dir");
        if (String.IsNullOrEmpty(path)) 
        {
            path = Config.ImageSavePath[0];
        } 
        else if (Config.ImageSavePath.Count(x => x == path) == 0)
        {
            context.Response.Write("{ 'state' : '非法上传目录' }");
            return;
        }

        info = up.upFile(context, path + '/', filetype, size);                   //获取上传状�?

        string title = up.getOtherInfo(context, "pictitle");                   //获取图片描述
        string oriName = up.getOtherInfo(context, "fileName");                //获取原始文件�?


        HttpContext.Current.Response.Write("{'url':'" + info["url"] + "','title':'" + title + "','original':'" + oriName + "','state':'" + info["state"] + "'}");  //向浏览器返回数据json数据
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

}
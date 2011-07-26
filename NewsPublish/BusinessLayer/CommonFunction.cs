using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;
using System.Web.UI.WebControls;

namespace NewsPublish.BusinessLayer
{
    public class CommonFunction
    {
        public static string  CreateAuthCodeImg(int width,int height,out string authcode)
        {
            string db="1,2,3,4,5,6,7,8,9,0,a,b,c,d,e,f,g,h,i,g,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z";
            string[] dbStr=db.Split(',');
            string codeStr=string.Empty;
            Random rand=new Random();
            for(int i=0;i<4;i++)
            {
               codeStr+=dbStr[rand.Next(dbStr.Length)];
            }
            Bitmap map=new Bitmap(width,height);
            Graphics g=Graphics.FromImage(map);
            WebColorConverter color=new WebColorConverter();
            g.Clear((Color)color.ConvertFromString("#FAE264"));
            //图片背景噪音线
            for(int i=0;i<12;i++)
            {
                int x1=rand.Next(map.Width);
                int x2=rand.Next(map.Width);
                int y1=rand.Next(map.Height);
                int y2=rand.Next(map.Height);
                g.DrawLine(new Pen(Color.LightGray),x1,y1,x2,y2);
            }
            Font font=new Font("Arial",15,FontStyle.Regular|FontStyle.Italic);
            System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(
            new Rectangle(0,0,map.Width,map.Height),Color.Blue,Color.Gray,1.2f,true);
            g.DrawString(codeStr,font,brush,0,0);
            authcode = codeStr;
            //图片前景噪音点
            //for(int i=0;i<10;i++)
            //{
            //    int x=rand.Next(map.Width);
            //    int y=rand.Next(map.Height);
            //    map.SetPixel(x,y,Color.White);
            //}
            //画图片边框
            //g.DrawRectangle(new Pen(Color.Black),0,0,map.Width-1,map.Height-1);
            
            //MemoryStream stream=new MemoryStream();
            //map.Save(stream,System.Drawing.Imaging.ImageFormat.Gif);
            //HttpContext.Current.Response.ClearContent();
            //HttpContext.Current.Response.ContentType = "image/gif";
            //HttpContext.Current.Response.BinaryWrite(stream.ToArray());
            
            
            string fileName="ViewPage\\Images\\AuthCodeImg\\"+DateTime.Now.ToFileTime()+".gif";
            string path = HttpContext.Current.Server.MapPath("~");
            map.Save(path+fileName);

            g.Dispose();
            map.Dispose();

            return "~//"+fileName.Replace("\\","/"); 
        }
    }
}
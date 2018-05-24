using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace BigDataNewsAPI.Controllers
{
    public class NewsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public struct News
        {
            public int id;
            public string news;
        }
        // GET api/<controller>/5
        public string Get(int id)
        {
            //string a = Server.MapPath("~/Content/Uploads");
            string startupPath = System.Web.HttpContext.Current.Server.MapPath("~/Content/onlineComing.csv");
            using (var reader = new StreamReader(startupPath))
            {
                while (!reader.EndOfStream)
                {
                    
                    var r = new Random();
                    var randomLineNumber = r.Next(0, 273000);

                    var line = reader.ReadLine();
                    for(int i=0;i<randomLineNumber;i++)
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    
                    var values = line.Split(',');
                    News news = new News();
                    if (values[0] != "id")
                    {
                        news.id = Int32.Parse( values[0]);
                        news.news = values[1];
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        return serializer.Serialize(news);
                    }
                    
                }
            }
            return "false";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}
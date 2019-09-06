using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PaShangDe
{
    class Program
    {
        static void Main(string[] args)
        {
            var http = new HttpClient();
            Task.Run(async () => 
            {
                for (int i = 1; i < 1500; i++)
                {
                    HttpResponseMessage response = await http.GetAsync(@"http://sfs-public-1257236099.cos.ap-beijing.myqcloud.com/teach-resource/resource/726/DatumBundle/"
                        + i +
                        @"/【1910密训资料】数据库系统原理（全国）.pdf");
                    //response.EnsureSuccessStatusCode();
                    var pageData = response.StatusCode.ToString();
                    if (pageData != "NotFound")
                    {
                        Console.WriteLine($"{i}   " + pageData);
                    }
                }
            }).GetAwaiter().GetResult();

            Console.WriteLine("完成了");
            Console.ReadKey();
        }
    }
}

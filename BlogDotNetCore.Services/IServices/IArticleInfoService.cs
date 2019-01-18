using System;
using System.Collections.Generic;
using System.Text;

namespace BlogDotNetCore.Services.Services
{
    public interface IArticleInfoService
    {
        bool Insert(string content,List<string> comments);
    }
}

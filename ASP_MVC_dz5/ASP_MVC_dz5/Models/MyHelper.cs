using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using ASP_MVC_dz5.Models;
using System.Web.Mvc.Html;

namespace ASP_MVC_dz5.App_Code
{
    public static class MyHelper
    {
        public static MvcHtmlString GenerateCustomTable<T>(this HtmlHelper helper, IEnumerable<T> collection, Func<T, string> additionalInfo = null)
        {
            TagBuilder table = new TagBuilder("table");
            table.AddCssClass("table");
            TagBuilder trHead = new TagBuilder("tr");
            //thead
            foreach (PropertyInfo propInfo in typeof(T).GetProperties())
            {
                trHead.InnerHtml += new TagBuilder("th") { InnerHtml = propInfo.Name }.ToString();
            }
            if (additionalInfo != null)
                trHead.InnerHtml += new TagBuilder("th").ToString();

            table.InnerHtml += trHead.ToString();

            //tbody
            foreach (var item in collection)
            {
                TagBuilder trTableBody = new TagBuilder("tr");
                foreach (var propInfo in typeof(T).GetProperties())
                {
                    if (propInfo.GetValue(item) == null)
                    {
                        trTableBody.InnerHtml += new TagBuilder("td").ToString();
                        continue;
                    }
                    if (propInfo.Name == "Role" && item is User)
                    {
                        var propInfoSub = propInfo.GetValue(item) as Role;
                        if (propInfoSub.Name != null)
                        {
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = propInfoSub.Name.ToString() }.ToString();
                            continue;
                        }
                        else
                        {
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = "" };
                            continue;
                        }
                    }
                    if (propInfo.Name == "Publisher" && item is Book)
                    {
                        var propInfoSub = propInfo.GetValue(item) as Publisher;
                        if (propInfoSub.Name!=null)
                        {
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = propInfoSub.Name.ToString() }.ToString();
                            continue;
                        }
                        else
                        {
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = ""};
                            continue;
                        }
                    }
                    if (propInfo.Name == "Authors" && item is Book)
                    {
                        string arrAuthor = "";
                            var b = item as Book;
                            foreach (var item2 in b.Authors)
                            {
                                arrAuthor += $"{item2.Name} ";
                            }
                            trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = arrAuthor };
                            continue;
                    }
                    trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = propInfo.GetValue(item).ToString() }.ToString();
                }

                if (additionalInfo != null)
                    trTableBody.InnerHtml += new TagBuilder("td") { InnerHtml = additionalInfo(item) }.ToString();

                table.InnerHtml += trTableBody.ToString();
            }

            return new MvcHtmlString(table.ToString());
        }
    }
}
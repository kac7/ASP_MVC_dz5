using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_MVC_dz5.Models
{
    public static class MyEnumerable
    {
        public static IEnumerable<Author> Add(this IEnumerable<Author> authors, Author author)
        {
            foreach (var item in authors)
            {
                yield return item;
            }
            yield return author;
        }
        public static IEnumerable<Author> Delete(this IEnumerable<Author> authors, int id)
        {
            if (authors != null)
            {
                foreach (var item in authors)
                {
                    if (item.Id != id)
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}